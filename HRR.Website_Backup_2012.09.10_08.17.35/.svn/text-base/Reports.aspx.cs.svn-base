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
                LoadReport();
            }
        }

        protected void RunClicked(object o, EventArgs e)
        {
            var r = new HRR.Web.Reporting.CommentsReport();
            r.ReportParameters["CommentType"].Value = ddlCommentType.SelectedValue;
            r.ReportParameters["EnteredFor"].Value = ddlEnteredFor.SelectedValue;
            r.ReportParameters["EnteredBy"].Value = ddlEnteredBy.SelectedValue;
            r.ReportParameters["CategoryID"].Value = ddlCommentCategory.SelectedValue;
            r.ReportParameters["AccountID"].Value = SecurityContextManager.Current.CurrentAccount.ID;
            ReportViewer1.Report = r;
        }

        private void LoadReport()
        {
            if (HttpContext.Current.Request.Url.Segments.Length > 2)
            {
                switch (HttpContext.Current.Request.Url.Segments[2])
                {
                    case "Review/":
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
    }
}