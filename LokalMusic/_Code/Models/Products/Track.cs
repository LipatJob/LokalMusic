using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Products
{
    public class Track
    {
        public Track(){ }

        public int TrackId { get; set; }
        public string TrackName { get; set; }
        public string Description { get; set; }
        public TimeSpan TrackDuration { get; set; }
        public TimeSpan ClipDuration { get; set; }
        public DateTime DateAdded { get; set; } //Date track was added
        public DateTime DateReleased { get; set; }// Date its album was released
        public Decimal Price { get; set; }
        public string ProducerName { get; set; }

        public string ClipFileAddress { get; set; }

        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public int AlbumId { get; set; }
        public string Genre { get; set; }
        

    }
}