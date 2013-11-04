using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.WebHost;
using System.Web.SessionState;
using System.Web;
using System.Web.Routing;

namespace HRR.Web.Routing
{
    public class HRRWebAPIRouteHandler : HttpControllerRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new HRRWebAPIHandler(requestContext.RouteData);
        }
    }
}
