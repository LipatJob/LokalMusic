using System;
using System.Collections.Generic;

namespace LokalMusic._Code.Models.Products
{
    public class Artist
    {
        public Artist()
        {
        }

        public Artist(int artistId, string artistName, string location, string bio, string email, string userName, DateTime dateRegistered, string profileImage)
        {
            ArtistId = artistId;
            ArtistName = artistName;
            Location = location;
            Bio = bio;
            Email = email;
            UserName = userName;
            DateRegistered = dateRegistered;
            ProfileImage = profileImage;
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