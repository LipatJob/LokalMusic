using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Store.Details
{
    public class Track
    {
        public Track(int trackId, int albumId, int artistId, string trackName, decimal price, TimeSpan audioDuration, string audioAddress, DateTime dateAdded, string description, string albumName, string artistName, DateTime albumReleaseDate, string albumCover)
        {
            TrackId = trackId;
            AlbumId = albumId;
            ArtistId = artistId;
            TrackName = trackName;
            Price = price;
            AudioDuration = audioDuration;
            AudioAddress = audioAddress;
            DateAdded = dateAdded;
            Description = description;
            AlbumName = albumName;
            ArtistName = artistName;
            AlbumReleaseDate = albumReleaseDate;
            AlbumCover = albumCover;
        }

        public int TrackId { get; set; }
        public int AlbumId { get; set; }
        public int ArtistId { get; set; }

        public string TrackName { get; set; }
        public Decimal Price { get; set; }
        public TimeSpan AudioDuration { get; set; }
        public string AudioAddress { get; set; }
        public DateTime DateAdded { get; set; }

        public string Description { get; set; }

        public string AlbumName { get; set; }
        public string ArtistName { get; set; }
        public DateTime AlbumReleaseDate { get; set; }

        public string AlbumCover { get; set; }

        // processed in presenter
        public string Genre { get; set; }


    }
}