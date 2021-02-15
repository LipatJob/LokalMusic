using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Fan
{
    public class PlaylistAlbum
    {

        public int AlbumId { get; set; }
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string AlbumName { get; set; }
        public string AlbumCover { get; set; }
        public List<PlaylistTrack> tracks { get; set; }

    }
}