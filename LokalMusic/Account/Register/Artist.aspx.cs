using LokalMusic._Code.Presenters.Account.Register;
using LokalMusic._Code.Repositories.Account.Register;
using LokalMusic._Code.Views.Account.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LokalMusic.Account.Register
{
    public partial class Artist : System.Web.UI.Page, IRegisterArtistViewModel
    {
        private RegisterArtistPresenter presenter;
        public Artist()
        {
            presenter = new RegisterArtistPresenter(this, new RegisterArtistRepository());
        }
        public string Email { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Username { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Password { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ConfirmPassword { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}