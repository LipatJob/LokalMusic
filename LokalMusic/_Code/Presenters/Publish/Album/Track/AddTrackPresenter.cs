﻿using LokalMusic._Code.Helpers;
using LokalMusic._Code.Repositories.Publish.Album.Track;
using LokalMusic._Code.Views.Publish;

namespace LokalMusic._Code.Presenters.Publish.Album.Track
{
    public class AddTrackPresenter
    {
        private AddTrackRepository addTrackRepository;
        private IAddTrackViewModel viewModel;
        private int AlbumId;

        public AddTrackPresenter(IAddTrackViewModel viewModel, AddTrackRepository addTrackRepository)
        {
            this.viewModel = viewModel;
            this.addTrackRepository = addTrackRepository;
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

            ProductHelper.CheckAlbumOwnership();
            AlbumId = int.Parse((string)NavigationHelper.GetRouteValue("AlbumId"));

            addTrackRepository.GetArtistName(AuthenticationHelper.UserId, viewModel);
            addTrackRepository.GetAlbumName(AlbumId, viewModel);
        }

        public void GetGenreList()
        {
            addTrackRepository.GetGenreList(viewModel);
        }

        public void AddTrack()
        {
            addTrackRepository.AddTrack(viewModel, AlbumId, viewModel.UploadedTrackFile, viewModel.UploadedClipFile);
        }

        public bool ValidateMaxTrackCount()
        {
            return addTrackRepository.ValidateMaxTrackCount(AlbumId);
        }
    }
}