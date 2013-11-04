using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.WebHost;
using System.Web.SessionState;
using System.Web.Routing;

namespace HRR.Web.Routing
{
    public class HRRWebAPIHandler : HttpControllerHandler, IRequiresSessionState
    {
        public HRRWebAPIHandler(RouteData routeData)
            : base(routeData)
        {
        }
    }
}
