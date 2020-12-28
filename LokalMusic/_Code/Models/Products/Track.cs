using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Products
{
    public class Track
    {
        public Track()
        {

        }

        public Track(int trackId, int albumId, int genreId, int trackFileId, int clipFileId, string trackName, TimeSpan trackDuration, string description, TimeSpan clipDuration)
        {
            TrackId = trackId;
            AlbumId = albumId;
            GenreId = genreId;
            TrackFileId = trackFileId;
            ClipFileId = clipFileId;
            TrackName = trackName;
            TrackDuration = trackDuration;
            Description = description;
            ClipDuration = clipDuration;
        }

        public int TrackId { get; set; }
        public int AlbumId { get; set; }
        public int GenreId { get; set; }
        public int TrackFileId { get; set; }
        public int ClipFileId { get; set; }

        public string TrackName { get; set; }
        public TimeSpan TrackDuration { get; set; }
        public string Description { get; set; }
        public TimeSpan ClipDuration { get; set; }

        // FileInfo
        // FileType?
    }
}