using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Publish.Album.Track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Repositories.Publish.Album.Track
{
    public class AddTrackRepository
    {
        public void GetArtistName(int artistId, AddTrackModel model)
        {
            string query = "SELECT ArtistName FROM ArtistInfo WHERE UserId = @ArtistId;";
            var result = DbHelper.ExecuteScalar(query, ("ArtistId", artistId));

            model.ArtistName = result.ToString();
        }

        public void GetAlbumName(int albumId, AddTrackModel model)
        {
            string query = "SELECT ProductName FROM Product WHERE ProductId = @AlbumId;";
            var result = DbHelper.ExecuteScalar(query, ("AlbumId", albumId));

            model.AlbumName = result.ToString();
        }

        public void AddTrack(AddTrackModel model, int albumId)
        {
            int trackId = AddToProduct(model);
            //int trackFileId = AddTrackFile(model);
            //int clipFileId = AddClipFile(model);
            int trackFileId = 4;
            int clipFileId = 5;
            int genreId = AddToGenre(model);

            string query = "INSERT INTO Track VALUES(@trackId,@albumId,@genreId,@trackFileId,@clipFileId,@trackDuration,@description,@clipDuration)";
            DbHelper.ExecuteScalar(
                query,
                ("trackId", trackId),
                ("albumId", albumId),
                ("genreId", genreId),
                ("trackFileId", trackFileId),
                ("clipFileId", clipFileId),
                ("trackDuration", model.TrackFileDuration),
                ("description", model.Description),
                ("clipDuration", model.ClipFileDuration));
        }

        private int AddToProduct(AddTrackModel model)
        {
            string query = @"
INSERT INTO Product(ProductTypeId,ProductStatusId,DateAdded,Price,ProductName)
VALUES (2,1,@dateAdded,@price,@trackName)

SELECT ProductId AS TrackId
FROM Product
WHERE ProductName = @trackName
AND DateAdded = (SELECT MAX(DateAdded) FROM Product WHERE ProductName = @trackName)
";
            string result = DbHelper.ExecuteScalar(
                query,
                ("dateAdded", DateTime.Now),
                ("price", model.Price),
                ("trackName", model.TrackName)).ToString();

            return int.Parse(result);
        }

        private int AddTrackFile(AddTrackModel model)
        {
            string query = @"
INSERT INTO FileInfo(FileTypeId,FileName)
VALUES (2,@trackFile)

SELECT FileId FROM FileInfo
WHERE FileName = @trackFile
";
            string result = DbHelper.ExecuteScalar(
                query, ("trackFile", model.TrackFile)).ToString();

            return int.Parse(result);
        }

        private int AddClipFile(AddTrackModel model)
        {
            string query = @"
INSERT INTO FileInfo(FileTypeId,FileName)
VALUES (2,@clipFile)

SELECT FileId FROM FileInfo
WHERE FileName = @clipFile
";
            string result = DbHelper.ExecuteScalar(
                query, ("clipFile", model.ClipFile)).ToString();

            return int.Parse(result);
        }

        private int AddToGenre(AddTrackModel model)
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
    }
}