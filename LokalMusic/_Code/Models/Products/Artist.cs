using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Products
{
    public class Artist
    {
        public Artist() { }
        public Artist(int artistId, string artistName, string location, string bio)
        {
            ArtistId = artistId;
            ArtistName = artistName;
            Location = location;
            Bio = bio;
        }

        public int ArtistId { get; set; } // UserId
        public string ArtistName { get; set; }
        public string Location { get; set; }
        public string Bio { get; set; }

        public string Email { get; set; }
        public string UserName { get; set; }
        public DateTime DateRegistered { get; set; }

        public string ProfileImage { get; set; }

        public List<Album> Albums { get; set; }
    }
}