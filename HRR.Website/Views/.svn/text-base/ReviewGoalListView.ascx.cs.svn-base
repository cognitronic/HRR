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
using System.Web.UI.HtmlControls;

namespace HRR.Website.Views
{
    public partial class ReviewGoalListView : System.Web.UI.UserControl
    {
        private HRR.Core.Domain.Review CurrentReview
        {
            get
            {
                if (!HttpContext.Current.Request.Url.PathAndQuery.Contains("New"))
                {
                    if (Session["CurrentReview"] == null)
                    {
                        Session["CurrentReview"] = new ReviewServices().GetByID(Convert.ToInt32(HttpContext.Current.Request.Url.Segments[HttpContext.Current.Request.Url.Segments.Count() - 1]));
                    }
                    return (HRR.Core.Domain.Review)Session["CurrentReview"];
                }
                return null;
            }
            set
            {
                Session["CurrentReview"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(CurrentReview != null)
                LoadGoals();
        }

        protected void ItemDataBound(object o, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //var p = ((HRR.Core.Domain.Activity)e.Item.DataItem);
                //var lbl = (IdeaSeed.Web.UI.Label)e.Item.FindControl("lblMessage");
                //switch (p.ActivityType)
                //{
                //    case (int)ActivityType.COMMENT:
                //        lbl.Text = "entered a comment for " + p.PerformedForRef.Name + " at " + p.DateCreated.ToString();
                //        break;
                //}
            }
        }

        private void LoadGoals()
        {
            var list = new GoalServices().GetByReviewID(Convert.ToInt32(HttpContext.Current.Request.Url.Segments[HttpContext.Current.Request.Url.Segments.Count() - 1]));
            dlComments.DataSource = list;
            dlComments.DataBind();
        }
    }
}