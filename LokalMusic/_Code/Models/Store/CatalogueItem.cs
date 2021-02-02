using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Store
{
    public class CatalogueItem
    {
        public CatalogueItem()
        {
        }

        public CatalogueItem(int artistId, int albumId, int trackId, string imageCoverAddress, string productName, Decimal price, string productType, string artistName)
        {
            ArtistId = artistId;
            AlbumId = albumId;
            TrackId = trackId;
            ImageCoverAddress = imageCoverAddress;
            ProductName = productName;
            Price = price;
            ProductType = productType;
            ArtistName = artistName;
        }

        public int ArtistId { get; set; }
        public int AlbumId { get; set; }
        public int TrackId { get; set; }
        public string ImageCoverAddress { get; set; }
        public string ProductName { get; set; }
        public Decimal Price { get; set; }
        public string ProductType { get; set; }

        public string ArtistName { get; set; }

        public string DetailsUrl
        {
            get
            {
                if (ProductType.ToLower() == "album")
                    return $"~/Store/" + this.ArtistId + "/" + this.AlbumId;
                else
                    return $"~/Store/" + this.ArtistId + "/" + this.AlbumId + "/" + this.TrackId;
            }
        }

    }
}