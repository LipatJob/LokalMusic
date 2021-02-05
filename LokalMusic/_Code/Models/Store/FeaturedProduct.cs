using LokalMusic._Code.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Store
{
    public class FeaturedProduct
    {
        public string ProductImage { get; set; }
        public int ArtistId { get; set; }
        public int ProductId { get; set; }
        public string MarketPage
        {
            get
            {
                return NavigationHelper.CreateAbsoluteUrl($"/Store/{ArtistId}/{ProductId}");

            }
        }
    }
}