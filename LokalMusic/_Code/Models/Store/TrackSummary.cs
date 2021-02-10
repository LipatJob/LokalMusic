using System;

namespace LokalMusic._Code.Models.Store
{
    public class TrackSummary
    {
        public TrackSummary() { }

        public TrackSummary(int trackId, int albumId, int artistId, string trackName, decimal price, DateTime dateAdded, string albumName, string artistName, string genre, string audioClip, TimeSpan audioClipDuration, TimeSpan audioDuration, string albumCover)
        {
            TrackId = trackId;
            AlbumId = albumId;
            ArtistId = artistId;
            TrackName = trackName;
            Price = price;
            DateAdded = dateAdded;
            AlbumName = albumName;
            ArtistName = artistName;
            Genre = genre;
            AudioClip = audioClip;
            AudioClipDuration = audioClipDuration;
            AudioDuration = audioDuration;
            AlbumCover = albumCover;
        }

        public int TrackId { get; set; }
        public int AlbumId { get; set; }
        public int ArtistId { get; set; }

        public string TrackName { get; set; }
        public Decimal Price { get; set; }
        public DateTime DateAdded { get; set; }
        public string AlbumName { get; set; }
        public string ArtistName { get; set; }

        public string Genre { get; set; }

        public string AudioClip { get; set; }
        public TimeSpan AudioClipDuration { get; set; }
        public TimeSpan AudioDuration { get; set; }

        public string AlbumCover { get; set; }

        public string DetailsUrl { 
            get { 
                return $"~/Store/" + this.ArtistId + "/" + this.AlbumId + "/" + this.TrackId;
            } 
        }

    }
}