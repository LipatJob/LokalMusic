using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Store
{
    public class AlbumSummary
    {
        public int AlbumId { get; set; }
        public int ArtistId { get; set; }

        public string AlbumName { get; set; }
        public Decimal Price { get; set; }
        public string ProducerName { get; set; }
        public string AlbumCover { get; set; }

        public DateTime DateReleased { get; set; }

        // processed in presenter
        public List<string> Genre { get; set; }

        // processed in presenter, not in repository
        public int TrackCounts { get; set; }
        public int TrackMinutes { get; set; }

    }
}