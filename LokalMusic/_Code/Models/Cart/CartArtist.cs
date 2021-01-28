using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Cart
{
    public class CartArtist
    {

        public int ArtistId { get; set; }

        public string ArtistName { get; set; }
        public List<CartTrack> tracks { get; set; }


    }
}