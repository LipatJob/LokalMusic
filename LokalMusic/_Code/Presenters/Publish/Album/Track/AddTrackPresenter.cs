using LokalMusic._Code.Helpers;
using LokalMusic._Code.Repositories.Publish.Album.Track;
using LokalMusic._Code.Views.Publish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
                NavigationHelper.Redirect("~/Account/Login");
            }
            else if (AuthenticationHelper.UserType != AuthenticationHelper.ARTIST_USER_TYPE)
            {
                NavigationHelper.Redirect("~");
            }

            AlbumId = int.Parse((string)NavigationHelper.GetRouteValue("AlbumId"));

            addTrackRepository.GetArtistName(AuthenticationHelper.UserId, viewModel);
            addTrackRepository.GetAlbumName(AlbumId, viewModel);
        }

        public void AddTrack()
        {
            addTrackRepository.AddTrack(viewModel, AlbumId);
        }
    }
}