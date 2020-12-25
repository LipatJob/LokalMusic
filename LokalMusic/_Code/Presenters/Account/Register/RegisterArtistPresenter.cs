using LokalMusic._Code.Models.Account.Register;
using LokalMusic._Code.Repositories.Account.Register;
using LokalMusic._Code.Views.Account.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Presenters.Account.Register
{
    public class RegisterArtistPresenter
    {
        private RegisterArtistRepository repository;
        private IRegisterArtistViewModel view;

        public RegisterArtistPresenter(IRegisterArtistViewModel view, RegisterArtistRepository repository)
        {
            this.view = view;
            this.repository = repository;
        }

        public void Register()
        {
        }
    }
}