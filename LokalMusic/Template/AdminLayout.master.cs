using LokalMusic._Code.Helpers;
using System;

namespace LokalMusic.Template
{
    public partial class AdminLayout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(AuthenticationHelper.LoggedIn == false)
            {

                NavigationHelper.RedirectReturnAddress("~/Account/Login");
            }
            else if(AuthenticationHelper.UserType != AuthenticationHelper.ADMIN_USER_TYPE)
            {
                Response.Redirect("~");
            }
        }
    }
}