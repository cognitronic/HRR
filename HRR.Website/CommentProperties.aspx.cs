using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRR.Core.Domain;
using HRR.Services;
using HRR.Core.Security;
using HRR.Web.Bases;
using HRR.Web.Utils;
using Telerik.Web.UI;
using System.Configuration;
using IdeaSeed.Core;
using System.Text;
using HRR.Core;

namespace HRR.Website
{
    public partial class CommentProperties : HRRBasePage
    {
        private HRR.Core.Domain.Comment CurrentComment
        {
            get
            {
                var c = new CommentServices().GetByID(Convert.ToInt32(HttpContext.Current.Request.Url.Segments[HttpContext.Current.Request.Url.Segments.Count() - 1]));
                if (c != null)
                    return c;
                return null;
            }
        }

        private Person _currentProfile = null;
        private Person CurrentProfile
        {
            get
            {

                return SecurityContextManager.Current.CurrentProfile;
            }
            set
            {
                _currentProfile = value;
                SecurityContextManager.Current.CurrentProfile = _currentProfile;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CurrentProfile = CurrentComment.EnteredForRef;
            if (!IsPostBack)
            {
                this.Authenticate();
                if (CurrentComment != null)
                {
                    LoadComment();
                    LoadComments();
                    if (CurrentComment.FlaggedAsInappropriate)
                    {
                        lbReportPost.Text = "<img src='/images/green_flag16.png' title='Remove Flag and Add To Feed' alt='' />";
                    }
                    else
                    {
                        lbReportPost.Text = "<img src='/images/red_flag16.png' title='Flag As Inappropriate' alt='' />";
                    }
                }
            }
        }

        protected void ReportPostClicked(object o, EventArgs e)
        {
            if (CurrentComment.FlaggedAsInappropriate)
            {
                CurrentComment.FlaggedAsInappropriate = false;
                CurrentComment.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
                CurrentComment.LastUpdated = DateTime.Now;
            }
            else
            {
                CurrentComment.FlaggedAsInappropriate = true;
                CurrentComment.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
                CurrentComment.LastUpdated = DateTime.Now;
            }
            new CommentServices().Save(CurrentComment);
            IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            if (SecurityContextManager.Current != null)
            {
                SecurityContextManager.Current.CurrentProfile = null;
            }
        }

        protected void EnteredForClicked(object o, EventArgs e)
        {
            Response.Redirect("/People/" + CurrentComment.EnteredForRef.Email);
        }

        protected void EnteredByClicked(object o, EventArgs e)
        {
            Response.Redirect("/People/" + CurrentComment.EnteredByRef.Email);
        }

        private void LoadComment()
        {
            lblEnteredBy.Text = CurrentComment.EnteredByRef.Name;
            lbEnteredFor.Text = CurrentComment.EnteredForRef.Name;
            lblCategory.Text = CurrentComment.Category.Name;
            lblComment.Text = CurrentComment.Message;
            lblCommentID.Text = CurrentComment.ID.ToString();
            //rbiProfile.ImageUrl = CurrentComment.EnteredForRef.AvatarPath;
            lblChangedBy.Text = CurrentComment.ChangedByRef.Name;
            lblLastUpdated.Text = CurrentComment.LastUpdated.ToString();
            tbFollowUpDate.SelectedDate = CurrentComment.FollowUpDate;
            tbFollowUpResolution.Text = CurrentComment.FollowUpResolution;
            if (CurrentComment.CommentType == 1)
                lblCommentType.Text = "Positive";
            else
                lblCommentType.Text = "Constructive";
            lblDateCreated.Text = CurrentComment.DateCreated.ToString();
            if (CurrentComment.FlaggedAsInappropriate)
                lblFlagged.Text = "YES";
            else
                lblFlagged.Text = "No";
            lblTeam.Text = CurrentComment.TeamRef.Name;
        }

        protected void UpdateCommentClicked(object o, EventArgs e)
        {
            if (tbFollowUpDate.SelectedDate == null)
                CurrentComment.FollowUpDate = DateTime.Now.AddDays(7);
            else
                CurrentComment.FollowUpDate = tbFollowUpDate.SelectedDate;
            CurrentComment.FollowUpResolution = tbFollowUpResolution.Text;
            new CommentServices().Save(CurrentComment);
            IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();
        }

        #region Communication

        protected void ResponseItemDataBound(object o, DataListItemEventArgs e)
        {
            
        }

        protected void SaveResponseClicked(object o, EventArgs e)
        {
            SaveResponse();
            LoadComments();
            tbNewResponse.Text = "";
        }

        protected void CancelResponseClicked(object o, EventArgs e)
        {
            Response.Redirect(SecurityContextManager.Current.PreviousURL);
        }

        private void LoadComments()
        {
            dlResponses.DataSource = null;
            dlResponses.DataBind();
            var list = new CommentResponseServices().GetByCommentID(CurrentComment.ID).OrderByDescending(o => o.DateCreated);
            if (list.Count() > 0)
            {
                dlResponses.DataSource = list;
                dlResponses.DataBind();
            }
        }

        private void SaveResponse()
        {
            var c = new CommentResponse();
            c.DateCreated = DateTime.Now;
            c.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
            c.CommentID = CurrentComment.ID;
            c.Message = tbNewResponse.Text;
            new CommentResponseServices().Save(c);
            IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();

            var a = new Activity();
            a.AccountID = SecurityContextManager.Current.CurrentProfile.AccountID;
            a.ActivityType = (int)ActivityType.NEW_COMMENT_RESPONSE;
            a.DateCreated = DateTime.Now;
            a.URL = "/Comments/" + CurrentComment.ID.ToString();
            a.PerformedBy = c.EnteredBy;
            a.PerformedFor = CurrentComment.EnteredForRef.ID;
            new ActivityServices().Save(a);

            string emails = "";
            foreach (var r in CurrentComment.Communication.GroupBy(cust => cust.EnteredBy).Select(grp => grp.First()))
            {
                emails += r.EnteredByRef.Email + ",";
            }

            EmailHelper.SendCommentResponseNotification(c, emails);
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

        string DateFormat
        {
            get
            {
                return "yyyyMMddTHHmmssZ"; // 20060215T092000Z
            }
        }

        protected void ExportToCalendar( object o, EventArgs e)
        {
            
            string desc = "Follow up on comment left by " + CurrentComment.EnteredByRef.Name + ".  Click here to view comment: " + ConfigurationManager.AppSettings["BASEURL"] + "/Comments/" + CurrentComment.ID.ToString();
            HttpPageHelper.ExportToCalendar((DateTime)CurrentComment.FollowUpDate, (DateTime)CurrentComment.FollowUpDate, "TBD", desc, "Follow Up Construct Comment For " + CurrentComment.EnteredForRef.Name);

            
        }
        #endregion

        private void Authenticate()
        {
            if (CurrentComment.AccountID != ((Person)SecurityContextManager.Current.CurrentUser).AccountID)
            {
                Response.Redirect(ResourceStrings.Page_Default);
            }
            var t = CurrentComment.TeamRef;
            var inteam = false;
            foreach (var m in t.Members)
            {
                if (m.PersonID == SecurityContextManager.Current.CurrentUser.ID)
                {
                    inteam = true;
                    if(!m.HasAccess)
                        Response.Redirect(SecurityContextManager.Current.PreviousURL);

                    if (!m.IsManager)
                    {
                        divUpdateComment.Visible = false;
                        trFollowUp.Visible = false;
                    }
                }
            }

            //if (((Person)SecurityContextManager.Current.CurrentUser).RoleID > (int)SecurityRole.MANAGER)
            //{
            //    inteam = true;
            //    divUpdateComment.Visible = true;
            //    trFollowUp.Visible = true;
            //}

            //if (((Person)SecurityContextManager.Current.CurrentUser).RoleID <= (int)SecurityRole.EMPLOYEE && CurrentComment.EnteredFor != SecurityContextManager.Current.CurrentUser.ID)
            //    Response.Redirect(SecurityContextManager.Current.PreviousURL);

            if (!inteam)
                Response.Redirect(SecurityContextManager.Current.PreviousURL);
        }
    }
}