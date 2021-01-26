using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Publish.Album;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Repositories.Publish.Album
{
    public class AddAlbumRepository
    {
        public void GetArtistName(int artistId, AddAlbumModel model)
        {
            string query = "SELECT ArtistName FROM ArtistInfo WHERE UserId = @ArtistId;";
            var result = DbHelper.ExecuteScalar(query, ("ArtistId", artistId));

            model.ArtistName = result.ToString();
        }

        public int AddAlbum(AddAlbumModel model, int userId)
        {
            int albumId = AddToProduct(model);
            int albumCoverId = AddToFile(model);
            AddToAlbum(model, albumId, albumCoverId, userId);

            return albumId;
        }

        private int AddToProduct(AddAlbumModel model)
        {
            string query = @"
INSERT INTO Product(ProductTypeId,ProductStatusId,DateAdded,Price,ProductName)
VALUES
(1,1,@dateAdded,@price,@albumName)

SELECT ProductId AS AlbumId
FROM Product
WHERE ProductName = @albumName
AND DateAdded = (SELECT MAX(DateAdded) FROM Product WHERE ProductName = @albumName)
";

            string result = DbHelper.ExecuteScalar(
                query,
                ("dateAdded", DateTime.Now),
                ("price", model.Price),
                ("albumName", model.AlbumName)).ToString();

            return int.Parse(result);
        }

        private int AddToFile(AddAlbumModel model)
        {
            string query = @"
INSERT INTO FileInfo(FileTypeId,FileName)
VALUES
(1,@albumCover)

SELECT FileId
FROM FileInfo
WHERE FileName = @albumCover
";

            string result = DbHelper.ExecuteScalar(query, ("albumCover", model.AlbumCover)).ToString();
            return int.Parse(result);
        }

        private void AddToAlbum(AddAlbumModel model, int albumId, int albumCoverId, int userId)
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