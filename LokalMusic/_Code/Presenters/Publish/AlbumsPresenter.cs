using LokalMusic._Code.Models.Publish;
using LokalMusic._Code.Repositories.Publish;
using LokalMusic.Publish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Presenters
{
    public class AlbumsPresenter
    {
        private Albums albums;
        private AlbumsRepository repository;

        public AlbumsPresenter(Albums albums, AlbumsRepository repository)
        {
            this.albums = albums;
            this.repository = repository;
        }

        public AlbumsModel GetAlbumsModel()
        {
            var items = new List<AlbumsItem>();
            items.Add(new AlbumsItem()
            {
                AlbumCoverLink = @"~\Content\Images\default_cover.jpg",
                AlbumName = "Test Album",
                DateAdded = DateTime.Now,
                TrackCount = 9,
                Producer = "Test Producer",
                SalesCount = 12,
                Price = 100.00m,
                TracksURL = "",
                EditURL = ""
            });

            return new AlbumsModel()
            {
                ArtistName = "Job Lipat",
                AlbumsItems = items
            };
        }
    }
}