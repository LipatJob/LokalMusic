using LokalMusic._Code.Models.Publish.Album.Track;
using System.Web;

namespace LokalMusic._Code.Views.Publish
{
    public interface IAddTrackViewModel : IAddTrackModel
    {
        HttpPostedFile UploadedTrackFile { get; }

        HttpPostedFile UploadedClipFile { get; }
    }

}