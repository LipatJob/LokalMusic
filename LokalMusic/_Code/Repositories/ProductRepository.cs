using LokalMusic._Code.Models.Products;
using LokalMusic.Code.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Author - Gene Garcia

namespace LokalMusic._Code.Repositories
{
    public class ProductRepository
    {

        const string STATUS_PRODUCT_LISTED = "LISTED";

        public void GetCompleteProductCatalogue()
        {
            string query = "SELECT * FROM ArtistInfo";

            var values = DbHelper.ExecuteDataTableQuery(query);
            bool valid = values.Rows.Count > 0;

            List<Artist> artists = new List<Artist>();

            if (valid)
            {
                for (int i = 0; i < values.Rows.Count-1; i++)
                {
                    Artist artist = new Artist();
                    
                }
            }
        }

        public void GetProductByArtist(/*IArtistModel or Id or Name*/)
        {
            string query = "SELECT * " +
                           "FROM Track " +
                           "INNER JOIN Product " +
                           "ON Track.TrackId = Product.ProductId " +
                           "INNER JOIN Album " +
                           "ON Track.AlbumId = Album.AlbumId " +
                           "INNER JOIN ArtistInfo " +
                           "ON Album.UserId = ArtistInfo.UserId " +
                           "WHERE Product.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE StatusName = '" + ProductRepository.STATUS_PRODUCT_LISTED + "') " +
                           "AND ArtistInfo.UserId = @UserId " +
                           "AND ArtistInfo.ArtistName = @ArtistName";

            var values = DbHelper.ExecuteDataTableQuery(query);
            bool valid = values.Rows.Count > 0;

            if (valid)
            {

            }
        }

        public void GetProductByAlbum(/*IAlbum or Id or Name*/)
        {
            string query = "SELECT * " +
                           "FROM Track " +
                           "INNER JOIN Product " +
                           "ON Track.TrackId = Product.ProductId " +
                           "INNER JOIN Album " +
                           "ON Track.AlbumId = Album.AlbumId " +
                           "INNER JOIN ArtistInfo " +
                           "ON Album.UserId = ArtistInfo.UserId " +
                           "WHERE Product.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE StatusName = '" + ProductRepository.STATUS_PRODUCT_LISTED + "') " +
                           "AND Album.AlbumName = @AlbumName " +
                           "AND Album.Album.Id = @AlbumId ";

            var values = DbHelper.ExecuteDataTableQuery(query);
            bool valid = values.Rows.Count > 0;

            if (valid)
            {

            }
        }

        public void GetProductByTrack(/*ITrack or Id or Name*/)
        {
            string query = "SELECT * " +
                           "FROM Track " +
                           "INNER JOIN Product " +
                           "ON Track.TrackId = Product.ProductId " +
                           "INNER JOIN Album " +
                           "ON Track.AlbumId = Album.AlbumId " +
                           "INNER JOIN ArtistInfo " +
                           "ON Album.UserId = ArtistInfo.UserId " +
                           "WHERE Product.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE StatusName = '" + ProductRepository.STATUS_PRODUCT_LISTED + "') " +
                           "AND Track.TrackName = @TrackName " +
                           "AND Track.TrackId = @TrackId";

            var values = DbHelper.ExecuteDataTableQuery(query);
            bool valid = values.Rows.Count > 0;

            if (valid)
            {

            }
        }

    }
}