using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Publish.Albums
{
    public class TracksItem
    {
        public string TrackCoverLink { get; set; }

        public string TrackName { get; set; }

        public DateTime DateAdded { get; set; }

        public string Genre { get; set; }

        public TimeSpan Duration { get; set; }

        public int SalesCount { get; set; }

        public decimal Price { get; set; }

        public string EditURL { get; set; }
    }
}