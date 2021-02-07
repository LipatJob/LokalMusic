using LokalMusic._Code.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Publish
{
    public class AlbumsItem
    {
        public int AlbumId { get; set; }

        public string AlbumCoverLink { get; set; }

        public string AlbumName { get; set; }

        public string Status { get; set; }

        public DateTime DateAdded { get; set; }

        public int TrackCount { get; set; }

        public string Producer { get; set; }

        public int SalesCount { get; set; }

        public decimal Price { get; set; }

        public string TracksURL
        {
            get
            {
                return NavigationHelper.CreateAbsoluteUrl($"/Publish/Album/{AlbumId}");
            }
        }

        public string EditURL
        {
            get
            {
                return NavigationHelper.CreateAbsoluteUrl($"/Publish/Album/{AlbumId}/Edit");
            }
        }
    }
}