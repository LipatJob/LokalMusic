using System;
using System.Collections.Generic;

namespace LokalMusic._Code.Models.Fan
{
    public class CollectionModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string ProfileImage { get; set; }
        public DateTime DateRegistered { get; set; }
        public IEnumerable<CollectionItem> Collection { get; set; }
    }
}