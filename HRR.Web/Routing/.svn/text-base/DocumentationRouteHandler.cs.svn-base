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
using System.Web.SessionState;

namespace HRR.Web.Routing
{
    public class DocumentationRouteHandler : IRouteHandler, IRequiresSessionState
    {
        public string VirtualPath { get; set; }

        public DocumentationRouteHandler(string virtualPath)
        {
            this.VirtualPath = virtualPath;
        }

        #region IRouteHandler Members

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            HttpPageHelper.CurrentItem = null;
            //var p = new HRR.Core.Domain.Page();
            //if (HttpPageHelper.CurrentUser == null)
            //    p = new PageServices().GetByNameAccessLevel(VirtualPath, 0, Convert.ToInt16(ConfigurationManager.AppSettings["APPLICATIONID"]));
            //else
            //    p = new PageServices().GetByNameAccessLevel(VirtualPath, HttpPageHelper.CurrentUser.AccessLevel, Convert.ToInt16(ConfigurationManager.AppSettings["APPLICATIONID"]));
            //HttpPageHelper.CurrentPage = p
            string name = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["name"]);
            var d = new DocumentationServices().GetByName(name.Replace("-", " "));
            if (d != null)
                HttpPageHelper.CurrentDocumentation = d;
            //var item = new Item();
            //item.Description = p.Name;
            //item.Name = p.Name;
            //item.SEOTitle = p.SEOTitle;
            //item.ItemReference = item;
            //HttpPageHelper.CurrentItem = item;

            HRRBasePage page;
            if (!string.IsNullOrEmpty(name))
            {
                page = (HRRBasePage)BuildManager.CreateInstanceFromVirtualPath(ResourceStrings.Page_Documentation, typeof(System.Web.UI.Page));
            }
            else
            {
                page = null;
            }

            HttpPageHelper.IsValidRequest = true;
            return page;
        }

        #endregion
    }
}
