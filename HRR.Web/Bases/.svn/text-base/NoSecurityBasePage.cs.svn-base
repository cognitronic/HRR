using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using IdeaSeed.Web;
using IdeaSeed.Core;
using IdeaSeed.Core.Utils;
using HRR.Core;
using HRR.Core.Security;
using HRR.Core.Domain;
using HRR.Services;
using Telerik.Web.UI;
using HRR.Web.Security;
using HRR.Web.Utils;

namespace HRR.Web.Bases
{
    public class NoSecurityBasePage : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (!Request.IsLocal && !Request.IsSecureConnection)
                Response.Redirect(Request.Url.ToString().Replace("http:", "https:"));
            InitializeSession();
            InitializeSecurityContextManagerValues();
        }

        #region Methods
        public void InitializeSession()
        {
            if (SessionManager.Current == null)
            {
                SessionManager.Current = new WebSessionProvider();
            }
            if (SecurityContextManager.Current == null)
            {
                SecurityContextManager.Current = new WebSecurityContext();
            }
        }

        public void InitializeSecurityContextManagerValues()
        {
            //if (HttpPageHelper.CurrentPage != null)
            //{
            //    if (SecurityContextManager.Current != null)
            //    {
            //        //SecurityContextManager
            //        //    .Current
            //        //    .CurrentPage = HttpPageHelper.CurrentPage;
            //        if (HttpPageHelper.CurrentItem != null)
            //            SessionManager.Current[ResourceStrings.Session_CurrentItem] = HttpPageHelper.CurrentItem;
            //        if (HttpPageHelper.CurrentUser != null)
            //            SecurityContextManager
            //                .Current
            //                .CurrentUser = HttpPageHelper.CurrentUser;
            //        else
            //            SecurityContextManager
            //                .Current
            //                .CurrentUser = null;
            //    }
            //}
        }
        #endregion
    }
}
