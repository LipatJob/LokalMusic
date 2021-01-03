using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Store
{
    public class ArtistSummary
    {
        public ArtistSummary(int artistId, string artistName, string bio, DateTime dateJoined, string artistProfileImage)
        {
            ArtistId = artistId;
            ArtistName = artistName;
            Bio = bio;
            DateJoined = dateJoined;
            ArtistProfileImage = artistProfileImage;
        }

        public int ArtistId { get; set; }

        public string ArtistName { get; set; }
        //public string Location { get; set; }
        public string Bio { get; set; }

        public DateTime DateJoined { get; set; }

        public string ArtistProfileImage { get; set; }

        // Processed in presenter
        public List<string> Genres { get; set; }

        // Processed in presenter
        public int AlbumCount { get; set; }
        public int TrackTotalCount { get; set; }


    }
}