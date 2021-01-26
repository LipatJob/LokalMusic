using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Store.Details
{
    public class Artist
    {
        public Artist() { }
        public Artist(int artistId, string artistName, string bio, string location, DateTime dateJoined, string artistImage)
        {
            ArtistId = artistId;
            ArtistName = artistName;
            Bio = bio;
            Location = location;
            DateJoined = dateJoined;
            ArtistImage = artistImage;
        }

        public int ArtistId { get; set; }

        public string ArtistName { get; set; }
        public string Bio { get; set; }
        public string Location { get; set; }
        public DateTime DateJoined { get; set; }

        public string ArtistImage { get; set; }

        // processed in presenter
        public string Genres { get; set; }
        public int AlbumCount { get; set; }
        public int TrackCount { get; set; }

    }
}