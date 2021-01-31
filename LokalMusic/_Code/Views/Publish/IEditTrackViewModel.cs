using LokalMusic._Code.Models.Publish.Album.Track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Views.Publish
{
    public interface IEditTrackViewModel : IEditTrackModel
    {
        HttpPostedFile UploadedTrackFile { get; }

        HttpPostedFile UploadedClipFile { get; }
    }
}