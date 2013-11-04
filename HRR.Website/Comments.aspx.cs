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

namespace HRR.Website
{
    public partial class Comments : HRRBasePage
    {
        ICacheStorage _cache = new MemcacheCacheAdapter();   
        public IdeaSeed.Web.UI.DropDownList SortDDL
        {
            get
            {
                return ddlSort;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divFollowUp.Visible = false;
                if (SecurityContextManager.Current.CurrentTeamID != null)
                {
                    ddlTeams.SelectedValue = SecurityContextManager.Current.CurrentTeamID.ToString();
                    LoadComments();
                }
                else
                {
                    if (ddlTeams.SelectedIndex == -1)
                    {
                        if (ddlTeams.Items.Count > 1)
                        {
                            ddlTeams.SelectedIndex = 1;
                            SecurityContextManager.Current.CurrentTeamID = Convert.ToInt16(ddlTeams.SelectedValue);
                            LoadComments();
                            ddlCommentFor.LoadUsers();
                        }
                    }
                }

                if (((Person)SecurityContextManager.Current.CurrentUser).RoleID == (int)SecurityRole.READ_ONLY)
                {
                    divAddComment.Visible = false;
                }
                else
                {
                    divAddComment.Visible = true;
                }

                if (((Person)SecurityContextManager.Current.CurrentUser).RoleID < (int)SecurityRole.EXECUTIVE_MANAGEMENT)
                {
                    spanFlagged.Visible = false;
                }
            }
        }

        protected void SortSelectedIndexChanged(object o, EventArgs e)
        {
            LoadComments();
        }

        protected void RateClicked(object o, EventArgs e)
        {
            if (((RadRating)o).SelectedItem.Value == -1)
                divFollowUp.Visible = true;
            else
                divFollowUp.Visible = false;
        }

        protected void PostClicked(object o, EventArgs e)
        {
            SaveComment();
            Response.Redirect(SecurityContextManager.Current.CurrentURL);
        }

        protected void TeamSelectedIndexChanged(object o, EventArgs e)
        {
            _cache.Remove(SecurityContextManager.Current.CurrentUser.ID.ToString() + "_CommentsFeed");
            if (ddlTeams.SelectedIndex > 0)
            {
                SecurityContextManager.Current.CurrentTeamID = Convert.ToInt16(ddlTeams.SelectedValue); 
                LoadComments();
                ddlCommentFor.LoadUsers();
            }
            else
            {
                SecurityContextManager.Current.CurrentTeamID = null;
                LoadComments();
                ddlCommentFor.LoadUsers();
            }
        }

        private void SaveComment()
        {
            var c = new HRR.Core.Domain.Comment();
            c.CategoryID = Convert.ToInt16(ddlCommentCategory.SelectedValue);
            c.CommentType = Convert.ToInt16(ratingBinary.SelectedItem.Value);
            c.DateCreated = DateTime.Now;
            c.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
            c.EnteredFor = Convert.ToInt16(ddlCommentFor.SelectedValue);
            c.FlaggedAsInappropriate = false;
            c.Message = tbNewComment.Text;
            c.TeamID = Convert.ToInt16(ddlTeams.SelectedValue);
            c.FollowUpDate = DateTime.Now.AddDays(7);
            c.SecurityType = 1;
            c.AccountID = SecurityContextManager.Current.CurrentAccount.ID;
            c.LastUpdated = DateTime.Now;
            c.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
            c.IncludedInReview = true;
            new CommentServices().Save(c);

            var a = new Activity();
            a.AccountID = c.AccountID;
            a.ActivityType = (int)ActivityType.COMMENT;
            a.DateCreated = DateTime.Now;
            a.PerformedBy = c.EnteredBy;
            a.PerformedFor = c.EnteredFor;
            a.URL = "/Comments/" + c.ID.ToString();
            new ActivityServices().Save(a);

            
            IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();


            var nc = new CommentServices().GetByID(c.ID);
            if (new TeamMemberServices().GetByPersonIDTeamID(c.EnteredFor, c.TeamID).RecievesNotifications)
            {
                EmailHelper.SendNewCommentNotification(nc);
            }
            _cache.Remove(SecurityContextManager
                    .Current
                    .CurrentUser.ID.ToString() + "_CommentsFeed");
            LoadComments();
        }

        private void LoadTeams()
        {
            //var list = new List<Team>();
            //foreach (var i in ((Person)SecurityContextManager.Current.CurrentUser).Memberships)
            //{
            //    list.Add(i.TeamRef);
            //}
            //rtvTeams.DataSource = list;
            //rtvTeams.DataTextField = "Name";
            //rtvTeams.DataValueField = "ID";
            //rtvTeams.DataBind();
        }

        protected void ReportPostClicked(object o, EventArgs e)
        {
            if (SecurityContextManager.Current.CurrentURL.Contains("Flagged"))
            {
                var c = new CommentServices().GetByID(Convert.ToInt16(((LinkButton)o).Attributes["postid"]));
                c.FlaggedAsInappropriate = false;
                new CommentServices().Save(c);
            }
            else
            {
                var c = new CommentServices().GetByID(Convert.ToInt16(((LinkButton)o).Attributes["postid"]));
                c.FlaggedAsInappropriate = true;
                new CommentServices().Save(c);
                IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();
                var nc = new CommentServices().GetByID(c.ID);

                var emails = "";
                foreach (var nu in new NotificationSubscriberServices().GetByNotificationIDAccountID((int)Notification.FLAGGED_COMMENT, SecurityContextManager.Current.CurrentAccount.ID))
                {
                    emails += nu.Subscriber.Email + ",";
                }
                EmailHelper.SendFlaggedCommentNotification(nc, emails.Remove(emails.Length - 1, 1));

            }
            _cache.Remove(SecurityContextManager
                    .Current
                    .CurrentUser.ID.ToString() + "_CommentsFeed");
            LoadComments();
        }

        protected void ViewCommentClicked(object o, EventArgs e)
        {
            Response.Redirect("/Comments/" + ((LinkButton)o).Attributes["itemid"]);
        }

        protected void DeleteCommentClicked(object o, EventArgs e)
        {
            var c = new CommentServices().GetByID(Convert.ToInt32(((LinkButton)o).Attributes["itemid"]));
            new CommentServices().Delete(c);
            _cache.Remove(SecurityContextManager.Current.CurrentUser.ID.ToString() + "_CommentsFeed");
            LoadComments();
        }

        protected void ResponseCountClicked(object o, EventArgs e)
        {
            Response.Redirect("/Comments/" + ((LinkButton)o).Attributes["itemid"]);
        }

        protected void ItemDataBound(object o, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var p = ((HRR.Core.Domain.Comment)e.Item.DataItem);
                var lbl = (IdeaSeed.Web.UI.Label)e.Item.FindControl("lblMessage");
                var delete = (IdeaSeed.Web.UI.LinkButton)e.Item.FindControl("lbDeleteComment");
                var responses = (IdeaSeed.Web.UI.LinkButton)e.Item.FindControl("lbResponseCount");
                if (SecurityContextManager.Current.CurrentUser.ID != p.EnteredBy)
                    delete.Visible = false;
                else
                    delete.Visible = true;
                //If readonly then hide responses link
                if (((Person)SecurityContextManager.Current.CurrentUser).RoleID == (int)SecurityRole.READ_ONLY)
                {
                    responses.Visible = false;
                }
                else
                {
                    responses.Visible = true;
                    responses.Text = p.Communication.Count().ToString() + " responses left";
                }
                if (p.CommentType == -1)
                {
                    if (((Person)SecurityContextManager.Current.CurrentUser).RoleID == (int)SecurityRole.ADMIN)
                    {
                        lbl.Text = p.Message;
                    }
                    else
                    {
                        if (SecurityContextManager.Current.CurrentUser.ID == p.EnteredFor || SecurityContextManager.Current.CurrentUser.ID == p.EnteredBy)
                        {
                            lbl.Text = p.Message;
                        }
                        else
                        {
                            if (((Person)SecurityContextManager.Current.CurrentUser).RoleID < (int)SecurityRole.MANAGER)
                            {
                                ((HtmlGenericControl)e.Item.FindControl("divContainer")).Visible = false;
                                lbl.Text = "<i><b>Contstructive Comment Made</b></i>";
                            }
                            else
                            {
                                var member = new TeamMemberServices().GetByPersonIDTeamID(p.EnteredFor, p.TeamID);

                                if (member != null && (((Person)SecurityContextManager.Current.CurrentUser).ID == member.PersonID && member.IsManager) || ((Person)SecurityContextManager.Current.CurrentUser).ID == p.EnteredByRef.ManagerID)
                                {
                                    lbl.Text = p.Message;
                                }
                                else
                                {
                                    ((HtmlGenericControl)e.Item.FindControl("divContainer")).Visible = false;
                                    lbl.Text = "<i><b>Contstructive Comment Made</b></i>";
                                }
                            }
                        }
                    }
                    ((HtmlGenericControl)e.Item.FindControl("lblEnteredBy")).Visible = true;
                }
                else
                    lbl.Text = p.Message;
            }
        }

        public void LoadComments()
        {
            if (SecurityContextManager.Current.CurrentTeamID != null)
            {
               // _cache.Remove(SecurityContextManager.Current.CurrentAccount.ID.ToString() + "_CommentsFeed");
                var list = new List<Comment>();
                if (_cache.Retrieve<List<Comment>>(SecurityContextManager.Current.CurrentUser.ID.ToString() + "_CommentsFeed") == null)
                {
                    list = new CommentServices().GetByTeamID((int)SecurityContextManager.Current.CurrentTeamID).ToList<Comment>();
                    _cache.Store(SecurityContextManager
                    .Current
                    .CurrentUser.ID.ToString() + "_CommentsFeed", list);
                }
                else
                {
                    list = _cache.Retrieve<List<Comment>>(SecurityContextManager
                        .Current
                        .CurrentUser.ID.ToString() + "_CommentsFeed");
                }
                var team = new TeamServices().GetByID((int)SecurityContextManager.Current.CurrentTeamID);
                
                //var page = (HRR.Website.Comments)this.Parent.Page;
                switch (ddlSort.SelectedValue)
                {
                    case "0":
                        list = list.OrderByDescending(o => o.DateCreated).ToList<Comment>();
                        break;
                    case "1":
                        list = list.OrderBy(o => o.EnteredByRef.LastName).ToList<Comment>();
                        break;
                    case "2":
                        list = list.OrderBy(o => o.EnteredForRef.LastName).ToList<Comment>();
                        break;
                    case "3":
                        list = list.OrderBy(o => o.Category.Name).ToList<Comment>();
                        break;
                    case "4":
                        list = list.OrderBy(o => o.CommentType).ToList<Comment>();
                        break;
                    default:
                        list = list.OrderByDescending(o => o.DateCreated).ToList<Comment>();
                        break;
                }
                bool ismanager = false;

                if (SecurityContextManager.Current.CurrentURL.Contains("All"))
                {
                    foreach (var m in team.Members)
                    {
                        if (m.PersonID == SecurityContextManager.Current.CurrentUser.ID)
                        {
                            if (m.IsManager)
                                ismanager = true;
                        }
                    }
                    var results = new List<Comment>();
                    var temp = new List<Comment>();
                    var temp2 = new List<Comment>();
                    if (!ismanager)
                    {

                        temp = list;
                        temp.RemoveAll(o => (o.CommentType == -1 &&
                            o.EnteredBy != SecurityContextManager.Current.CurrentUser.ID) && (o.CommentType == -1 &&
                            o.EnteredFor != SecurityContextManager.Current.CurrentUser.ID));
                        results.AddRange(temp);

                        temp2 = list;
                        temp2.RemoveAll(o => (o.CommentType == -1 &&
                            o.EnteredFor != SecurityContextManager.Current.CurrentUser.ID));
                        results.AddRange(temp2);
                    }
                    else
                    {
                        results = list;
                    }
                    dlComments.DataSource = results.Distinct();
                    dlComments.DataBind();

                    #region Oldstuff
                    //var team = new List<TeamMember>();
                    //foreach (var t in ((Person)SecurityContextManager.Current.CurrentUser).Memberships)
                    //{
                    //    foreach (var m in t.TeamRef.Members)
                    //    {
                    //        if (SecurityContextManager.Current.CurrentUser.ID == m.PersonID)
                    //        {
                    //            if (m.IsManager)
                    //                ismanager = true;
                    //        }

                    //        team.Add(m);
                    //    }
                    //}
                    //((Person)SecurityContextManager.Current.CurrentUser).DepartmentRef.People;
                    //var comments = new List<Comment>();
                    //foreach (var member in team.Distinct())
                    //{
                    //if (member.PersonID == SecurityContextManager.Current.CurrentUser.ID && member.IsManager)
                    //{
                    //    var mine = from l in list
                    //               where l.EnteredBy == member.PersonRef.ID ||
                    //               l.EnteredFor == member.PersonRef.ID 
                    //               orderby l.DateCreated descending
                    //               select l;
                    //    comments.AddRange(mine);
                    //}
                    //else
                    //{
                    //    var mine = from l in list
                    //               where 
                    //               (l.CommentType == -1 && (l.EnteredBy == SecurityContextManager.Current.CurrentUser.ID || l.EnteredFor == SecurityContextManager.Current.CurrentUser.ID))
                    //               orderby l.DateCreated descending
                    //               select l;
                    //    comments.AddRange(mine);

                    //    mine = from i in list
                    //           where
                    //           (i.EnteredBy == member.PersonRef.ID ||
                    //               i.EnteredFor == member.PersonRef.ID) &&
                    //               i.CommentType != -1
                    //           orderby i.DateCreated descending
                    //           select i;
                    //    comments.AddRange(mine);
                    //}
                    //    var mine = from l in list
                    //               where l.EnteredBy == member.PersonRef.ID ||
                    //               l.EnteredFor == member.PersonRef.ID
                    //               orderby l.DateCreated descending
                    //               select l;
                    //    comments.AddRange(mine);
                    //}
                    //var results = new List<Comment>();
                    //var temp = new List<Comment>();
                    //var temp2 = new List<Comment>();
                    //if (!ismanager)
                    //{

                    //    temp = comments;
                    //    temp.RemoveAll(o => (o.CommentType == -1 &&
                    //        o.EnteredBy != SecurityContextManager.Current.CurrentUser.ID));
                    //    temp2 = comments;
                    //    temp2.RemoveAll(o => (o.CommentType == -1 &&
                    //        o.EnteredFor != SecurityContextManager.Current.CurrentUser.ID));
                    //}
                    //results.AddRange(temp);
                    //results.AddRange(temp2);
                    //dlComments.DataSource = results.Distinct().OrderByDescending(o => o.DateCreated);
                    //dlComments.DataBind();
                    #endregion
                }
                else if (SecurityContextManager.Current.CurrentURL.Contains("Flagged"))
                {
                    if (((Person)SecurityContextManager.Current.CurrentUser).RoleID < (int)SecurityRole.ADMIN)
                    {
                        Response.Redirect("/Comments/Mine");
                    }
                    dlComments.DataSource = new CommentServices().GetFlaggedByTeamID((int)SecurityContextManager.Current.CurrentTeamID);
                    dlComments.DataBind();
                }
                else if (SecurityContextManager.Current.CurrentURL.Contains("Mine"))
                {
                    var mine = from l in list
                               where l.EnteredBy == SecurityContextManager.Current.CurrentUser.ID ||
                               l.EnteredFor == SecurityContextManager.Current.CurrentUser.ID
                               select l;
                    dlComments.DataSource = mine;
                    dlComments.DataBind();
                }
                else if (SecurityContextManager.Current.CurrentURL.Contains("Profile"))
                {
                    switch (((Person)SecurityContextManager.Current.CurrentUser).RoleID)
                    {
                        case (int)SecurityRole.ADMIN:
                        case (int)SecurityRole.EXECUTIVE_MANAGEMENT:
                            var mine = from l in list
                                       where l.EnteredBy == SecurityContextManager.Current.CurrentProfile.ID ||
                                       l.EnteredFor == SecurityContextManager.Current.CurrentProfile.ID
                                       select l;
                            dlComments.DataSource = mine;
                            dlComments.DataBind();
                            break;
                        case (int)SecurityRole.MANAGER:
                            var t = ((Person)SecurityContextManager.Current.CurrentUser).DepartmentRef.People;
                            var comments = new List<Comment>();
                            foreach (var member in t)
                            {
                                mine = from l in list
                                       where l.EnteredBy == member.ID ||
                                       l.EnteredFor == member.ID
                                       select l;
                                comments.AddRange(mine);
                            }
                            dlComments.DataSource = comments.Distinct();
                            dlComments.DataBind();
                            break;
                        default:
                            mine = from l in list
                                   where l.EnteredBy == SecurityContextManager.Current.CurrentUser.ID ||
                                   l.EnteredFor == SecurityContextManager.Current.CurrentUser.ID
                                   select l;
                            dlComments.DataSource = mine;
                            dlComments.DataBind();
                            break;
                    }

                }
                else
                {
                    dlComments.DataSource = list;
                    dlComments.DataBind();
                }
            }
            else
            {
                dlComments.DataSource = null;
                dlComments.DataBind();
            }
        }

    }
}