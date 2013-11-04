using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Configuration;
using System.Web.Compilation;
using System.Web.UI;
using System.Collections;
using HRR.Web.Utils;
using HRR.Services;
using HRR.Core.Domain;
using HRR.Core;
using HRR.Web.Bases;

namespace HRR.Web.Routing
{
    public class LoginRouteHandler : IRouteHandler
    {
        public string VirtualPath { get; set; }

        public LoginRouteHandler(string virtualPath)
        {
            this.VirtualPath = virtualPath;
        }

        #region IRouteHandler Members

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            NoSecurityBasePage page;

            page = (NoSecurityBasePage)BuildManager.CreateInstanceFromVirtualPath(VirtualPath, typeof(System.Web.UI.Page));

            HttpPageHelper.IsValidRequest = true;
            return page;
        }

        #endregion
    }
}
