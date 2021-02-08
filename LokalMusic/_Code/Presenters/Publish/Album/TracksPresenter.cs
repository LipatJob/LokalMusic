using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Publish.Albums;
using LokalMusic._Code.Repositories.Publish.Albums;
using LokalMusic.Publish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Presenters.Publish.Albums
{
    public class TracksPresenter
    {
        private Tracks tracks;
        private TracksRepository tracksRepository;
        private int AlbumId;

        public TracksPresenter(Tracks tracks, TracksRepository tracksRepository)
        {
            this.tracks = tracks;
            this.tracksRepository = tracksRepository;
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
        }

        public TracksModel GetTracksModel()
        {
            return new TracksModel()
            {
                ArtistName = tracksRepository.GetArtistName(AuthenticationHelper.UserId),
                AlbumName = tracksRepository.GetAlbumName(AlbumId),
                TracksItems = tracksRepository.GetTracksItems(AlbumId)
            };
        }

        public bool ValidateMaxTrackCount()
        {
            return tracksRepository.ValidateMaxTrackCount(AlbumId);
        }
    }
}