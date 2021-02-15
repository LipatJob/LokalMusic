using LokalMusic._Code.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LokalMusic
{
    public partial class ErrorPage : System.Web.UI.Page
    {

        protected string error;
        protected string description;

        protected void Page_Load(object sender, EventArgs e)
        {
            error = (string)NavigationHelper.GetRouteValue("msg");
            description = (string)NavigationHelper.GetRouteValue("handler");

            if (error == null || error == "") error = "Error";
            if (description == null || description == "") description = GetMessage(error);

            errorTitle.InnerHtml = error;
            errorText.InnerHtml = description;
        }

        protected string GetMessage(string error)
        {
            if (error.ToLower() == "database")
                return "Conenction error to database server. Please try again.";
            else
                return "Unexpected error encountered. Please try again";
        }
    }
}