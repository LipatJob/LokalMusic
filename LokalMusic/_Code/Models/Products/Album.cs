using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Products
{
    public class Album
    {
        public Album()
        {

        }

        public Album(int albumId, int albumCoverId, string albumName, string description, DateTime dateReleased, int userId)
        {
            AlbumId = albumId;
            AlbumCoverId = albumCoverId;
            AlbumName = albumName;
            Description = description;
            DateReleased = dateReleased;
            UserId = userId;
        }

        public int AlbumId { get; set; }
        public int AlbumCoverId { get; set; }
        public string AlbumName { get; set; }
        public string Description { get; set; }
        public DateTime DateReleased { get; set; }
        public int UserId { get; set; }

        public List<Track> Tracks { get; set; }

        // FileInfo
    }
}