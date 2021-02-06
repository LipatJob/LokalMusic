using System;

namespace LokalMusic._Code.Models.Publish.Album
{
    public interface IAddAlbumModel
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