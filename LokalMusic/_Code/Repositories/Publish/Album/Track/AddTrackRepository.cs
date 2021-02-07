using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Publish.Album.Track;
using System;
using System.IO;
using System.Web;

namespace LokalMusic._Code.Repositories.Publish.Album.Track
{
    public class AddTrackRepository
    {
        public void GetArtistName(int artistId, IAddTrackModel model)
        {
            string query = "SELECT ArtistName FROM ArtistInfo WHERE UserId = @ArtistId;";
            var result = DbHelper.ExecuteScalar(query, ("ArtistId", artistId));

            model.ArtistName = result.ToString();
        }

        public void GetAlbumName(int albumId, IAddTrackModel model)
        {
            string query = "SELECT ProductName FROM Product WHERE ProductId = @AlbumId;";
            var result = DbHelper.ExecuteScalar(query, ("AlbumId", albumId));

            model.AlbumName = result.ToString();
        }

        public void AddTrack(IAddTrackModel model, int albumId, HttpPostedFile trackFile, HttpPostedFile clipFile)
        {
            int trackId = AddToProduct(model);
            int trackFileId = AddTrackFile(model, trackId, trackFile);
            int clipFileId = AddClipFile(model, trackId, clipFile);
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

        private int AddToProduct(IAddTrackModel model)
        {
            string query = @"
INSERT INTO Product(ProductTypeId,ProductStatusId,DateAdded,Price,ProductName)
VALUES (2,1,@dateAdded,@price,@trackName)

SELECT SCOPE_IDENTITY();
";
            string result = DbHelper.ExecuteScalar(
                query,
                ("dateAdded", DateTime.Now),
                ("price", model.Price),
                ("trackName", model.TrackName)).ToString();

            return int.Parse(result);
        }

        private int AddTrackFile(IAddTrackModel model, int trackId, HttpPostedFile trackFile)
        {
            var tfile = TagLib.File.Create(new HttpPostedFileAbstraction(trackFile));
            model.TrackFileDuration = tfile.Properties.Duration;

            string fileName = trackId + Path.GetExtension(trackFile.FileName);
            string fileLocation = FileSystemHelper.UploadFile(fileName, FileSystemHelper.TRACKS_CONTAINER_NAME, trackFile);
            model.TrackFile = fileLocation;
            
            string query = @"
INSERT INTO FileInfo(FileTypeId,FileName)
VALUES ((SELECT FileTypeId FROM FileType WHERE FileTypeName = @fileTypeName), @trackFile)

SELECT SCOPE_IDENTITY();
";
            string result = DbHelper.ExecuteScalar(
                query, 
                ("fileTypeName", FileSystemHelper.TRACKS_CONTAINER_NAME), 
                ("trackFile", model.TrackFile)).ToString();

            return int.Parse(result);
        }

        private int AddClipFile(IAddTrackModel model, int trackId, HttpPostedFile clipFile)
        {
            var tfile = TagLib.File.Create(new HttpPostedFileAbstraction(clipFile));
            model.ClipFileDuration = tfile.Properties.Duration;

            string fileName = trackId + Path.GetExtension(clipFile.FileName);
            string fileLocation = FileSystemHelper.UploadFile(fileName, FileSystemHelper.CLIPS_CONTAINER_NAME, clipFile);
            model.ClipFile = fileLocation;

            string query = @"
INSERT INTO FileInfo(FileTypeId,FileName)
VALUES ((SELECT FileTypeId FROM FileType WHERE FileTypeName = @fileTypeName), @clipFile)

SELECT SCOPE_IDENTITY();
";
            string result = DbHelper.ExecuteScalar(
                query, 
                ("fileTypeName", FileSystemHelper.CLIPS_CONTAINER_NAME),
                ("clipFile", model.ClipFile)).ToString();

            return int.Parse(result);
        }

        private int AddToGenre(IAddTrackModel model)
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

        public bool ValidateMaxTrackCount(int albumId)
        {
            string query = @"
SELECT COUNT(TrackId) AS TrackCount
FROM Track
LEFT JOIN Product
ON Track.TrackId = Product.ProductId
WHERE Track.AlbumId = @AlbumId
AND Product.ProductStatusId != 2;
";
            var result = DbHelper.ExecuteScalar(query, ("AlbumId", albumId));

            bool maxReached;
            if ((int)result >= 20)
                maxReached = true;
            else
                maxReached = false;

            return maxReached;
        }
    }


    public class HttpPostedFileAbstraction : TagLib.File.IFileAbstraction
    {
        private HttpPostedFile file;

        public HttpPostedFileAbstraction(HttpPostedFile file)
        {
            this.file = file;
        }

        public string Name
        {
            get { return file.FileName; }
        }

        public System.IO.Stream ReadStream
        {
            get { return file.InputStream; }
        }

        public System.IO.Stream WriteStream
        {
            get { throw new Exception("Cannot write to HttpPostedFile"); }
        }

        public void CloseStream(System.IO.Stream stream) { }
    }
}