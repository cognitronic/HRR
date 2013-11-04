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
    public partial class CommentListView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadComments();
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
                var sb = new StringBuilder();
                sb.Append(EmailHelper.EmailHTMLStart());
                sb.Append("<div class='maincontainer'>");
                sb.Append("<h2><span>Comment Flagged As Inappropriate</span></h2>");
                sb.Append("<div class='maincontent'>");
                sb.Append(SecurityContextManager.Current.CurrentUser.Name);
                sb.Append(" flagged the following comment as inappropriate.<br /><br />");
                sb.Append("Comment ID: ");
                sb.Append(nc.ID.ToString());
                sb.Append("<br />Entered For: ");
                sb.Append(nc.EnteredForRef.Name);
                sb.Append("<br />Entered By: ");
                sb.Append(nc.EnteredByRef.Name);
                sb.Append("<br />Comment: ");
                sb.Append(nc.Message);
                sb.Append("<br />Click here to view: <a href='");
                sb.Append(ConfigurationManager.AppSettings["BASEURL"]);
                sb.Append("/Comments/");
                sb.Append(c.ID.ToString());
                sb.Append("'>HRRiver.com</a></div></div>");
                sb.Append(EmailHelper.EmailHTMLEnd());
                try
                {
                    var list = new NotificationSubscriberServices().GetByNotificationID((int)Notification.FLAGGED_COMMENT);
                    foreach (var sub in list)
                    {
                        IdeaSeed.Core.Mail.EmailUtils.SendEmail(sub.Subscriber.Email, "noreply@hrrriver.com", "", "", "A Comment Has Been Flagged", sb.ToString(), false, "");
                    }
                }
                catch (Exception exc)
                {

                }

            }
            LoadComments();
        }

        protected void ViewCommentClicked(object o, EventArgs e)
        {
            Response.Redirect("/Comments/" + ((LinkButton)o).Attributes["itemid"]);
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
                var responses = (IdeaSeed.Web.UI.LinkButton)e.Item.FindControl("lbResponseCount");
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

                                if ((((Person)SecurityContextManager.Current.CurrentUser).ID == member.PersonID && member.IsManager) || ((Person)SecurityContextManager.Current.CurrentUser).ID == p.EnteredByRef.ManagerID)
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
                //lbl.Text = p.Message;
            }
        }

        public void LoadComments()
        {
            if (SecurityContextManager.Current.CurrentTeamID != null)
            {
                var team = new TeamServices().GetByID((int)SecurityContextManager.Current.CurrentTeamID);
                var list = new CommentServices().GetByTeamID((int)SecurityContextManager.Current.CurrentTeamID).ToList<Comment>();
                var page = (HRR.Website.Comments)this.Parent.Page;
                switch (page.SortDDL.SelectedValue)
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
                            o.EnteredBy != SecurityContextManager.Current.CurrentUser.ID));
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