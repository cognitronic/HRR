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
    public partial class ActivityFeedView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadActivity();
        }

        protected void ItemDataBound(object o, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var p = ((HRR.Core.Domain.Activity)e.Item.DataItem);
                var lbl = (IdeaSeed.Web.UI.Label)e.Item.FindControl("lblMessage");
                switch (p.ActivityType)
                { 
                    case (int)ActivityType.COMMENT:
                        if (!string.IsNullOrEmpty(p.URL))
                        {
                            lbl.Text = "entered a <a href='" + p.URL + "'>comment</a> for " + p.PerformedForRef.Name + " at " + p.DateCreated.ToString();
                        }
                        else
                        {
                            lbl.Text = "entered a comment for " + p.PerformedForRef.Name + " at " + p.DateCreated.ToString();
                        }
                        break;
                    case (int)ActivityType.NEW_COMMENT_RESPONSE:
                        if (!string.IsNullOrEmpty(p.URL))
                        {
                            lbl.Text = "responded to a  <a href='" + p.URL + "'>comment</a> for " + p.PerformedForRef.Name + " at " + p.DateCreated.ToString();
                        }
                        else
                        {
                            lbl.Text = "responded to a comment for " + p.PerformedForRef.Name + " at " + p.DateCreated.ToString();
                        }
                        break;
                    case (int)ActivityType.GOAL_UPDATED:
                        if (!string.IsNullOrEmpty(p.URL))
                        {
                            lbl.Text = "updated a <a href='" + p.URL + "'>goal</a> for " + p.PerformedForRef.Name + " at " + p.DateCreated.ToString();
                        }
                        else
                        {
                            lbl.Text = "updated a goal for " + p.PerformedForRef.Name + " at " + p.DateCreated.ToString();
                        }
                        break;
                    case (int)ActivityType.MILESTONE_UPDATED:
                        if (!string.IsNullOrEmpty(p.URL))
                        {
                            lbl.Text = "updated a <a href='" + p.URL + "'>goal milestone</a> for " + p.PerformedForRef.Name + " at " + p.DateCreated.ToString();
                        }
                        else
                        {
                            lbl.Text = "updated a goal milestone for " + p.PerformedForRef.Name + " at " + p.DateCreated.ToString();
                        }
                        break;
                    case (int)ActivityType.NEW_GOAL:
                        if (!string.IsNullOrEmpty(p.URL))
                        {
                            lbl.Text = "entered a new <a href='" + p.URL + "'>goal</a> for " + p.PerformedForRef.Name + " at " + p.DateCreated.ToString();
                        }
                        else
                        {
                            lbl.Text = "entered a new goal for " + p.PerformedForRef.Name + " at " + p.DateCreated.ToString();
                        }
                        break;
                    case (int)ActivityType.NEW_GOAL_COMMENT:
                        if (!string.IsNullOrEmpty(p.URL))
                        {
                            lbl.Text = "entered a <a href='" + p.URL + "'>goal comment</a> for " + p.PerformedForRef.Name + " at " + p.DateCreated.ToString();
                        }
                        else
                        {
                            lbl.Text = "entered a goal comment for " + p.PerformedForRef.Name + " at " + p.DateCreated.ToString();
                        }
                        break;
                    case (int)ActivityType.NEW_MILESTONE:
                        if (!string.IsNullOrEmpty(p.URL))
                        {
                            lbl.Text = "entered a new <a href='" + p.URL + "'>goal milestone</a> for " + p.PerformedForRef.Name + " at " + p.DateCreated.ToString();
                        }
                        else
                        {
                            lbl.Text = "entered a goal milestone for " + p.PerformedForRef.Name + " at " + p.DateCreated.ToString();
                        }
                        break;
                    case (int)ActivityType.NEW_REVIEW:
                        if (!string.IsNullOrEmpty(p.URL))
                        {
                            lbl.Text = "entered a new <a href='" + p.URL + "'>review</a> for " + p.PerformedForRef.Name + " at " + p.DateCreated.ToString();
                        }
                        else
                        {
                            lbl.Text = "entered a new review for " + p.PerformedForRef.Name + " at " + p.DateCreated.ToString();
                        }
                        break;
                    case (int)ActivityType.REVIEW_UPDATED:
                        if (!string.IsNullOrEmpty(p.URL))
                        {
                            lbl.Text = "updated a <a href='" + p.URL + "'>review</a> for " + p.PerformedForRef.Name + " at " + p.DateCreated.ToString();
                        }
                        else
                        {
                            lbl.Text = "updated a review for " + p.PerformedForRef.Name + " at " + p.DateCreated.ToString();
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Loadds activity by team membership.
        /// </summary>
        private void LoadActivity()
        {
            var list = new ActivityServices().GetAll();
            var results = new List<Activity>();
            if (((Person)SecurityContextManager.Current.CurrentUser).RoleID < (int)SecurityRole.EXECUTIVE_MANAGEMENT)
            {
                foreach (var t in ((Person)SecurityContextManager.Current.CurrentUser).Memberships)
                {
                    foreach (var m in list)
                    {
                        foreach (var p in m.PerformedForRef.Memberships)
                        {
                            if (p.TeamID == t.TeamID)
                                results.Add(m);
                            break;
                        }
                        foreach (var p in m.PerformedByRef.Memberships)
                        {
                            if (p.TeamID == t.TeamID)
                                results.Add(m);
                            break;
                        }
                    }
                }
            }
            else
            {
                results = list.ToList<Activity>();
            }
            if (results.Count() < 1)
                divActivity.Visible = true;
            else
                divActivity.Visible = false;
            dlComments.DataSource = results.Take<Activity>(10);
            dlComments.DataBind();
        }
    }
}

