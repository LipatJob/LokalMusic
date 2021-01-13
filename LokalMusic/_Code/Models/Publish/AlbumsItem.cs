using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Publish
{
    public class AlbumsItem
    {
        public string AlbumCoverLink { get; set; }

        public string AlbumName { get; set; }

        public DateTime DateAdded { get; set; }

        public int TrackCount { get; set; }

        public string Producer { get; set; }

        public int SalesCount { get; set; }

        public decimal Price { get; set; }

        public string TracksURL { get; set; }

        public string EditURL { get; set; }
    }
}