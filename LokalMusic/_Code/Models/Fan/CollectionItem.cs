using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Fan
{
    public class CollectionItem
    {
        public string CoverLink { get; set; }
        public string ProductName { get; set; }
        public string ArtistName { get; set; }
        public string ProductType { get; set; }
        public int ArtistId { get; set; }
        public int TrackId { get; set; }
        public int AlbumId { get; set; }

        public string GetUrl 
        { 
            get 
            {
                if (ProductType == "ALBUM")
                {
                    return $"~/Store/{ArtistId}/{AlbumId}";
                }
                else
                {
                    return $"~/Store/{ArtistId}/{AlbumId}/{TrackId}";
                }
            } 
        }
    }
}