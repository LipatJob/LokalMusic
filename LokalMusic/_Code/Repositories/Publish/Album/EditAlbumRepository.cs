using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Publish.Album;
using System;
using System.Data;
using System.IO;
using System.Web;

namespace LokalMusic._Code.Repositories.Publish.Album
{
    public class EditAlbumRepository
    {
        private const string WITHDRAWN_STATUS = "WITHDRAWN";
        private const string UNPUBLISHED_STATUS = "UNPUBLISHED";
        private const string PUBLISHED_STATUS = "PUBLISHED";

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
FileInfo.FileName AS AlbumCover,
ProductStatus.StatusName AS Status
FROM Album
LEFT JOIN Product ON Album.AlbumId = Product.ProductId
LEFT JOIN FileInfo ON Album.AlbumCoverID = FileInfo.FileId
LEFT JOIN ProductStatus ON Product.ProductStatusId = ProductStatus.ProductStatusId
WHERE Product.ProductId = @AlbumId
";

            var result = DbHelper.ExecuteDataTableQuery(query, ("AlbumId", albumId));

            model.AlbumName = (string)result.Rows[0]["AlbumName"];
            model.Description = (string)result.Rows[0]["Description"];
            model.DateReleased = (DateTime)result.Rows[0]["DateReleased"];
            model.Producer = (string)result.Rows[0]["Producer"];
            model.Price = (decimal)result.Rows[0]["Price"];
            model.AlbumCover = (string)result.Rows[0]["AlbumCover"];
            model.Status = (string)result.Rows[0]["Status"];
        }

        public bool GetAlbumHasTrack(int albumId)
        {
            string query = @"
SELECT COUNT(TrackId) AS TrackCount
FROM Track
LEFT JOIN Product ON Track.TrackId = Product.ProductId
WHERE Track.AlbumId = @AlbumId
AND Product.ProductStatusId != 2
";
            var result = DbHelper.ExecuteScalar(query, ("AlbumId", albumId));

            if ((int)result > 0)
                return true;
            else
                return false;
        }

        public void EditAlbum(IEditAlbumModel model, int albumId, HttpPostedFile albumCover)
        {
            if (model.AlbumCoverIsUpdated)
            {
                string fileName = albumId + Path.GetExtension(albumCover.FileName);
                string fileLocation = FileSystemHelper.UploadFile(fileName, FileSystemHelper.ALBUMCOVER_CONTAINER_NAME, albumCover, true);
                model.AlbumCover = fileLocation;
            }

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

            string getAlbumCoverIdQuery = @"
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

            var result = DbHelper.ExecuteScalar(
                getAlbumCoverIdQuery,
                ("albumId", albumId));

            if (result != null)
            {
                int albumCoverId = (int)result;
                string query2 = "UPDATE FileInfo SET FileName = @albumCover WHERE FileId = @albumCoverId";
                DbHelper.ExecuteScalar(query2, ("albumCover", model.AlbumCover), ("albumCoverId", albumCoverId));
            }
        }

       

        public string GetAlbumStatus(int albumId)
        {
            string query = @"
SELECT ProductStatus.StatusName FROM Product 
LEFT JOIN ProductStatus ON Product.ProductStatusId = ProductStatus.ProductStatusId 
WHERE Product.ProductId = @AlbumId
";
            var result = DbHelper.ExecuteScalar(query, ("AlbumId", albumId));

            return (string)result;
        }

        public void WithdrawAlbum(int albumId)
        {
            ChangeAlbumStatus(albumId, WITHDRAWN_STATUS);
            ChangeAllAlbumTrackStatus(albumId, WITHDRAWN_STATUS);
        }

        public void UnpublishAlbum(int albumId)
        {
            ChangeAlbumStatus(albumId, UNPUBLISHED_STATUS);
            ChangeUnwithdrawnAlbumTrackStatus(albumId, UNPUBLISHED_STATUS);
        }

        public void PublishAlbum(int albumId)
        {
            ChangeAlbumStatus(albumId, PUBLISHED_STATUS);
            ChangeUnwithdrawnAlbumTrackStatus(albumId, PUBLISHED_STATUS);
        }

        public void ChangeAlbumStatus(int albumId, string productStatus)
        {
            string StatusQuery = @"
UPDATE [Product]
SET ProductStatusId = (SELECT ProductStatusId
						FROM [ProductStatus]
						WHERE StatusName = @ProductStatus)
WHERE ProductId = @ProductId";
            DbHelper.ExecuteNonQuery(
                StatusQuery,
                ("ProductStatus", productStatus),
                ("ProductId", albumId));
        }

        public void ChangeAllAlbumTrackStatus(int albumId, string productStatus)
        {
            string updateQuery = @"
UPDATE [Product]
SET ProductStatusId = (SELECT ProductStatusId
						FROM [ProductStatus]
						WHERE StatusName = @ProductStatus)
WHERE ProductId IN (SELECT TrackId FROM Track WHERE AlbumId = @AlbumId)";

            DbHelper.ExecuteNonQuery(
                updateQuery,
                ("ProductStatus", productStatus),
                ("AlbumId", albumId));
        }

        public void ChangeUnwithdrawnAlbumTrackStatus(int albumId, string productStatus)
        {
            string updateQuery = $@"
UPDATE [Product]
SET ProductStatusId = (SELECT ProductStatusId
						FROM [ProductStatus]
						WHERE StatusName = @ProductStatus)
WHERE 
    ProductId IN (SELECT TrackId FROM Track WHERE AlbumId = @AlbumId) AND
    ProductStatusId != (SELECT ProductStatusId
						FROM [ProductStatus]
						WHERE StatusName = '{WITHDRAWN_STATUS}')";

            DbHelper.ExecuteNonQuery(
                updateQuery,
                ("ProductStatus", productStatus),
                ("AlbumId", albumId));
        }
    }
}