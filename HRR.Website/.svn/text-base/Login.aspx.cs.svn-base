using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using IdeaSeed.Core;
using HRR.Core.Domain;
using HRR.Core.Domain.Interfaces;
using HRR.Core.Security;
using HRR.Services;
using HRR.Core;
using HRR.Web.Bases;

namespace HRR.Website
{
    public partial class Login : NoSecurityBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "Login";
            tbUsername.Focus();
        }

        protected void LoginClicked(object o, EventArgs e)
        {
            string userName = tbUsername.Text;
            string password = tbPassword.Text;

            var response = new SecurityServices().AuthenticateUser(userName, password, "");
            if (response.IsAuthenticated)
            {
                if (Request.QueryString["redirect"] != null)
                {
                    Response.Redirect(Request.QueryString["redirect"]);
                }
                Response.Redirect(ResourceStrings.Page_Default);
            }
            else
            {
                lblLoginMessage.Visible = true;
                lblLoginMessage.Text = "Invalid username or password.<br/>Please try again.";
            }
        }

        protected void ForgotPasswordClicked(object o, EventArgs e)
        {
            Response.Redirect(ResourceStrings.Page_ForgotPassword);
        }
    }
}