using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Fan
{
    public class CollectionModel
    {
        public string Username { get; set; }
        public string ProfileImage { get; set; }
        public DateTime DateRegistered { get; set; }
        public IEnumerable<CollectionItem> Collection { get; set; }
    }
}