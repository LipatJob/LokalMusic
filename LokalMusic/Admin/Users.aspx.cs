using LokalMusic._Code.Models.Admin;
using LokalMusic._Code.Presenters.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LokalMusic.Admin
{
    public partial class Users : System.Web.UI.Page
    {
        private UsersPresenter presenter;
        public Users()
        {
            this.presenter = new UsersPresenter(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [WebMethod]
        public static IList<UsersItem> GetUsers()
        {
            return UsersPresenter.GetUsers();
        }

        [WebMethod]
        public static bool DeactivateUser(int userId)
        {
            UsersPresenter.DeactivateUser(userId);
            return true;
        }

        [WebMethod]
        public static bool ReactivateUser(int userId)
        {
            UsersPresenter.ReactivateUser(userId);
            return true;
        }
    }
}