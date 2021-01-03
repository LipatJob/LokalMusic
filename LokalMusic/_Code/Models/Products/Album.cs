using System;
using System.Collections.Generic;

namespace LokalMusic._Code.Models.Products
{
    public class Album
    {
        public Album()
        {
        }

        public Album(int albumId, int albumCoverId, string albumName, string description, DateTime dateReleased, int userId, double price)
        {
            AlbumId = albumId;
            AlbumCoverId = albumCoverId;
            AlbumName = albumName;
            Description = description;
            DateReleased = dateReleased;
            UserId = userId;
            Price = price;
        }

        public int AlbumId { get; set; }
        public int AlbumCoverId { get; set; }
        public string AlbumName { get; set; }
        public string Description { get; set; }
        public DateTime DateReleased { get; set; }
        public int UserId { get; set; }

        public double Price { get; set; }

        public List<Track> Tracks { get; set; }

        // FileInfo
    }
}