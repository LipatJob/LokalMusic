using LokalMusic._Code.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LokalMusic.Template
{
    public partial class AdminLayout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(AuthenticationHelper.LoggedIn == false)
            {
                Response.Redirect("~/Account/Login");
            }
            else if(AuthenticationHelper.UserType != AuthenticationHelper.ADMIN_USER_TYPE)
            {
                Response.Redirect("~");
            }
        }
    }
}