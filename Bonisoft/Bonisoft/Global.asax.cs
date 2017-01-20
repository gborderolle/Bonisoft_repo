using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Bonisoft
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

            // Get the exception object.
            Exception exc = Server.GetLastError();

            Server.Transfer("/Pages/ErrorPage.aspx");

            System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(exc, true);

            // Log the exception and notify system operators
            Global_Objects.Logs.AddErrorLog("Excepcion no controlada. ERROR:", trace.GetFrame(0).GetMethod().ReflectedType.FullName, trace.GetFrame(0).GetMethod().Name, exc.Message);

            // Clear the error from the server
            Server.ClearError();
        }
    }
}