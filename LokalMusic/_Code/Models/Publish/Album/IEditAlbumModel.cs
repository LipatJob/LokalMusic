﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Publish.Album
{
    public interface IEditAlbumModel
    {
        string ArtistName { get; set; }

        string AlbumName { get; set; }

        string Description { get; set; }

        DateTime DateReleased { get; set; }

        string Producer { get; set; }

        decimal Price { get; set; }

        string AlbumCover { get; set; }
    }
}