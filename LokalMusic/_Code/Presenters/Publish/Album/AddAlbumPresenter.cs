﻿using LokalMusic._Code.Helpers;
using LokalMusic._Code.Repositories.Publish.Album;
using LokalMusic._Code.Views.Publish;

namespace LokalMusic._Code.Presenters.Publish.Album
{
    public class AddAlbumPresenter
    {
        private AddAlbumRepository addAlbumRepository;
        private IAddAlbumViewModel viewModel;

        public AddAlbumPresenter(IAddAlbumViewModel viewModel, AddAlbumRepository addAlbumRepository)
        {
            this.viewModel = viewModel;
            this.addAlbumRepository = addAlbumRepository;
        }

        public void PageLoad()
        {
            if (AuthenticationHelper.LoggedIn == false)
            {
                NavigationHelper.RedirectReturnAddress("~/Account/Login");
            }
            else if (AuthenticationHelper.UserType != AuthenticationHelper.ARTIST_USER_TYPE)
            {
                NavigationHelper.Redirect("~");
            }

            addAlbumRepository.GetArtistName(AuthenticationHelper.UserId, viewModel);
        }

        public int AddAlbum()
        {
            return addAlbumRepository.AddAlbum(viewModel, AuthenticationHelper.UserId, viewModel.UploadedAlbumCover);
        }
    }
}