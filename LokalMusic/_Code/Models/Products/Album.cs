using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Products
{
    public class Album
    {
        public int AlbumId { get; set; }
        public int AlbumCoverId { get; set; }
        public string AlbumName { get; set; }
        public string Description { get; set; }
        public DateTime DateReleased { get; set; }
        public int UserId { get; set; }

        public List<Track> Tracks { get; set; }

        // FileInfo
    }
}