﻿using LokalMusic._Code.Helpers;
using LokalMusic._Code.Repositories.Publish.Album.Track;
using LokalMusic._Code.Views.Publish;

namespace LokalMusic._Code.Presenters.Publish.Album.Track
{
    public class EditTrackPresenter
    {
        private EditTrackRepository editTrackRepository;
        private IEditTrackViewModel viewModel;
        private int AlbumId => int.Parse((string)NavigationHelper.GetRouteValue("AlbumId"));
        private int TrackId => int.Parse((string)NavigationHelper.GetRouteValue("TrackId"));

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

            editTrackRepository.GetArtistName(AuthenticationHelper.UserId, viewModel);
            editTrackRepository.GetAlbumName(AlbumId, viewModel);

            LoadTrackDetails();
        }

        public void LoadTrackDetails()
        {
            editTrackRepository.GetTrackDetails(viewModel, TrackId);
        }

        public bool GetAlbumIsPublished()
        {
            return editTrackRepository.GetAlbumIsPublished(AlbumId);
        }

        public void EditTrack()
        {
            editTrackRepository.EditTrack(viewModel, TrackId, viewModel.UploadedTrackFile, viewModel.UploadedClipFile);
        }

        public void WithdrawTrack()
        {
            editTrackRepository.WithdrawTrack(TrackId);
        }

        public string GetTrackStatus()
        {
            return editTrackRepository.GetTrackStatus(TrackId);
        }

        public void UnpublishTrack()
        {
            editTrackRepository.UnpublishTrack(TrackId);
        }

        public void PublishTrack()
        {
            editTrackRepository.PublishTrack(TrackId);
        }
    }
}