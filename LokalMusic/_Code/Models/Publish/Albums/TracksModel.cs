using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Publish.Albums
{
    public class TracksModel
    {
        public string ArtistName { get; set; }

        public string AlbumName { get; set; }

        public IList<TracksItem> TracksItems { get; set; }
    }
}