using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Publish.Album
{
    public interface AddAlbumModel
    {
        string ArtistName { get; set; }

        string AlbumName { get; }

        string Description { get; }

        DateTime DateReleased { get; }

        string Producer { get; }

        decimal Price { get; }

        string AlbumCover { get; set; }
    }
}