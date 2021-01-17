﻿using LokalMusic._Code.Helpers;
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
            return new AlbumsModel()
            {
                ArtistName = repository.GetArtistName(AuthenticationHelper.UserId),
                AlbumsItems = repository.GetAlbumsItems(AuthenticationHelper.UserId)
            };
        }
    }
}