using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Products
{
    public class Track
    {
        public int TrackId { get; set; }
        public int AlbumId { get; set; }
        public int GenreId { get; set; }
        public int TrackFileId { get; set; }
        public int ClipFileId { get; set; }

        public string TrackName { get; set; }
        public DateTime TrackDuration { get; set; }
        public string Description { get; set; }
        public DateTime ClipDuration { get; set; }

        // FileInfo
        // FileType?
    }
}