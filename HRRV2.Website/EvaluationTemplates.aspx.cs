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
using System.Collections.Specialized;
using HRR.Web.Bases;
using IdeaSeed.Core;
using HRR.Core;
using System.Text;
using HRR.Web.Utils;
using System.Configuration;
using Telerik.Web.UI;
using System.Net;

namespace HRRV2.Website
{
    public partial class EvaluationTemplates : HRRBasePage
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

        ICacheStorage _cache = new MemcacheCacheAdapter();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTemplates();
            }
        }

        protected void ItemDataBound(object o, RadListViewItemEventArgs e)
        { 
            
        }

        protected void EvaluationTemplateItemCommand(object o, RadListViewCommandEventArgs e)
        { 
            
        }

        protected void AddNewTemplateClicked(object o, EventArgs e)
        {
            
        }

        protected void EditTemplateClicked(object o, EventArgs e)
        {
            Response.Redirect(ResourceStrings.Page_Evaluation_Template_Edit + ((LinkButton)o).Attributes["itemid"]);
        }

        protected void DeleteTemplateClicked(object o, EventArgs e)
        { 
        
        }

        private void LoadTemplates()
        {
            PagedDataSource pd = new PagedDataSource();

            //string result = "";
            //using (var client = new WebClient())
            //{
            //    client.Headers[HttpRequestHeader.ContentType] = "application/json";
            //    client.Headers[HttpRequestHeader.Accept] = "application/json";
            //    result = client.DownloadString(ConfigurationManager.AppSettings["BASEURL"] + "/api/Evaluation/GetEvaluationTemplates?accountID=" + SecurityContextManager.Current.CurrentUser.AccountID.ToString());
                
            //}

            var list = new List<PerformanceEvaluationTemplate>();
            if (_cache.Retrieve<List<PerformanceEvaluationTemplate>>(SecurityContextManager.Current.CurrentUser.AccountID.ToString() + "_EvaluationTemplateList") == null)
            {

                list = new PerformanceEvaluationServices().GetTemplates(SecurityContextManager.Current.CurrentUser.AccountID).OrderBy(o => o.DateCreated).ToList<PerformanceEvaluationTemplate>();
                _cache.Store(SecurityContextManager
                     .Current
                     .CurrentUser.AccountID.ToString() + "_EvaluationTemplateList", list);
            }
            else
            {
                list = _cache.Retrieve<List<PerformanceEvaluationTemplate>>(SecurityContextManager
                    .Current
                    .CurrentUser.AccountID.ToString() + "_EvaluationTemplateList");
            }

            pd.DataSource = list;
            pd.AllowPaging = true;
            pd.PageSize = 20;
            pd.CurrentPageIndex = CurrentPage;
            lblCurrentPage.Text = "Page: "
                + (CurrentPage + 1).ToString()
                + " of "
                + pd.PageCount.ToString();
            cmdPrev.Enabled = !pd.IsFirstPage;
            cmdNext.Enabled = !pd.IsLastPage;

            dlEvaluationTemplates.DataSource = list;
            dlEvaluationTemplates.DataBind();
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