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
using Telerik.Web.UI;

namespace HRR.Website
{
    public partial class Comments : HRRBasePage
    {
        
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
                }
                else
                {
                    if (ddlTeams.SelectedIndex == -1)
                    {
                        if (ddlTeams.Items.Count > 1)
                        {
                            ddlTeams.SelectedIndex = 1;
                            SecurityContextManager.Current.CurrentTeamID = Convert.ToInt16(ddlTeams.SelectedValue);
                            clv.LoadComments();
                            ddlCommentFor.LoadUsers();
                        }
                    }
                }
                //switch (((Person)SecurityContextManager.Current.CurrentUser).RoleID)
                //{
                //    case (int)SecurityRole.EMPLOYEE:
                //        Response.Redirect("/Comments/Mine");
                //        break;
                //    case (int)SecurityRole.MANAGER:
                //        Response.Redirect("/Comments/Team");
                //        break;
                //}
                //LoadTeams();
                if(((Person)SecurityContextManager.Current.CurrentUser).RoleID < (int)SecurityRole.MANAGER)
                {
                    if (!SecurityContextManager.Current.CurrentURL.Contains("Mine"))
                    {
                        Response.Redirect("/Comments/Mine");
                    }
                    else
                    {
                        if (((Person)SecurityContextManager.Current.CurrentUser).RoleID == (int)SecurityRole.READ_ONLY)
                        {
                            divAddComment.Visible = false;
                        }
                        else
                        {
                            divAddComment.Visible = true;
                        }
                        divFilters.Visible = false;
                        
                    }
                }
                if (((Person)SecurityContextManager.Current.CurrentUser).RoleID < (int)SecurityRole.EXECUTIVE_MANAGEMENT)
                {
                    spanFlagged.Visible = false;
                }
                //else if (((Person)SecurityContextManager.Current.CurrentUser).RoleID == (int)SecurityRole.MANAGER)
                //{

                //    if (!SecurityContextManager.Current.CurrentURL.Contains("Team"))
                //    {
                //        Response.Redirect("/Comments/Team");
                //    }
                //    else
                //    {
                //        divFilters.Visible = false;
                //        divAddComment.Visible = true;
                //    }
                //}
            }
        }

        protected void SortSelectedIndexChanged(object o, EventArgs e)
        {
            clv.LoadComments();
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
            if (ddlTeams.SelectedIndex > 0)
            {
                SecurityContextManager.Current.CurrentTeamID = Convert.ToInt16(ddlTeams.SelectedValue);
                clv.LoadComments();
                ddlCommentFor.LoadUsers();
            }
            else
            {
                SecurityContextManager.Current.CurrentTeamID = null;
                clv.LoadComments();
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

            Cache.Remove(ResourceStrings.Cache_Comments);
            Cache.Insert(ResourceStrings.Cache_Comments, 
                new CommentServices().GetAllAppropriate()
                .OrderByDescending(o => o.DateCreated));
            IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();


            var nc = new CommentServices().GetByID(c.ID);
            if (new TeamMemberServices().GetByPersonIDTeamID(c.EnteredFor, c.TeamID).RecievesNotifications)
            {
                var sb = new StringBuilder();
                sb.Append(EmailHelper.EmailHTMLStart());
                sb.Append("<div class='maincontainer'>");
                sb.Append("<h2><span>New Comment</span></h2>");
                sb.Append("<div class='maincontent'>");
                sb.Append(nc.EnteredByRef.Name);
                sb.Append(" has entered a comment about you.  Click here to view: <a href='");
                sb.Append(ConfigurationManager.AppSettings["BASEURL"]);
                sb.Append("/Comments/");
                sb.Append(c.ID.ToString());
                sb.Append("'>HRRiver.com</a></div></div>");
                sb.Append(EmailHelper.EmailHTMLEnd());
                try
                {
                    IdeaSeed.Core.Mail.EmailUtils.SendEmail(nc.EnteredForRef.Email, "noreply@hrrriver.com", "", ConfigurationManager.AppSettings["NEWCOMMENTNOTIFICATION"], "You Have A New Comment", sb.ToString(), false, "");
                }
                catch (Exception exc)
                {

                }
            }
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

    }
}