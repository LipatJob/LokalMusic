using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace LokalMusic
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            RouteConfig.RegisterCustomRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
            // Exception Ex = Server.GetLastError();
            // Server.ClearError();
            // ExceptionLogging.LogErrorToEventViewer(Ex);
            // Server.Transfer("ErrorPage.aspx");

        }
    }
}