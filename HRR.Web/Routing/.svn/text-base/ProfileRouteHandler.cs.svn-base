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
    public class ProfileRouteHandler: IRouteHandler, IRequiresSessionState
    {
        public string VirtualPath { get; set; }

        public ProfileRouteHandler(string virtualPath)
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
            string email = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["email"]);
            string action = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["action"]);
            var p = new PersonServices().GetByEmail(email);
            if (p != null)
            {
                HttpPageHelper.CurrentProfile = p;
            }

            //var item = new Item();
            //item.Description = p.Name;
            //item.Name = p.Name;
            //item.SEOTitle = p.SEOTitle;
            //item.ItemReference = item;
            //HttpPageHelper.CurrentItem = item;

            HRRBasePage page;
            if (!string.IsNullOrEmpty(action) && action.Equals("Edit"))
            {
                page = (HRRBasePage)BuildManager.CreateInstanceFromVirtualPath(ResourceStrings.Page_Profile_Edit, typeof(System.Web.UI.Page));
            }
            else
            {
                page = (HRRBasePage)BuildManager.CreateInstanceFromVirtualPath(ResourceStrings.Page_Profile_ReadOnly, typeof(System.Web.UI.Page));
            }

            HttpPageHelper.IsValidRequest = true;
            return page;
        }

        #endregion
    }
}
