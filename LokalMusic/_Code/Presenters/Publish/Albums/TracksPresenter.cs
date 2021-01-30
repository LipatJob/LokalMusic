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
        }

        public TracksModel GetTracksModel()
        {
            var Items = new List<TracksItem>();
            Items.Add(new TracksItem()
            {
                TrackCoverLink = @"~\Content\Images\default_cover.jpg",
                TrackName = "Test Track 10",
                DateAdded = DateTime.Now,
                Genre = "Pop",
                Duration = new TimeSpan(0, 2, 45),
                SalesCount = 9,
                Price = 199,
                EditURL = "~"
            });

            return new TracksModel()
            {
                ArtistName = "Job Lipat",
                AlbumName = "Test Album 10",
                TracksItems = Items
            };
        }
    }
}