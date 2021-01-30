using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Publish
{
    public class SalesModel
    {
        public string ArtistName { get; set; }

        public IList<SalesItem> SalesItems { get; set; } 
    }
}