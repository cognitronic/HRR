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
    public partial class Goal : HRRBasePage
    {
        private HRR.Core.Domain.Goal CurrentGoal
        {
            get
            {
                if (!SecurityContextManager.Current.CurrentURL.Contains("New"))
                {
                    var g = new GoalServices().GetByID(Convert.ToInt32(HttpContext.Current.Request.Url.Segments[HttpContext.Current.Request.Url.Segments.Count() - 1]));
                    if (g != null)
                        return g;
                    return null;
                }
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
            if (CurrentGoal == null)
            {
                lblName.Text = "New Goal";
                this.CurrentProfile = new PersonServices().GetByID(Convert.ToInt32(HttpContext.Current.Request.Url.Segments[HttpContext.Current.Request.Url.Segments.Count() - 1]));
                if (((Person)SecurityContextManager.Current.CurrentUser).RoleID < (int)SecurityRole.MANAGER)
                {
                    ddlType.SelectedValue = ((int)GoalType.PROFESSIONAL_DEVELOPMENT).ToString();
                    ddlType.Enabled = false;
                }
                ddlStatus.SelectedValue = ((int)GoalStatus.AWAITING_ACCEPTANCE).ToString();
                ddlStatus.Enabled = false;
                lbAccept.Visible = false;
                lbApprove.Visible = false;
            }
            else
            {
                lblName.Text = "Goal - " + CurrentGoal.Title;
                this.CurrentProfile = CurrentGoal.EnteredForRef;
            }

            if (!IsPostBack)
            {
                if (CurrentGoal != null)
                {
                    if (CurrentGoal.IsAccepted)
                        lbAccept.Visible = false;
                    if (CurrentGoal.IsApproved)
                        lbApprove.Visible = false;
                    switch (((Person)SecurityContextManager.Current.CurrentUser).RoleID)
                    { 
                        case (int)SecurityRole.READ_ONLY:
                        case (int)SecurityRole.EMPLOYEE:
                            if (CurrentGoal.EnteredFor != SecurityContextManager.Current.CurrentUser.ID)
                                Response.Redirect(SecurityContextManager.Current.PreviousURL);

                            if (CurrentGoal.EnteredBy != SecurityContextManager.Current.CurrentUser.ID)
                            {
                                lbApprove.Visible = false;
                                lbSave.Visible = false;
                                rgMilestones.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                            }
                            break;
                        case (int)SecurityRole.MANAGER:
                            if (CurrentGoal.EnteredForRef.ManagerID != SecurityContextManager.Current.CurrentUser.ID ||
                                CurrentGoal.EnteredFor != SecurityContextManager.Current.CurrentUser.ID)
                                Response.Redirect(SecurityContextManager.Current.PreviousURL);
                            break;
                    }

                    LoadGoal();
                    LoadMilestones(true);
                    LoadComments();
                    LoadManagers(true);
                    //this.Master.MasterProfileInfo.Visible = false;
                    //this.Master.MasterProfilePicLink.Enabled = false;
                    LoadTabRecordCount();
                    divCommunication.Visible = true;
                    divMilestones.Visible = true;
                }
                else
                {
                    if (this.CurrentProfile.Reviews.Count() < 1 || !this.CurrentProfile.Reviews[0].IsActive)
                    {
                        msgContainer.Visible = true;
                        var sb = new StringBuilder();
                        sb.Append("<span class='error' style='margin-top: 30px;'>This user does not have an active review.  Please add a new review <a href='/Review/New/" + this.CurrentProfile.ID.ToString() + "'>Here</a></span>");
                        msgContainer.InnerHtml = sb.ToString();
                        lbSave.Visible = false;
                    }
                    else
                    {
                        lbSave.Visible = true;
                        msgContainer.Visible = false;
                    }
                    divCommunication.Visible = false;
                    divMilestones.Visible = false;
                }
            }
        }

        protected void ApproveClicked(object o, EventArgs e)
        {
            var g = new HRR.Core.Domain.Goal();
            g = CurrentGoal;
            g.IsApproved = true;
            new GoalServices().Save(g);
            //lbApprove.Visible = false;
            Response.Redirect(SecurityContextManager.Current.CurrentURL);
        }

        protected void AcceptClicked(object o, EventArgs e)
        {
            var g = new HRR.Core.Domain.Goal();
            g = CurrentGoal;
            g.IsAccepted = true;
            new GoalServices().Save(g);
            //lbAccept.Visible = false;
            Response.Redirect(SecurityContextManager.Current.CurrentURL);
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            if (SecurityContextManager.Current != null)
            {
                SecurityContextManager.Current.CurrentProfile = null;
            }
        }

        private void LoadGoal()
        {
            if (CurrentGoal != null)
            {
                tbDescription.Text = CurrentGoal.Description;
                tbTitle.Text = CurrentGoal.Title;
                tbDueDate.SelectedDate = CurrentGoal.DueDate;
                ddlStatus.SelectedValue = CurrentGoal.StatusID.ToString();
                ddlType.SelectedValue = CurrentGoal.GoalType.ToString();
            }
        }

        protected void SaveClicked(object o, EventArgs e)
        {
            SaveGoal();
        }

        protected void CancelClicked(object o, EventArgs e)
        {
            Response.Redirect(SecurityContextManager.Current.PreviousURL);
        }

        protected void SaveGoal()
        {
            var g = new HRR.Core.Domain.Goal();
            if (CurrentGoal == null)
            {
                var r = new ReviewServices().GetEmployeeActiveReview(CurrentProfile.ID);
                g.DateCreated = DateTime.Now;
                g.Description = tbDescription.Text;
                g.AccountID = ((Person)SecurityContextManager.Current.CurrentUser).AccountID;
                g.DueDate = (DateTime)tbDueDate.SelectedDate;
                g.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
                g.EnteredFor = CurrentProfile.ID;
                g.GoalType = Convert.ToInt16(ddlType.SelectedValue);
                g.ReviewID = r.ID;
                g.Score = 0;
                g.StatusID = Convert.ToInt16(ddlStatus.SelectedValue);
                g.Title = tbTitle.Text;
                new GoalServices().Save(g);

                var a = new Activity();
                a.AccountID = CurrentProfile.AccountID;
                a.URL = "/Goals/" + g.ID.ToString();
                a.ActivityType = (int)ActivityType.NEW_GOAL;
                a.DateCreated = DateTime.Now;
                a.PerformedBy = SecurityContextManager.Current.CurrentUser.ID;
                a.PerformedFor = CurrentProfile.ID;
                new ActivityServices().Save(a);
            }
            else
            {
                g = CurrentGoal;
                g.Description = tbDescription.Text;
                g.DueDate = (DateTime)tbDueDate.SelectedDate;
                g.Score = 0;
                g.StatusID = Convert.ToInt16(ddlStatus.SelectedValue);
                g.Title = tbTitle.Text;
                g.GoalType = Convert.ToInt16(ddlType.SelectedValue);
                new GoalServices().Save(g);

                var a = new Activity();
                a.AccountID = CurrentProfile.AccountID;
                a.ActivityType = (int)ActivityType.GOAL_UPDATED;
                a.DateCreated = DateTime.Now;
                a.URL = "/Goals/" + g.ID.ToString();
                a.PerformedBy = SecurityContextManager.Current.CurrentUser.ID;
                a.PerformedFor = CurrentProfile.ID;
                new ActivityServices().Save(a);
            }
            string emails = "";
            if (g.Managers.Count > 0)
            {
                foreach (var m in g.Managers)
                {
                    emails += m.PersonRef.Email + ",";
                }
            }
            var sb = new StringBuilder();
            sb.Append(EmailHelper.EmailHTMLStart());
            sb.Append("<div class='maincontainer'>");
            sb.Append("<h2><span>Goal Activity</span></h2>");
            sb.Append("<div class='maincontent'>");
            sb.Append("Click here to view: <a href='");
            sb.Append(ConfigurationManager.AppSettings["BASEURL"]);
            sb.Append("/Goals/");
            sb.Append(g.ID.ToString());
            sb.Append("'>HRRiver.com</a></div></div>");
            sb.Append(EmailHelper.EmailHTMLEnd());
            try
            {
                IdeaSeed.Core.Mail.EmailUtils.SendEmail(CurrentProfile.Email, "noreply@hrrriver.com", "", emails + ConfigurationManager.AppSettings["NEWGOALNOTIFICATION"], "You Have New Goal Activity", sb.ToString(), false, "");
            }
            catch (Exception exc)
            {

            }

            Response.Redirect("/Goals/" + g.ID.ToString());

        }

        #region Managers

        protected void ManagerNeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadManagers(false);
        }

        protected void ManagerItemDataBound(object o, GridItemEventArgs e)
        {

        }

        protected void ManagerItemCreated(object o, GridItemEventArgs e)
        {
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                if (!e.Item.OwnerTableView.IsItemInserted)
                {
                    LinkButton updateButton = (LinkButton)e.Item.FindControl("UpdateButton");
                    updateButton.Text = "Update ";
                    updateButton.CssClass = "button small round sky-blue";
                    updateButton.Style["margin-top"] = "15px !important";
                    updateButton.Style["margin-bottom"] = "15px !important";
                }
                else
                {
                    LinkButton insertButton = (LinkButton)e.Item.FindControl("PerformInsertButton");
                    insertButton.Text = "Insert";
                    insertButton.CssClass = "button small round sky-blue";
                    insertButton.Style["margin-top"] = "15px !important";
                    insertButton.Style["margin-bottom"] = "15px !important";
                }
                LinkButton cancelButton = (LinkButton)e.Item.FindControl("CancelButton");
                cancelButton.Text = "Cancel";
                cancelButton.CssClass = "button small round sky-blue";
                cancelButton.Style["margin-top"] = "15px !important";
                cancelButton.Style["margin-bottom"] = "15px !important";
            }
        }

        protected void ManagerItemCommand(object o, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.InitInsertCommandName)
            {
                e.Canceled = true;
                var i = new HRR.Core.Domain.GoalManager();
                i.GoalID = 0;
                i.PersonID = 0;
                i.RecievesNotifications = true;
                i.ID = 0;
                e.Item.OwnerTableView.InsertItem(i);
            }

            if (e.CommandName == RadGrid.PerformInsertCommandName)
            {
                var t = new HRR.Core.Domain.GoalManager();
                t.RecievesNotifications = (e.Item.FindControl("cbRecievesNotifications") as IdeaSeed.Web.UI.CheckBox).Checked;
                t.PersonID = Convert.ToInt16((e.Item.FindControl("ddlPerson") as HRR.Web.Controls.ManagersDDL).SelectedValue);
                t.GoalID = CurrentGoal.ID;
                new GoalManagerServices().Save(t); IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();
            }
            if (e.CommandName == RadGrid.UpdateCommandName)
            {
                if (e.Item is GridEditableItem)
                {
                    var t = new GoalManagerServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                    t.RecievesNotifications = (e.Item.FindControl("cbRecievesNotifications") as IdeaSeed.Web.UI.CheckBox).Checked;
                    new GoalManagerServices().Save(t); IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();
                }
            }
            if (e.CommandName == RadGrid.DeleteCommandName)
            {
                var t = new GoalManagerServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                new GoalManagerServices().Delete(t);
            }
            LoadManagers(true);
            
        }

        private void LoadManagers(bool bindData)
        {
            if (CurrentGoal != null)
            {
                rgManager.DataSource = new GoalManagerServices().GetByGoalID(CurrentGoal.ID);
                if (bindData)
                    rgManager.DataBind();
            }
        }
        #endregion

        #region Milestones

        protected void SaveMilestoneClicked(object o, EventArgs e)
        {
            var m = new HRR.Core.Domain.GoalMilestone();
            m.DateCreated = DateTime.Now;
            //m.Description = tbMilestoneDescription.Text;
            //m.DueDate = (DateTime)tbMilestoneDueDate.SelectedDate;
            m.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
            m.GoalID = CurrentGoal.ID;
            m.IsAccepted = true;
            //m.Title = tbMilestoneTitle.Text;
            new GoalMilestoneServices().Save(m);

           

            LoadMilestones(true);
        }

        protected void CancelMilestoneClicked(object o, EventArgs e)
        { 
        
        }

        protected void NeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadMilestones(false);
        }

        protected void ItemDataBound(object o, GridItemEventArgs e)
        {
         
        }

        protected void MilestonesItemCreated(object o, GridItemEventArgs e)
        {
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                if (!e.Item.OwnerTableView.IsItemInserted)
                {
                    LinkButton updateButton = (LinkButton)e.Item.FindControl("UpdateButton");
                    updateButton.Text = "Update ";
                    updateButton.CssClass = "button small round sky-blue";
                    updateButton.Style["margin-top"] = "15px !important";
                    updateButton.Style["margin-bottom"] = "15px !important";
                }
                else
                {
                    LinkButton insertButton = (LinkButton)e.Item.FindControl("PerformInsertButton");
                    insertButton.Text = "Insert";
                    insertButton.CssClass = "button small round sky-blue";
                    insertButton.Style["margin-top"] = "15px !important";
                    insertButton.Style["margin-bottom"] = "15px !important";
                }
                LinkButton cancelButton = (LinkButton)e.Item.FindControl("CancelButton");
                cancelButton.Text = "Cancel";
                cancelButton.CssClass = "button small round sky-blue";
                cancelButton.Style["margin-top"] = "15px !important";
                cancelButton.Style["margin-bottom"] = "15px !important";
            }
        }

        protected void ItemCommand(object o, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.InitInsertCommandName)
            {
                e.Canceled = true;
                var i = new HRR.Core.Domain.GoalMilestone();
                i.DateCreated = DateTime.Now;
                i.Description = "";
                i.DueDate = DateTime.Now;
                i.AccountID = ((Person)SecurityContextManager.Current.CurrentUser).AccountID;
                i.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
                i.GoalID = CurrentGoal.ID;
                i.EnteredFor = CurrentProfile.ID;
                i.Status = (int)GoalStatus.ACCEPTED;
                i.IsAccepted = false;
                i.ID = 0;
                i.Title = "";
                e.Item.OwnerTableView.InsertItem(i);
            }

            if (e.CommandName == RadGrid.PerformInsertCommandName)
            {
                var t = new HRR.Core.Domain.GoalMilestone();
                t.Title = (e.Item.FindControl("tbTitle") as IdeaSeed.Web.UI.TextBox).Text;
                t.Description = (e.Item.FindControl("tbDescription") as IdeaSeed.Web.UI.TextBox).Text;
                t.DateCreated = DateTime.Now;
                t.EnteredFor = CurrentProfile.ID;
                t.Status = (int)GoalStatus.ACCEPTED;
                t.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
                t.GoalID = CurrentGoal.ID;
                t.AccountID = ((Person)SecurityContextManager.Current.CurrentUser).AccountID;
                t.IsAccepted = true;
                t.DueDate = (DateTime)(e.Item.FindControl("tbMilestoneDueDate") as Telerik.Web.UI.RadDatePicker).SelectedDate;
                new GoalMilestoneServices().Save(t);

                var a = new Activity();
                a.AccountID = CurrentProfile.AccountID;
                a.ActivityType = (int)ActivityType.NEW_MILESTONE;
                a.DateCreated = DateTime.Now;
                a.URL = "/Goals/" + CurrentGoal.ID.ToString();
                a.PerformedBy = SecurityContextManager.Current.CurrentUser.ID;
                a.PerformedFor = CurrentProfile.ID;
                new ActivityServices().Save(a);

                string emails = "";
                foreach (var m in CurrentGoal.Managers)
                {
                    emails += m.PersonRef.Email + ",";
                }
                var sb = new StringBuilder();
                sb.Append(EmailHelper.EmailHTMLStart());
                sb.Append("<div class='maincontainer'>");
                sb.Append("<h2><span>Milestone Activity</span></h2>");
                sb.Append("<div class='maincontent'>");
                sb.Append("Click here to view: <a href='");
                sb.Append(ConfigurationManager.AppSettings["BASEURL"]);
                sb.Append("/Goals/");
                sb.Append(t.GoalID.ToString());
                sb.Append("'>HRRiver.com</a></div></div>");
                sb.Append(EmailHelper.EmailHTMLEnd());
                try
                {
                    IdeaSeed.Core.Mail.EmailUtils.SendEmail(CurrentProfile.Email, "noreply@hrrriver.com", "", emails + ConfigurationManager.AppSettings["NEWGOALNOTIFICATION"], "You Have New Milestone Activity", sb.ToString(), false, "");
                }
                catch (Exception exc)
                {

                }
            }
            if (e.CommandName == RadGrid.UpdateCommandName)
            {
                if (e.Item is GridEditableItem)
                {
                    var t = new GoalMilestoneServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                    t.Title = (e.Item.FindControl("tbTitle") as IdeaSeed.Web.UI.TextBox).Text;
                    t.Description = (e.Item.FindControl("tbDescription") as IdeaSeed.Web.UI.TextBox).Text;
                    t.DueDate = (DateTime)(e.Item.FindControl("tbMilestoneDueDate") as Telerik.Web.UI.RadDatePicker).SelectedDate;
                    new GoalMilestoneServices().Save(t);

                    var a = new Activity();
                    a.AccountID = CurrentProfile.AccountID;
                    a.ActivityType = (int)ActivityType.MILESTONE_UPDATED;
                    a.DateCreated = DateTime.Now;
                    a.URL = "/Goals/" + CurrentGoal.ID.ToString();
                    a.PerformedBy = SecurityContextManager.Current.CurrentUser.ID;
                    a.PerformedFor = CurrentProfile.ID;
                    new ActivityServices().Save(a);

                    string emails = "";
                    foreach (var m in CurrentGoal.Managers)
                    {
                        emails += m.PersonRef.Email + ",";
                    }

                    var sb = new StringBuilder();
                    sb.Append(EmailHelper.EmailHTMLStart());
                    sb.Append("<div class='maincontainer'>");
                    sb.Append("<h2><span>Milestone Activity</span></h2>");
                    sb.Append("<div class='maincontent'>");
                    sb.Append("Click here to view: <a href='");
                    sb.Append(ConfigurationManager.AppSettings["BASEURL"]);
                    sb.Append("/Goals/");
                    sb.Append(t.GoalID.ToString());
                    sb.Append("'>HRRiver.com</a></div></div>");
                    sb.Append(EmailHelper.EmailHTMLEnd());
                    try
                    {
                        IdeaSeed.Core.Mail.EmailUtils.SendEmail(CurrentProfile.Email, "noreply@hrrriver.com", "", emails + ConfigurationManager.AppSettings["NEWGOALNOTIFICATION"], "You Have New Milestone Activity", sb.ToString(), false, "");
                    }
                    catch (Exception exc)
                    {

                    }
                }
            }
            if (e.CommandName == RadGrid.DeleteCommandName)
            {
                var t = new GoalMilestoneServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                new GoalMilestoneServices().Delete(t);

                var a = new Activity();
                a.AccountID = CurrentProfile.AccountID;
                a.ActivityType = (int)ActivityType.MILESTONE_UPDATED;
                a.DateCreated = DateTime.Now;
                a.PerformedBy = SecurityContextManager.Current.CurrentUser.ID;
                a.PerformedFor = CurrentProfile.ID;
                new ActivityServices().Save(a);
            }
            LoadMilestones(true);
        }

        private void LoadMilestones(bool bindData)
        {
            if (CurrentGoal != null)
            {
                rgMilestones.DataSource = new GoalMilestoneServices().GetByGoalID(CurrentGoal.ID).OrderBy(o => o.DueDate);
                if (bindData)
                    rgMilestones.DataBind();
            }
        }
        #endregion

        #region Communication

        protected void CommentItemDataBound(object o, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //var p = ((HRR.Core.Domain.GoalCommunication)e.Item.DataItem);
                
                //var ctl = (Telerik.Web.UI.RadBinaryImage)e.Item.FindControl("rbiProfile");
                //var lbl = (HtmlGenericControl)e.Item.FindControl("lblName");
                //if (p != null)
                //{
                //    ctl.ImageUrl = p.EnteredByRef.AvatarPath;
                //    lbl.InnerHtml = "<a href='/Profile/" + p.EnteredByRef.Email + "'>" + p.EnteredByRef.Name + "</a>";
                //}
                //switch (p.ActivityType)
                //{
                //    case (int)ActivityType.COMMENT:
                //        lbl.Text = "entered a comment for " + p.PerformedForRef.Name + " at " + p.DateCreated.ToString();
                //        break;
                //}
            }
        }

        protected void SaveCommentClicked(object o, EventArgs e)
        {
            SaveComment();
            IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();
            LoadComments();
            tbNewComment.Text = "";
        }

        protected void CancelCommentClicked(object o, EventArgs e)
        { 
            
        }

        private void LoadComments()
        {
            dlComments.DataSource = null;
            dlComments.DataBind();

            var list = new GoalCommunicationServices().GetByGoalID(CurrentGoal.ID).OrderBy(o => o.DateCreated);
            if (list.Count() > 0)
            {
                dlComments.DataSource = list;
                dlComments.DataBind();
            }
        }

        private void SaveComment()
        {
            var c = new GoalCommunication();
            c.DateCreated = DateTime.Now;
            c.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
            c.GoalID = CurrentGoal.ID;
            c.Message = tbNewComment.Text;
            new GoalCommunicationServices().Save(c);

            var a = new Activity();
            a.AccountID = CurrentProfile.AccountID;
            a.ActivityType = (int)ActivityType.NEW_GOAL_COMMENT;
            a.DateCreated = DateTime.Now;
            a.URL = "/Goals/" + CurrentGoal.ID.ToString();
            a.PerformedBy = c.EnteredBy;
            a.PerformedFor = CurrentProfile.ID;
            new ActivityServices().Save(a);

            string emails = "";
            foreach (var m in CurrentGoal.Managers)
            {
                emails += m.PersonRef.Email + ",";
            }

            var sb = new StringBuilder();
            sb.Append(EmailHelper.EmailHTMLStart());
            sb.Append("<div class='maincontainer'>");
            sb.Append("<h2><span>Goal Comment Activity</span></h2>");
            sb.Append("<div class='maincontent'>");
            sb.Append("Click here to view: <a href='");
            sb.Append(ConfigurationManager.AppSettings["BASEURL"]);
            sb.Append("/Goals/");
            sb.Append(c.GoalID.ToString());
            sb.Append("'>HRRiver.com</a></div></div>");
            sb.Append(EmailHelper.EmailHTMLEnd());
            try
            {
                IdeaSeed.Core.Mail.EmailUtils.SendEmail(CurrentProfile.Email, "noreply@hrrriver.com", "", emails + ConfigurationManager.AppSettings["NEWGOALNOTIFICATION"], "You Have New Goal Comment Activity", sb.ToString(), false, "");
            }
            catch (Exception exc)
            {

            }
        }
        #endregion

        private void LoadTabRecordCount()
        {
            if (CurrentGoal.Managers.Count > 0)
            {
                rtsGoal.Tabs.FindTabByValue("1").Text = "";
                rtsGoal.Tabs.FindTabByValue("1").Text += "managers (" + CurrentGoal.Managers.Count.ToString() + ")";
            }
            if (CurrentGoal.Milestones.Count > 0)
            {
                rtsGoal.Tabs.FindTabByValue("2").Text = "";
                rtsGoal.Tabs.FindTabByValue("2").Text += "milestones (" + CurrentGoal.Milestones.Count.ToString() + ")";
            }
            if (CurrentGoal.Communication.Count > 0)
            {
                rtsGoal.Tabs.FindTabByValue("3").Text = "";
                rtsGoal.Tabs.FindTabByValue("3").Text += "communication (" + CurrentGoal.Communication.Count.ToString() + ")";
            }
        }

        protected void ExportToCalendar(object o, EventArgs e)
        {

            string desc = "Click here to view goal: " + ConfigurationManager.AppSettings["BASEURL"] + "/Goals/" + CurrentGoal.ID.ToString();
            HttpPageHelper.ExportToCalendar((DateTime)CurrentGoal.DueDate, (DateTime)CurrentGoal.DueDate, "TBD", desc, "Goal:" + CurrentGoal.Title + " is due!!");
        }

    }
}