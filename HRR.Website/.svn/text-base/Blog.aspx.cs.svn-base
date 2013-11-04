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
using HRR.Web.Utils;
using System.Configuration;
using HRR.Core;
using System.Text;
using Telerik.Web.UI;

namespace HRR.Website
{
    public partial class Blog : HRRBasePage
    {
        private HRR.Core.Domain.Blog CurrentBlog
        {
            get
            {
                var c = new BlogServices().GetByID(Convert.ToInt32(HttpContext.Current.Request.Url.Segments[HttpContext.Current.Request.Url.Segments.Count() - 1]));
                if (c != null)
                    return c;
                return null;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            AuthorizeAccount(CurrentBlog.EnteredByRef.AccountID);
            if (!IsPostBack)
            {
                LoadBlog();
                LoadResponses();
            }
        }

        private void LoadBlog()
        {
            if (CurrentBlog != null)
            {
                lblTitle.Text = CurrentBlog.Title;
                lblCategory.Text = CurrentBlog.Category.Name;
                lbAuthor.Text = CurrentBlog.EnteredByRef.Name;
                lblDate.Text = CurrentBlog.StartDate.ToString("MMM dd, yyyy");
                lblContent.Text = CurrentBlog.BlogContent;
                lblResponses.Text = CurrentBlog.Responses.Count() + " Comments";
            }
        }

        private void LoadResponses()
        {
            var list = CurrentBlog.Responses.OrderByDescending(o => o.DateCreated);
            if (list.Count() > 0)
            {
                dlResponses.DataSource = list;
                dlResponses.DataBind();
            }
        }

        protected void AuthorClicked(object o, EventArgs e)
        {
            Response.Redirect("/People/" + CurrentBlog.EnteredByRef.Email);
        }

        protected void PostClicked(object o, EventArgs e)
        {
            var p = new BlogResponse();
            p.BlogID = CurrentBlog.ID;
            p.Comment = tbBlogComment.Text;
            p.DateCreated = DateTime.Now;
            p.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
            p.FlaggedAsInappropriate = false;
            new BlogResponseServices().Save(p);
            tbBlogComment.Text = "";
            IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();
            LoadResponses();
        }
    }
}