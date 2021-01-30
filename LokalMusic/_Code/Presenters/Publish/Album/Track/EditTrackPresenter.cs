using LokalMusic._Code.Helpers;
using LokalMusic._Code.Repositories.Publish.Album.Track;
using LokalMusic._Code.Views.Publish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Presenters.Publish.Album.Track
{
    public class EditTrackPresenter
    {
        private EditTrackRepository editTrackRepository;
        private IEditTrackViewModel viewModel;
        private int AlbumId;
        private int TrackId;

        public EditTrackPresenter(IEditTrackViewModel viewModel, EditTrackRepository editTrackRepository)
        {
            this.viewModel = viewModel;
            this.editTrackRepository = editTrackRepository;
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
            TrackId = int.Parse((string)NavigationHelper.GetRouteValue("TrackId"));

            editTrackRepository.GetArtistName(AuthenticationHelper.UserId, viewModel);
            editTrackRepository.GetAlbumName(AlbumId, viewModel);

            LoadTrackDetails();
        }

        public void LoadTrackDetails()
        {
            editTrackRepository.GetTrackDetails(viewModel, TrackId);
        }

        public void EditTrack()
        {
            editTrackRepository.EditTrack(viewModel, TrackId);
        }

        public void UnlistTrack()
        {
            editTrackRepository.UnlistTrack(TrackId);
        }
    }
}