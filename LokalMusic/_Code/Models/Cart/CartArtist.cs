using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Cart
{
    public class CartArtist
    {
        public CartArtist()
        {
        }

        public CartArtist(int artistId, string artistName)
        {
            ArtistId = artistId;
            ArtistName = artistName;
        }

        public CartArtist(int artistId, string artistName, List<CartTrack> tracks)
        {
            ArtistId = artistId;
            ArtistName = artistName;
            this.tracks = tracks;
        }

        public int ArtistId { get; set; }

        public string ArtistName { get; set; }
        public List<CartTrack> tracks { get; set; }

        public string DetailsUrl 
        { 
            get 
            {
                return $"~/Store/" + this.ArtistId;
            }
        }

    }
}