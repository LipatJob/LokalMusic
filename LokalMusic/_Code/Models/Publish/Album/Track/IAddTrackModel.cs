using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Publish.Album.Track
{
    public interface IAddTrackModel
    {
        string ArtistName { get; set; }

        string AlbumName { get; set; }

        string TrackName { get; }

        string Genre { get; }

        string Description { get; }

        decimal Price { get; }

        string TrackFile { get; set; }
        
        TimeSpan TrackFileDuration { get; set; }

        string ClipFile { get; set; }

        TimeSpan ClipFileDuration { get; set; }
    }
}