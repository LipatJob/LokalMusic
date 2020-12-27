using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Author - Gene Garcia

namespace LokalMusic._Code.Repositories
{
    public class ProductRepository
    {
        public void GetCompleteProductCatalogue()
        {
            string query = "SELECT * " + 
                           "FROM Track " +
                           "INNER JOIN Product " +
                           "ON Track.TrackId = Product.ProductId " +
                           "INNER JOIN Album " +
                           "ON Track.AlbumId = Album.AlbumId " +
                           "INNER JOIN ArtistInfo " + 
                           "ON Album.UserId = ArtistInfo.UserId " +
                           "WHERE Product.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE StatusName = 'LISTED') ";
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
                           "WHERE Product.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE StatusName = 'LISTED') " +
                           "AND ArtistInfo.UserId = 0 " +
                           "AND ArtistInfo.ArtistName = ' '";
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
                           "WHERE Product.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE StatusName = 'LISTED') " +
                           "AND Album.AlbumName = ' ' " +
                           "AND Album.Album.Id = 0";
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
                           "WHERE Product.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE StatusName = 'LISTED') " +
                           "AND Track.TrackName = ' ' " +
                           "AND Track.TrackId = 0";
        }

    }
}