using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Products
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string Location { get; set; }
        public string Bio { get; set; }
        public List<Album> Albums { get; set; }
        
        // UserInfo - contains reference eto FileInfo
    }
}