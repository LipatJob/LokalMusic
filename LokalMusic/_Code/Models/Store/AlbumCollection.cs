using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Store
{
    public class AlbumCollection
    {
        public AlbumCollection() { }

        public AlbumCollection(int albumId, string albumName, string description, DateTime dateReleased, decimal price, string producerName, DateTime dateAdded, int artistId, string artistName, string artistLocation, string bio, string fileName)
        {
            AlbumId = albumId;
            AlbumName = albumName;
            Description = description;
            DateReleased = dateReleased;
            Price = price;
            ProducerName = producerName;
            DateAdded = dateAdded;
            ArtistId = artistId;
            ArtistName = artistName;
            ArtistLocation = artistLocation;
            Bio = bio;
            FileName = fileName;
        }

        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public string Description { get; set; }
        public DateTime DateReleased { get; set; }
        public Decimal Price { get; set; }
        public string ProducerName { get; set; }
        public DateTime DateAdded { get; set; }

        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string ArtistLocation { get; set; }
        public string Bio { get; set; }

        public string FileName { get; set; }

    }
}