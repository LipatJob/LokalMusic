using System;

namespace LokalMusic._Code.Models.Products
{
    public class Track
    {
        public Track()
        {
        }

        public Track(int trackId, string trackName, string description, TimeSpan trackDuration, TimeSpan clipDuration, DateTime dateAdded, DateTime dateReleased, decimal price, string producerName, string clipFileAddress, int artistId, string artistName, int albumId, string genre, string albumName)
        {
            TrackId = trackId;
            TrackName = trackName;
            Description = description;
            TrackDuration = trackDuration;
            ClipDuration = clipDuration;
            DateAdded = dateAdded;
            DateReleased = dateReleased;
            Price = price;
            ProducerName = producerName;
            ClipFileAddress = clipFileAddress;
            ArtistId = artistId;
            ArtistName = artistName;
            AlbumId = albumId;
            Genre = genre;
            AlbumName = albumName;
        }

        public int TrackId { get; set; }
        public string TrackName { get; set; }
        public string Description { get; set; }
        public TimeSpan TrackDuration { get; set; }
        public TimeSpan ClipDuration { get; set; }
        public DateTime DateAdded { get; set; } //Date track was added
        public Decimal Price { get; set; }
        public string ProducerName { get; set; }

        public string AlbumName { get; set; }
        public DateTime DateReleased { get; set; }// Date its album was released

        public string ClipFileAddress { get; set; }

        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public int AlbumId { get; set; }
        public string Genre { get; set; }
    }
}