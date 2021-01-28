using LokalMusic._Code.Helpers;
using LokalMusic._Code.Repositories.Publish.Album;
using LokalMusic._Code.Views.Publish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Presenters.Publish.Album
{
    public class EditAlbumPresenter
    {
        private EditAlbumRepository editAlbumRepository;
        private IEditAlbumViewModel viewModel;
        private int AlbumId;

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

            AlbumId = int.Parse((string)NavigationHelper.GetRouteValue("AlbumId"));
            editAlbumRepository.GetArtistName(AuthenticationHelper.UserId, viewModel);
            LoadAlbumDetails();
        }

        public void LoadAlbumDetails()
        {
            editAlbumRepository.GetAlbumDetails(viewModel, AlbumId);
        }

        public void EditAlbum()
        {
            editAlbumRepository.EditAlbum(viewModel, AlbumId);
        }
        
        public void UnlistAlbum()
        {
            editAlbumRepository.UnlistAlbum(AlbumId);
        }
    }
}