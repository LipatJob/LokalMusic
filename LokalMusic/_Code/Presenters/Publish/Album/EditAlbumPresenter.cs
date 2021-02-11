using LokalMusic._Code.Helpers;
using LokalMusic._Code.Repositories.Publish.Album;
using LokalMusic._Code.Views.Publish;

namespace LokalMusic._Code.Presenters.Publish.Album
{
    public class EditAlbumPresenter
    {
        private EditAlbumRepository editAlbumRepository;
        private IEditAlbumViewModel viewModel;
        private int AlbumId => int.Parse((string)NavigationHelper.GetRouteValue("AlbumId"));

        public EditAlbumPresenter(IEditAlbumViewModel viewModel, EditAlbumRepository editAlbumRepository)
        {
            this.viewModel = viewModel;
            this.editAlbumRepository = editAlbumRepository;
        }

        public void PageLoad()
        {
            if (AuthenticationHelper.LoggedIn == false)
            {
                NavigationHelper.Redirect("~/Account/Login");
            }
            else if (AuthenticationHelper.UserType != AuthenticationHelper.ARTIST_USER_TYPE)
            {
                NavigationHelper.Redirect("~");
            }

            editAlbumRepository.GetArtistName(AuthenticationHelper.UserId, viewModel);
            editAlbumRepository.GetAlbumDetails(viewModel, AlbumId);
        }

        public bool GetAlbumHasTrack()
        {
            return editAlbumRepository.GetAlbumHasTrack(AlbumId);
        }

        public void EditAlbum()
        {
            editAlbumRepository.EditAlbum(viewModel, AlbumId, viewModel.UploadedAlbumCover);
        }
        
        public void WithdrawAlbum()
        {
            editAlbumRepository.WithdrawAlbum(AlbumId);
        }

        public string GetAlbumStatus()
        {
            return editAlbumRepository.GetAlbumStatus(AlbumId);
        }

        public void UnpublishAlbum()
        {
            editAlbumRepository.UnpublishAlbum(AlbumId);
        }

        public void PublishAlbum()
        {
            editAlbumRepository.PublishAlbum(AlbumId);
        }
    }
}