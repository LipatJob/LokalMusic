using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Publish.Album.Track;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
Track.ClipDuration AS ClipFileDuration,
ProductStatus.StatusName AS Status
FROM Track
LEFT JOIN Product ON Track.TrackId = Product.ProductId
LEFT JOIN Genre ON Track.GenreId = Genre.GenreId
LEFT JOIN FileInfo ON Track.TrackFileID = FileInfo.FileId
LEFT JOIN ProductStatus ON Product.ProductStatusId = ProductStatus.ProductStatusId
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
            model.Status = (string)result.Rows[0]["Status"];
        }

        public void GetGenreList(IEditTrackModel model)
        {
            string query = "SELECT GenreName FROM Genre";
            var result = DbHelper.ExecuteDataTableQuery(query);

            List<string> genreList = new List<string> { };
            foreach (DataRow row in result.Rows)
            {
                string genre = (string)row["GenreName"];
                genreList.Add(genre);
            }
            model.Genres = genreList;
        }

        public bool CheckIfLastPublished(int albumId)
        {
            string query = "SELECT COUNT(TrackId) FROM Track LEFT JOIN Product ON Track.TrackId = Product.ProductId WHERE AlbumId = @AlbumId AND ProductStatusId = 1;";
            var result = DbHelper.ExecuteScalar(query, ("AlbumId", albumId));

            if ((int)result <= 1)
                return true;
            else
                return false;
        }

        public bool CheckAlbumIsPublished(int albumId)
        {
            string query = "SELECT ProductStatusId FROM Product WHERE ProductId = @AlbumId;";
            var result = DbHelper.ExecuteScalar(query, ("AlbumId", albumId));

            if ((int)result == 1)
                return true;
            else
                return false;
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
Description = @description
WHERE TrackId = @trackId;";

            string fileIdQuery = @"
SELECT TrackFileID, ClipFileID
FROM Track
WHERE TrackId = @trackId;";

            DbHelper.ExecuteScalar(
                updateTrackQuery,
                ("trackName", model.TrackName),
                ("price", model.Price),
                ("trackId", trackId),
                ("genreId", genreId),
                ("description", model.Description)
                );

            var result = DbHelper.ExecuteDataTableQuery(
                fileIdQuery, ("trackId", trackId));

            if (result != null)
            {
                int trackFileId = (int)result.Rows[0]["TrackFileID"];
                int clipFileId = (int)result.Rows[0]["ClipFileID"];

                string updateFileQuery = "UPDATE FileInfo SET FileName = @trackFile WHERE FileId = @trackFileId " +
                    "UPDATE FileInfo SET FileName = @clipFile WHERE FileId = @clipFileId";
                DbHelper.ExecuteScalar(updateFileQuery,
                    ("trackFile", model.TrackFile),
                    ("trackFileId", trackFileId),
                    ("clipFile", model.ClipFile),
                    ("clipFileId", clipFileId));
            }
        }

        private void UploadTrackFile(IEditTrackModel model, int trackId, HttpPostedFile trackFile)
        {
            var tfile = TagLib.File.Create(new HttpPostedFileAbstraction(trackFile));
            model.TrackFileDuration = tfile.Properties.Duration;

            string fileName = trackId + Path.GetExtension(trackFile.FileName);
            string fileLocation = FileSystemHelper.UploadFile(fileName, FileSystemHelper.TRACKS_CONTAINER_NAME, trackFile, true);
            model.TrackFile = fileLocation;

            string query = "UPDATE Track SET TrackDuration = @trackFileDuration WHERE TrackId = @trackId;";
            DbHelper.ExecuteNonQuery(query, ("trackFileDuration", model.TrackFileDuration), ("trackId", trackId));
        }

        private void UploadClipFile(IEditTrackModel model, int trackId, HttpPostedFile clipFile)
        {
            var tfile = TagLib.File.Create(new HttpPostedFileAbstraction(clipFile));
            model.ClipFileDuration = tfile.Properties.Duration;

            string fileName = trackId + Path.GetExtension(clipFile.FileName);
            string fileLocation = FileSystemHelper.UploadFile(fileName, FileSystemHelper.CLIPS_CONTAINER_NAME, clipFile, true);
            model.ClipFile = fileLocation;

            string query = "UPDATE Track SET ClipDuration = @clipFileDuration WHERE TrackId = @trackId;";
            DbHelper.ExecuteNonQuery(query, ("clipFileDuration", model.ClipFileDuration), ("trackId", trackId));
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

        public string GetTrackStatus(int trackId)
        {
            string query = @"
SELECT ProductStatus.StatusName FROM Product 
LEFT JOIN ProductStatus ON Product.ProductStatusId = ProductStatus.ProductStatusId 
WHERE Product.ProductId = @TrackId
";
            var result = DbHelper.ExecuteScalar(query, ("TrackId", trackId));

            return (string)result;
        }
        public void WithdrawTrack(int trackId)
        {
            int albumId = (int) DbHelper.ExecuteScalar("SELECT AlbumId FROM Track WHERE TrackId = @TrackId", ("TrackId", trackId));
            bool isLastPublished = CheckIfLastPublished(albumId);
            string query = "UPDATE Product SET ProductStatusId = 2 WHERE ProductId = @trackId";

            DbHelper.ExecuteNonQuery(query, ("trackId", trackId));
            if (isLastPublished)
            {
                DbHelper.ExecuteNonQuery("UPDATE Product SET ProductStatusId = 4 WHERE ProductId = @AlbumId", ("AlbumId", albumId));
            }
        }

        public void UnpublishTrack(int trackId)
        {
            string query = "UPDATE Product SET ProductStatusId = 4 WHERE ProductId = @trackId";
            DbHelper.ExecuteNonQuery(query, ("trackId", trackId));
        }

        public void PublishTrack(int trackId)
        {
            string query = "UPDATE Product SET ProductStatusId = 1 WHERE ProductId = @trackId";
            DbHelper.ExecuteNonQuery(query, ("trackId", trackId));
        }
    }
}