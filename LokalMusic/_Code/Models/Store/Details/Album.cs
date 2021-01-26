using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Store.Details
{
    public class Album
    {
        public Album() { }
        public Album(int albumId, int artistId, string albumName, decimal price, string description, DateTime releaseDate, string albumCover, string artistName)
        {
            AlbumId = albumId;
            ArtistId = artistId;
            AlbumName = albumName;
            Price = price;
            Description = description;
            ReleaseDate = releaseDate;
            AlbumCover = albumCover;
            ArtistName = artistName;
        }

        public int AlbumId { get; set; }
        public int ArtistId { get; set; }

        public string AlbumName { get; set; }
        public Decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }

        public string AlbumCover { get; set; }

        public string ArtistName { get; set; }

        // processed in presenter
        public string Genres { get; set; }
        public int TrackCount { get; set; }
        public double MinuteCount { get; set; }

        public string AlbumArtistUrl
        {
            get
            {
                return $"~/Store/" + this.ArtistId;
            }
        }

        public string DetailsUrl
        {
            get
            {
                return $"~/Store/" + this.ArtistId + "/" + this.AlbumId;
            }
        }
    }
}