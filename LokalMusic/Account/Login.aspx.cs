using LokalMusic.Code.Presenters.Account;
using LokalMusic.Code.Repositories.Account;
using LokalMusic.Code.Views.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LokalMusic.Webforms.Account
{
    public partial class Login : System.Web.UI.Page, ILoginView
    {
        private LoginPresenter presenter;
        public Login()
        {
            presenter = new LoginPresenter(this, new LoginRepository());
        }

        public string email { get { return emailTxt.Text; } }
        public string password { get { return passwordTxt.Text; } }

        public void RedirectToHomePage()
        {
            Response.Redirect("~/");
        }

        public void ShowLoginErrorMessage()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            presenter.Login();
        }
    }
}