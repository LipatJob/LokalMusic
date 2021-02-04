using LokalMusic._Code.Helpers;
using System;

namespace LokalMusic._Code.Models.Admin
{
    public class ProductItem
    {
        public int ArtistId { get; set; }
        public int ProductId { get; set; }
        public int? AlbumId { get; internal set; }
        public string ProductName { get; set; }
        public string ArtistName { get; set; }
        public DateTime DateListed { get; set; }
        public string ProductType { get; set; }

        public string MarketPage
        {
            get
            {
                if (ProductType.ToLower() == "album")
                {
                    return NavigationHelper.CreateAbsoluteUrl($"/Store/{ArtistId}/{ProductId}");
                }
                return NavigationHelper.CreateAbsoluteUrl($"/Store/{ArtistId}/{AlbumId}/{ProductId}");
            }
        }

        public string ProductStatus { get; set; }
        public string FormattedDateListed => DateListed.ToShortDateString();
    }
}