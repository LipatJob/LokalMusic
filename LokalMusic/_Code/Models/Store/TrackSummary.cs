using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Store
{
    public class TrackSummary
    {
        public int TrackId { get; set; }
        public int AlbumId { get; set; }
        public int ArtistId { get; set; }

        public string TrackName { get; set; }
        public Decimal Price { get; set; }
        public DateTime DateAdded { get; set; }
        public string AlbumName { get; set; }
        public string ArtistName { get; set; }

        public string Genre { get; set; }

        public string AudioClip { get; set; }
        public TimeSpan AudioClipDuration { get; set; }
        public TimeSpan AudioDuration { get; set; }

        public string AlbumCover { get; set; }

    }
}