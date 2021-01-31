using LokalMusic._Code.Models.Publish.Album;
using System.Web;

namespace LokalMusic._Code.Views.Publish
{
    public interface IEditAlbumViewModel : IEditAlbumModel
    {
        HttpPostedFile UploadedAlbumCover { get; }
    }
}