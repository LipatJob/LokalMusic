using LokalMusic._Code.Helpers;
using System;

namespace LokalMusic.Template
{
    public partial class FinanceLayout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (BackendAuthenticationHelper.LoggedIn == false)
            {
                NavigationHelper.RedirectReturnAddress("~/Admin/Login");
            }
            else if (BackendAuthenticationHelper.UserType != BackendAuthenticationHelper.FINANCE_USER_TYPE)
            {
                Response.Redirect("~");
            }
        }
    }
}