using LokalMusic._Code.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Admin
{
    public class ProductItem
    {
        public int ProductId { get; set; }
        public int? AlbumId { get; internal set; }
        public string ProductName { get; set; }
        public string ArtistName { get; set; }
        public DateTime DateListed { get; set; }
        public string ProductType { get; set; }
        public string MarketPage {
            get
            {
                if(ProductType == "ALBUM")
                {
                    return NavigationHelper.CreateAbsoluteUrl($"/Store/{ProductId}");
                }
                return NavigationHelper.CreateAbsoluteUrl($"/Store/{AlbumId}/{ProductId}");
            }
        }
        public string ProductStatus { get; set; }
        public string FormattedDateListed => DateListed.ToShortDateString();

    }
}