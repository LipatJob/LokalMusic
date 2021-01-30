using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Cart
{
    public class CartAlbum
    {
        public CartAlbum()
        {
        }

        public CartAlbum(int albumId, int artistId, string albumName, string artistName, decimal price, string albumCoverAddress)
        {
            AlbumId = albumId;
            ArtistId = artistId;
            AlbumName = albumName;
            ArtistName = artistName;
            Price = price;
            AlbumCoverAddress = albumCoverAddress;
        }

        public int AlbumId { get; set; }
        public int ArtistId { get; set; }

        public string AlbumName { get; set; }
        public string ArtistName { get; set; }
        public Decimal Price { get; set; }

        public string AlbumCoverAddress { get; set; }

        public int TrackCount { get; set; }
        public int TrackTotalMinutes { get; set; }

        public string DetailsUrl 
        {
            get
            {
                return $"~/Store/" + this.ArtistId + "/" + this.AlbumId;
            }
        }

        public string AlbumArtistUrl
        {
            get
            {
                return $"~/Store/" + this.ArtistId;
            }
        }

    }
}