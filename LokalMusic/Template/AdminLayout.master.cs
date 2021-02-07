using LokalMusic._Code.Helpers;
using System;

namespace LokalMusic.Template
{
    public partial class AdminLayout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(BackendAuthenticationHelper.LoggedIn == false)
            {

                NavigationHelper.Redirect("~/Admin/Login");
            }
            else if(BackendAuthenticationHelper.UserType != BackendAuthenticationHelper.ADMIN_USER_TYPE)
            {
                Response.Redirect("~");
            }
        }
    }
}