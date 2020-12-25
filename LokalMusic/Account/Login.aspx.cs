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
    public partial class Login : System.Web.UI.Page, ILoginViewModel
    {
        private LoginPresenter presenter;
        public Login()
        {
            presenter = new LoginPresenter(this, new LoginRepository());
        }

        public string Email { get { return EmailTxt.Text; } set { throw new NotImplementedException(); } }
        public string Password { get { return PasswordTxt.Text; } set { throw new NotImplementedException(); } }

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