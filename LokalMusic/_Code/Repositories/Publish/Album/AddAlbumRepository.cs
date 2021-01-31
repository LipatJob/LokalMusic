using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Publish.Album;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Repositories.Publish.Album
{
    public class AddAlbumRepository
    {
        public void GetArtistName(int artistId, IAddAlbumModel model)
        {
            string query = "SELECT ArtistName FROM ArtistInfo WHERE UserId = @ArtistId;";
            var result = DbHelper.ExecuteScalar(query, ("ArtistId", artistId));

            model.ArtistName = result.ToString();
        }

        public int AddAlbum(IAddAlbumModel model, int userId, HttpPostedFile albumCover)
        {
            int albumId = AddToProduct(model);
            int albumCoverId = AddToFile(model, albumId, albumCover);
            AddToAlbum(model, albumId, albumCoverId, userId);

            return albumId;
        }

        private int AddToProduct(IAddAlbumModel model)
        {
            string query = @"
INSERT INTO Product(ProductTypeId,ProductStatusId,DateAdded,Price,ProductName)
VALUES
(1,1,@dateAdded,@price,@albumName);

SELECT SCOPE_IDENTITY();
";

            string result = DbHelper.ExecuteScalar(
                query,
                ("dateAdded", DateTime.Now),
                ("price", model.Price),
                ("albumName", model.AlbumName)).ToString();

            return int.Parse(result);
        }

        private int AddToFile(IAddAlbumModel model, int albumId, HttpPostedFile albumCover)
        {
            string fileName = albumId + Path.GetExtension(albumCover.FileName);
            string fileLocation = FileSystemHelper.UploadFile(fileName, FileSystemHelper.ALBUMCOVER_CONTAINER_NAME, albumCover);
            model.AlbumCover = fileLocation;

            string query = @"
INSERT INTO FileInfo(FileTypeId,FileName)
VALUES
((SELECT FileTypeId FROM FileType WHERE FileTypeName = @fileTypeName),@albumCover);

SELECT SCOPE_IDENTITY();
";

            string result = DbHelper.ExecuteScalar(
                query, 
                ("fileTypeName", FileSystemHelper.ALBUMCOVER_CONTAINER_NAME),
                ("albumCover", model.AlbumCover)).ToString();
            return int.Parse(result);
        }

        private void AddToAlbum(IAddAlbumModel model, int albumId, int albumCoverId, int userId)
        {
            string query = "INSERT INTO Album VALUES " +
                "(@albumId,@albumCoverId,@description,@dateReleased,@producer,@userId)";

            DbHelper.ExecuteScalar(
                query,
                ("albumId", albumId),
                ("albumCoverId", albumCoverId),
                ("description", model.Description),
                ("dateReleased", model.DateReleased),
                ("producer", model.Producer),
                ("userId", userId)
                );
        }
    }
}