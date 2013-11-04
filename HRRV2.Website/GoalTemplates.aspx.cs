using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using HRR.Core.Domain;
using HRR.Core.Security;
using HRR.Services;
using HRR.Web.Bases;
using IdeaSeed.Core;
using HRR.Core;
using System.Text;
using HRR.Web.Utils;
using System.Configuration;
using Telerik.Web.UI;

namespace HRRV2.Website
{
    public partial class GoalTemplates : HRRBasePage
    {
        public int CurrentPage
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_CurrentPage"];
                if (o == null)
                    return 0; // default page index of 0
                else
                    return (int)o;
            }

            set
            {
                this.ViewState["_CurrentPage"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTemplates();
            }
        }

        private void LoadTemplates()
        {
            PagedDataSource pd = new PagedDataSource();

            var list = new GoalServices().GetTemplates().OrderBy(o => o.DateCreated).ToList<Goal>();

            pd.DataSource = list;
            pd.AllowPaging = true;
            pd.PageSize = 50;
            pd.CurrentPageIndex = CurrentPage;
            lblCurrentPage.Text = "Page: "
                + (CurrentPage + 1).ToString()
                + " of "
                + pd.PageCount.ToString();
            cmdPrev.Enabled = !pd.IsFirstPage;
            cmdNext.Enabled = !pd.IsLastPage;

            dlPeople.DataSource = pd;
            dlPeople.DataBind();
        }

        protected void EditClicked(object o, EventArgs e)
        {
            Response.Redirect("/Goals/Templates/" + ((IdeaSeed.Web.UI.LinkButton)o).Attributes["itemid"]);
        }

        protected void PrevClicked(object sender, System.EventArgs e)
        {
            // Set viewstate variable to the previous page
            CurrentPage -= 1;

            // Reload control
            LoadTemplates();
        }

        protected void NextClicked(object sender, System.EventArgs e)
        {
            // Set viewstate variable to the next page
            CurrentPage += 1;

            // Reload control
            LoadTemplates();
        }
    }
}