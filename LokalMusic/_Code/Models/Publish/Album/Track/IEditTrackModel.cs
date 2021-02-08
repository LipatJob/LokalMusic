using System;

namespace LokalMusic._Code.Models.Publish.Album.Track
{
    public interface IEditTrackModel
    {
        string ArtistName { get; set; }

        string AlbumName { get; set; }

        string TrackName { get; set; }

        string Genre { get; set; }

        string Description { get; set; }

        decimal Price { get; set; }

        string TrackFile { get; set; }

        TimeSpan TrackFileDuration { get; set; }

        string ClipFile { get; set; }

        TimeSpan ClipFileDuration { get; set; }

        bool TrackIsUpdated { get; set; }

        bool ClipIsUpdated { get; set; }

        string Status { get; set; }
    }
}