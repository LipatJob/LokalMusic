using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Publish.Album.Track;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Repositories.Publish.Album.Track
{
    public class EditTrackRepository
    {
        public void GetArtistName(int artistId, IEditTrackModel model)
        {
            string query = "SELECT ArtistName FROM ArtistInfo WHERE UserId = @ArtistId;";
            var result = DbHelper.ExecuteScalar(query, ("ArtistId", artistId));

            model.ArtistName = result.ToString();
        }

        public void GetAlbumName(int albumId, IEditTrackModel model)
        {
            string query = "SELECT ProductName FROM Product WHERE ProductId = @AlbumId;";
            var result = DbHelper.ExecuteScalar(query, ("AlbumId", albumId));

            model.AlbumName = result.ToString();
        }

        public void GetTrackDetails(IEditTrackModel model, int trackId)
        {
            string query = @"
SELECT Product.ProductName AS TrackName,
Genre.GenreName AS Genre,
Track.Description,
Product.Price,
FileInfo.FileName AS TrackFile,
Track.TrackDuration AS TrackFileDuration,
(SELECT FileName FROM Track LEFT JOIN FileInfo 
ON Track.ClipFileID = FileInfo.FileId WHERE TrackId = @trackId) AS ClipFile,
Track.ClipDuration AS ClipFileDuration
FROM Track
LEFT JOIN Product
ON Track.TrackId = Product.ProductId
LEFT JOIN Genre 
ON Track.GenreId = Genre.GenreId
LEFT JOIN FileInfo
ON Track.TrackFileID = FileInfo.FileId
WHERE TrackId = @trackId
";

            var result = DbHelper.ExecuteDataTableQuery(query, ("trackId", trackId));

            model.TrackName = (string)result.Rows[0]["TrackName"];
            model.Genre = (string)result.Rows[0]["Genre"];
            model.Description = (string)result.Rows[0]["Description"];
            model.Price = (decimal)result.Rows[0]["Price"];
            model.TrackFile = (string)result.Rows[0]["TrackFile"];
            model.TrackFileDuration = (TimeSpan)result.Rows[0]["TrackFileDuration"];
            model.ClipFile = (string)result.Rows[0]["ClipFile"];
            model.ClipFileDuration = (TimeSpan)result.Rows[0]["ClipFileDuration"];
        }

        public void EditTrack(IEditTrackModel model, int trackId, HttpPostedFile trackFile, HttpPostedFile clipFile)
        {
            if (model.TrackIsUpdated)
            {
                UploadTrackFile(model, trackId, trackFile);
            }
            
            if (model.ClipIsUpdated)
            {
                UploadClipFile(model, trackId, clipFile);
            }

            int genreId = EditInGenre(model);

            string updateTrackQuery = @"
UPDATE Product
SET ProductName = @trackName,
Price = @price
WHERE ProductId = @trackId;

UPDATE Track
SET GenreId = @genreId,
Description = @description,
TrackDuration = @trackFileDuration,
ClipDuration = @clipFileDuration
WHERE TrackId = @trackId;";

            DbHelper.ExecuteScalar(
                updateTrackQuery,
                ("trackName", model.TrackName),
                ("price", model.Price),
                ("trackId", trackId),
                ("genreId", genreId),
                ("description", model.Description),
                ("trackFileDuration", model.TrackFileDuration),
                ("clipFileDuration", model.ClipFileDuration)
                );
        }

        private void UploadTrackFile(IEditTrackModel model, int trackId, HttpPostedFile trackFile)
        {
            var tfile = TagLib.File.Create(new HttpPostedFileAbstraction(trackFile));
            model.TrackFileDuration = tfile.Properties.Duration;

            string fileName = trackId + Path.GetExtension(trackFile.FileName);
            string fileLocation = FileSystemHelper.UploadFile(fileName, FileSystemHelper.TRACKS_CONTAINER_NAME, trackFile, true);
            model.TrackFile = fileLocation;
        }

        private void UploadClipFile(IEditTrackModel model, int trackId, HttpPostedFile clipFile)
        {
            var tfile = TagLib.File.Create(new HttpPostedFileAbstraction(clipFile));
            model.ClipFileDuration = tfile.Properties.Duration;

            string fileName = trackId + Path.GetExtension(clipFile.FileName);
            string fileLocation = FileSystemHelper.UploadFile(fileName, FileSystemHelper.CLIPS_CONTAINER_NAME, clipFile, true);
            model.ClipFile = fileLocation;
        }

        private int EditInGenre(IEditTrackModel model)
        {
            var genreId = DbHelper.ExecuteScalar(
                "SELECT GenreId FROM Genre WHERE GenreName = @genre",
                ("genre", model.Genre.ToUpper()));

            if (genreId == null)
            {
                genreId = DbHelper.ExecuteScalar(
                    "INSERT INTO Genre(GenreName) VALUES (@genre) " +
                    "SELECT GenreId FROM Genre WHERE GenreName = @genre",
                    ("genre", model.Genre.ToUpper()));
            }

            return int.Parse(genreId.ToString());
        }

        public void UnlistTrack(int trackId)
        {
            string query = "UPDATE Product SET ProductStatusId = 2 WHERE ProductId = @trackId";
            DbHelper.ExecuteScalar(query, ("trackId", trackId));
        }
    }
}