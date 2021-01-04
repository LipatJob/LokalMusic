using System;

namespace LokalMusic._Code.Models.Store
{
    public class AlbumSummary
    {
        public AlbumSummary(int albumId, int artistId, string albumName, decimal price, string producerName, string albumCover, string artistName, DateTime dateReleased)
        {
            AlbumId = albumId;
            ArtistId = artistId;
            AlbumName = albumName;
            Price = price;
            ProducerName = producerName;
            AlbumCover = albumCover;
            ArtistName = artistName;
            DateReleased = dateReleased;
        }

        public int AlbumId { get; set; }
        public int ArtistId { get; set; }

        public string AlbumName { get; set; }
        public Decimal Price { get; set; }
        public string ProducerName { get; set; }
        public string AlbumCover { get; set; }

        public string ArtistName { get; set; }

        public DateTime DateReleased { get; set; }

        // processed in presenter
        public string Genre { get; set; }

        // processed in presenter, not in repository
        public int TrackCount { get; set; }
        public double TrackMinutes { get; set; }

    }
}