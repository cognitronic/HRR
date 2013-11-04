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
using System.Text;
using HRR.Web.Utils;
using System.Configuration;

namespace HRR.Website
{
    public partial class Reports : HRRBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divMessage.Visible = false;
                LoadReport();
            }
        }

        protected void RunClicked(object o, EventArgs e)
        {
            if (ddlTeams.SelectedIndex > 0)
            {
                divMessage.Visible = false;
                var r = new HRR.Web.Reporting.CommentsReport();
                r.ReportParameters["CommentType"].Value = ddlCommentType.SelectedValue;
                r.ReportParameters["EnteredFor"].Value = ddlEnteredFor.SelectedValue;
                r.ReportParameters["EnteredBy"].Value = ddlEnteredBy.SelectedValue;
                r.ReportParameters["CategoryID"].Value = ddlCommentCategory.SelectedValue;
                r.ReportParameters["TeamID"].Value = ddlTeams.SelectedValue;
                r.ReportParameters["AccountID"].Value = SecurityContextManager.Current.CurrentAccount.ID;
                ReportViewer1.Report = r;
            }
            else
            {
                divMessage.Visible = true;
                lblMessage.Text = "You must select a team before you can run the report.";
            }
        }

        private void LoadReport()
        {
            if (HttpContext.Current.Request.Url.Segments.Length > 2)
            {
                switch (HttpContext.Current.Request.Url.Segments[2])
                {
                    case "Reviews/":
                        var r = new HRR.Web.Reporting.Review();
                        r.ReportParameters["ReviewID"].Value = Convert.ToInt32(HttpContext.Current.Request.Url.Segments[3]);
                        ReportViewer1.Report = r;
                        divFilter.Visible = false;
                        divRunReport.Visible = false;
                        break;
                }
            }
            else
            {

                divFilter.Visible = true;
                divRunReport.Visible = true;
            }
        }

        protected void TeamSelectedIndexChanged(object o, EventArgs e)
        {
            if (ddlTeams.SelectedIndex > 0)
            {
                SecurityContextManager.Current.CurrentTeamID = Convert.ToInt16(ddlTeams.SelectedValue);
                ddlEnteredBy.LoadUsers();
                ddlEnteredFor.LoadUsers();
            }
            else
            {
                SecurityContextManager.Current.CurrentTeamID = null;
                ddlEnteredBy.LoadUsers();
                ddlEnteredFor.LoadUsers();
            }
        }
    }
}