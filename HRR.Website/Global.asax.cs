using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using IdeaSeed.Core;
using HRR.Core.Domain;
using HRR.Web.Routing;
using System.Web.Routing;
using HRR.Core;
using HRR.Core.Security;
using HRR.Services;
using System.Configuration;
using System.Text;
using Couchbase;

namespace HRR.Website
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            RouteBuilder builder = new RouteBuilder(RouteTable.Routes);
            builder.Run();

            
        }

        void Application_End(object sender, EventArgs e)
        {
            

        }

        void Application_Error(object sender, EventArgs e)
        {
            

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
