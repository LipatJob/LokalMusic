using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Publish.Album;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Repositories.Publish.Album
{
    public class EditAlbumRepository
    {
        public void GetArtistName(int artistId, IEditAlbumModel model)
        {
            string query = "SELECT ArtistName FROM ArtistInfo WHERE UserId = @ArtistId;";
            var result = DbHelper.ExecuteScalar(query, ("ArtistId", artistId));

            model.ArtistName = result.ToString();
        }

        public void GetAlbumDetails(IEditAlbumModel model, int albumId)
        {
            string query = @"
SELECT Product.ProductName AS AlbumName,
Album.Description,
Album.DateReleased,
Album.ProducerName AS Producer,
Product.Price,
FileInfo.FileName AS AlbumCover
FROM Album
LEFT JOIN Product
ON Album.AlbumId = Product.ProductId
LEFT JOIN FileInfo
ON Album.AlbumCoverID = FileInfo.FileId
WHERE Product.ProductId = @AlbumId
";

            var result = DbHelper.ExecuteDataTableQuery(query, ("AlbumId", albumId));

            model.AlbumName = (string)result.Rows[0]["AlbumName"];
            model.Description = (string)result.Rows[0]["Description"];
            model.DateReleased = (DateTime)result.Rows[0]["DateReleased"];
            model.Producer = (string)result.Rows[0]["Producer"];
            model.Price = (decimal)result.Rows[0]["Price"];
            model.AlbumCover = (string)result.Rows[0]["AlbumCover"];
        }

        public void EditAlbum(IEditAlbumModel model, int albumId)
        {
            string updateProductQuery = @"
UPDATE Product
SET
Price = @price,
ProductName = @albumName
WHERE ProductId = @albumId;";

            string updateAlbumQuery = @"
UPDATE Album
SET
Description = @description,
DateReleased = @dateReleased,
ProducerName = @producer
WHERE AlbumId = @albumId;
";

            string getAlbumIdQuery = @"
SELECT AlbumCoverID FROM Album
WHERE AlbumId = @albumId;";


            DbHelper.ExecuteNonQuery(updateProductQuery,
                ("price", model.Price),
                ("albumName", model.AlbumName),
                ("albumId", albumId));

            DbHelper.ExecuteNonQuery(updateAlbumQuery,
                ("albumId", albumId),
                ("description", model.Description),
                ("dateReleased", model.DateReleased),
                ("producer", model.Producer));

            var albumIdResult = DbHelper.ExecuteScalar(
                getAlbumIdQuery,
                ("albumId", albumId));

            if(albumIdResult != null)
            {
                int albumCoverId = (int)albumIdResult;
                string query2 = "UPDATE FileInfo SET FileName = @albumCover WHERE FileId = @albumCoverId";
                DbHelper.ExecuteScalar(query2, ("albumCover", model.AlbumCover), ("albumCoverId", albumCoverId));
            }
        }


        public void UnlistAlbum(int albumId)
        {
            string query = "UPDATE Product SET ProductStatusId = 2 WHERE ProductId = @albumId " +
                "SELECT TrackId FROM Track WHERE AlbumId = @albumId";
            var result = DbHelper.ExecuteDataTableQuery(query, ("albumId", albumId));

            foreach (DataRow row in result.Rows)
            {
                int trackId = (int)row["TrackId"];
                string query2 = "UPDATE Product SET ProductStatusId = 2 WHERE ProductId = @trackId";
                DbHelper.ExecuteScalar(query2, ("trackId", trackId));
            }
        }
    }
}