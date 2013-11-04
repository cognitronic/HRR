using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRR.Core.Domain;
using HRR.Core.Security;
using HRR.Services;
using HRR.Web.Bases;
using IdeaSeed.Core;
using HRR.Core;

namespace HRR.Website
{
    public partial class Error : HRRBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (SecurityContextManager.Current == null)
                {
                    Response.Redirect("/Login");
                }
                else
                {
                    lblMessage.Text = "An unexpected error has occured and our staff has been notified.  We're sorry for the inconvienence.";
                }
            }
        }
    }
}