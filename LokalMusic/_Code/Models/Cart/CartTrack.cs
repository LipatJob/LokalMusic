using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Cart
{
    public class CartTrack
    {
        public CartTrack()
        {
        }

        public CartTrack(int trackId, int albumId, int artistId, string trackName, string albumName, decimal price, int audioLength, string albumCover)
        {
            TrackId = trackId;
            AlbumId = albumId;
            ArtistId = artistId;
            TrackName = trackName;
            AlbumName = albumName;
            Price = price;
            AudioLength = audioLength;
            AlbumCover = albumCover;
        }

        public int TrackId { get; set; }
        public int AlbumId { get; set; }
        public int ArtistId { get; set; }

        public string TrackName { get; set; }
        public string AlbumName { get; set; }

        public Decimal Price { get; set; }

        public int AudioLength { get; set; }

        public string AlbumCover { get; set; }

        public string DetailsUrl 
        { 
            get 
            {
                return $"~/Store/" + this.ArtistId + "/" + this.AlbumId + "/" + this.TrackId;
            } 
        }

        public string TrackAlbumDetails
        {
            get
            {
                return $"~/Store/" + this.ArtistId + "/" + this.AlbumId;
            }
        }
    }
}