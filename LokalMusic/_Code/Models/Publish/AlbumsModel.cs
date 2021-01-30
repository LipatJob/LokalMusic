using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Publish
{
    public class AlbumsModel
    {
        public string ArtistName { get; set; }

        public IList<AlbumsItem> AlbumsItems { get; set; }
    }
}