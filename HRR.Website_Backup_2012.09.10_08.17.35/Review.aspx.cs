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
using HRR.Web.Utils;
using System.Text;
using System.Configuration;
using IdeaSeed.Core;
using Telerik.Web.UI;
using HRR.Core;
using System.Web.UI.HtmlControls;

namespace HRR.Website
{
    public partial class Review : HRRBasePage
    {
        private HRR.Core.Domain.Review CurrentReview
        {
            get
            {
                if (!SecurityContextManager.Current.CurrentURL.Contains("New"))
                {
                    var g = new ReviewServices().GetByID(Convert.ToInt32(HttpContext.Current.Request.Url.Segments[HttpContext.Current.Request.Url.Segments.Count() - 1]));
                    if (g != null)
                        return g;
                    return null;
                }
                return null;
            }
            set
            {
                Session["CurrentReview"] = value;
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
            if (CurrentReview == null)
            {
                lblName.Text = "New Review";
                this.CurrentProfile = new PersonServices().GetByID(Convert.ToInt32(HttpContext.Current.Request.Url.Segments[HttpContext.Current.Request.Url.Segments.Count() - 1]));
            }
            else
            {
                lblName.Text = "Review For " + CurrentReview.StartDate.ToShortDateString() + " to " + CurrentReview.DueDate.ToShortDateString();
                this.CurrentProfile = CurrentReview.EnteredForRef;
            }
            if (!IsPostBack)
            {
                if (CurrentReview != null)
                {
                    ApplySecurity();
                    //divQuestions.Visible = true;
                    LoadReview();
                    LoadCommentCounts();
                    LoadComments();
                    LoadNotes(true);
                    LoadManagers(true);
                    LoadTabRecordCount();
                    switch (((Person)SecurityContextManager.Current.CurrentUser).RoleID)
                    {
                        case (int)SecurityRole.READ_ONLY:
                        case (int)SecurityRole.EMPLOYEE:
                            if (CurrentReview.EnteredFor != SecurityContextManager.Current.CurrentUser.ID)
                                Response.Redirect(SecurityContextManager.Current.PreviousURL);

                            lbSave.Visible = false;
                            break;
                        case (int)SecurityRole.MANAGER:
                            if (CurrentReview.EnteredForRef.ManagerID != SecurityContextManager.Current.CurrentUser.ID || 
                                CurrentReview.EnteredFor != SecurityContextManager.Current.CurrentUser.ID)
                                Response.Redirect(SecurityContextManager.Current.PreviousURL);
                            break;
                    }

                }
                else
                {
                    //divQuestions.Visible = false;
                }
            }
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            if (SecurityContextManager.Current != null)
            {
                SecurityContextManager.Current.CurrentProfile = null;
            }
        }

        protected void SaveClicked(object o, EventArgs e)
        {
            SaveReview();
        }

        protected void SaveQuestionsClicked(object o, EventArgs e)
        {
            SaveQuestions();
            LoadReview();
        }

        protected void CancelClicked(object o, EventArgs e)
        {
            Response.Redirect(SecurityContextManager.Current.PreviousURL);
        }

        protected void ExportClicked(object o, EventArgs e)
        {
            Response.Redirect("/Reports/Reviews/" + CurrentReview.ID.ToString());
        }

        protected void ItemCreated(object o, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //var p = ((HRR.Core.Domain.ReviewQuestionScore)e.Item.DataItem);
                //var rs = (Telerik.Web.UI.RadSlider)e.Item.FindControl("rsQuestion");
                //if (p != null)
                //{
                //    foreach (var i in p.Question.RatingScale.Values)
                //    {
                //        rs.Items.Add(new RadSliderItem(i.Title, i.Value.ToString()));
                //    }
                //    rs.SmallChange = p.Question.RatingScale.Values.Count / 100;
                //}
            }
        }

        protected void ItemDataBound(object o, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var p = ((HRR.Core.Domain.ReviewQuestionScore)e.Item.DataItem);
                var rs = (Telerik.Web.UI.RadSlider)e.Item.FindControl("rsQuestion");
                foreach (var i in p.Question.RatingScale.Values)
                {
                    rs.Items.Add(new RadSliderItem(i.Title, i.Value.ToString()));
                }
                rs.SmallChange = p.Question.RatingScale.Values.Count / 100;
                rs.SelectedValue = p.Score.ToString();
            }
        }

        private void SaveReview()
        {
            if (CurrentReview == null)
            {
                var r = new HRR.Core.Domain.Review();
                r.IsActive = true;
                r.ReviewTemplateID = Convert.ToInt32(ddlTemplate.SelectedValue);
                r.StartDate = (DateTime)tbStartDate.SelectedDate;
                r.Status = 1;
                r.Score = 0;
                r.AccountID = ((Person)SecurityContextManager.Current.CurrentUser).AccountID;
                r.DateCreated = DateTime.Now;
                r.DueDate = (DateTime)tbEndDate.SelectedDate;
                r.Title = CurrentProfile.Name + " - Due: " + r.DueDate.ToShortDateString();
                r.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
                r.EnteredFor = CurrentProfile.ID;
                new ReviewServices().Save(r);

                var a = new Activity();
                a.AccountID = CurrentProfile.AccountID;
                a.ActivityType = (int)ActivityType.NEW_REVIEW;
                a.DateCreated = DateTime.Now;
                a.URL = "/Reviews/" + r.ID.ToString();
                a.PerformedBy = SecurityContextManager.Current.CurrentUser.ID;
                a.PerformedFor = CurrentProfile.ID;
                new ActivityServices().Save(a);

                var t = new ReviewTemplateServices().GetByID(r.ReviewTemplateID);
                foreach (var i in t.Questions)
                {
                    var q = new ReviewQuestionScore();
                    q.Comment = "";
                    q.DateCreated = DateTime.Now;
                    q.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
                    q.Score = 0;
                    q.ReviewID = r.ID;
                    q.ReviewQuestionID = i.ID;
                    new ReviewQuestionScoreServices().Save(q);
                }
                CurrentReview = r;
                //SaveQuestions();
                SendNotification(r);
                Response.Redirect("/Reviews/" + r.ID.ToString());
            }

            SaveQuestions();
            SendNotification(CurrentReview);
            Response.Redirect("/Reviews");
        }

        private void SaveQuestions()
        {
            foreach (DataListItem row in dlQuestions.Items)
            {
                if (row.ItemType == ListItemType.Item || row.ItemType == ListItemType.AlternatingItem)
                {
                    var q = new ReviewQuestionScoreServices().GetByID(Convert.ToInt32(((Telerik.Web.UI.RadSlider)row.FindControl("rsQuestion")).Attributes["itemid"]));
                    q.Comment = ((IdeaSeed.Web.UI.TextBox)row.FindControl("tbComment")).Text;
                    q.Score = Convert.ToInt32(((Telerik.Web.UI.RadSlider)row.FindControl("rsQuestion")).SelectedValue);
                    new ReviewQuestionScoreServices().Save(q);
                }
            }

            var a = new Activity();
            a.AccountID = CurrentProfile.AccountID;
            a.ActivityType = (int)ActivityType.REVIEW_UPDATED;
            a.DateCreated = DateTime.Now;
            a.URL = "/Reviews/" + ((HRR.Core.Domain.Review)Session["CurrentReview"]).ID.ToString();
            a.PerformedBy = SecurityContextManager.Current.CurrentUser.ID;
            a.PerformedFor = CurrentProfile.ID;
            new ActivityServices().Save(a);

            IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();
        }

        private void LoadReview()
        {
            if (CurrentReview != null)
            {
                ddlTemplate.SelectedValue = CurrentReview.ReviewTemplateID.ToString();
                ddlTemplate.Enabled = false;
                tbStartDate.SelectedDate = CurrentReview.StartDate;
                tbStartDate.Enabled = false;
                tbEndDate.SelectedDate = CurrentReview.DueDate;
                tbEndDate.Enabled = false;
                //divQuestions.Visible = true;
                var questions = new ReviewQuestionScoreServices().GetByReviewID(CurrentReview.ID);
                dlQuestions.DataSource = questions;
                dlQuestions.DataBind();
            }
        }

        private void SendNotification(HRR.Core.Domain.Review r)
        {
            string email = "";
            if (r.Managers.Count > 0)
            {
                foreach (var m in r.Managers)
                {
                    email += m.PersonRef.Email + ",";
                }
            }
            var sb = new StringBuilder();
            sb.Append(EmailHelper.EmailHTMLStart());
            sb.Append("<div class='maincontainer'>");
            sb.Append("<h2><span>Review Activity</span></h2>");
            sb.Append("<div class='maincontent'>");
            sb.Append("Click here to view: <a href='");
            sb.Append(ConfigurationManager.AppSettings["BASEURL"]);
            sb.Append("/Reviews/");
            sb.Append(r.ID.ToString());
            sb.Append("'>HRRiver.com</a></div></div>");
            sb.Append(EmailHelper.EmailHTMLEnd());
            try
            {
                IdeaSeed.Core.Mail.EmailUtils.SendEmail(CurrentProfile.Email, "noreply@hrrriver.com", "", email + ConfigurationManager.AppSettings["NEWREVIEWNOTIFICATION"], "You Have New Review Activity", sb.ToString(), false, "");
            }
            catch (Exception exc)
            {

            }
        }

        private void LoadCommentCounts()
        {
            var ct = new CommentServices().GetCommentTotalsByEmployeeID(CurrentProfile.ID, CurrentReview.StartDate.ToShortDateString(), CurrentReview.DueDate.ToShortDateString());
            if (ct != null)
            {
                lblConstructiveLeftFor.InnerHtml = ct.LeftForConstructive.ToString() + " <img src='/images/downh.png' border='0' alt='Constructive' />";
                lblPositiveLeftFor.InnerHtml = ct.LeftForPositive.ToString() + " <img src='/images/uph.png' border='0' alt='Positive' />";
                lblPositiveLeftBy.InnerHtml = ct.LeftByPositive.ToString() + " <img src='/images/uph.png' border='0' alt='Positive' />";
                lblConstructiveLeftBy.InnerHtml = ct.LeftByConstructive.ToString() + " <img src='/images/downh.png' border='0' alt='Constructive' />";
            }
            else
            {
                lblConstructiveLeftFor.InnerHtml = "0 <img src='/images/downh.png' border='0' alt='Constructive' />";
                lblPositiveLeftFor.InnerHtml = "0 <img src='/images/uph.png' border='0' alt='Positive' />";
                lblPositiveLeftBy.InnerHtml = "0 <img src='/images/uph.png' border='0' alt='Positive' />";
                lblConstructiveLeftBy.InnerHtml = "0 <img src='/images/downh.png' border='0' alt='Constructive' />";
            }
        }

        private void ApplySecurity()
        { 
            switch (((Person)SecurityContextManager.Current.CurrentUser).RoleID)
            { 
                case (int)SecurityRole.READ_ONLY:
                case (int)SecurityRole.EMPLOYEE:
                    if (SecurityContextManager.Current.CurrentUser.ID != CurrentReview.EnteredForRef.ID)
                    {
                        Response.Redirect("/Reviews");
                    }
                    break;
                case (int)SecurityRole.MANAGER:
                    if (SecurityContextManager.Current.CurrentUser.ID != CurrentReview.EnteredByRef.ID || SecurityContextManager.Current.CurrentUser.ID != CurrentReview.EnteredForRef.ManagerID)
                    {
                        Response.Redirect("/Reviews");
                    }
                    break;
            }
        }

        #region Managers

        protected void ManagerNeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadManagers(false);
        }

        protected void ManagerItemCreated(object o, GridItemEventArgs e)
        {
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {

                //TableCell cell = new TableCell();
                //RequiredFieldValidator requiredvalidator = new RequiredFieldValidator();
                //CompareValidator comparevalidator = new CompareValidator();

                //cell = (TableCell)(e.Item.FindControl("tbTitle") as IdeaSeed.Web.UI.TextBox).Parent;
                //requiredvalidator.ControlToValidate = (e.Item.FindControl("tbTitle") as IdeaSeed.Web.UI.TextBox).ID;
                //requiredvalidator.InitialValue = "";
                //requiredvalidator.Display = ValidatorDisplay.Dynamic;
                //requiredvalidator.CssClass = "error";
                //requiredvalidator.ErrorMessage = "Enter Scale Title";
                //cell.Controls.Add(requiredvalidator);


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

        protected void ManagerItemDataBound(object o, GridItemEventArgs e)
        {

        }

        protected void ManagerItemCommand(object o, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.InitInsertCommandName)
            {
                e.Canceled = true;
                var i = new HRR.Core.Domain.ReviewManager();
                i.ReviewID = 0;
                i.PersonID = 0;
                i.RecievesNotifications = true;
                i.ID = 0;
                e.Item.OwnerTableView.InsertItem(i);
            }

            if (e.CommandName == RadGrid.PerformInsertCommandName)
            {
                var t = new HRR.Core.Domain.ReviewManager();
                t.RecievesNotifications = (e.Item.FindControl("cbRecievesNotifications") as IdeaSeed.Web.UI.CheckBox).Checked;
                t.PersonID = Convert.ToInt16((e.Item.FindControl("ddlPerson") as HRR.Web.Controls.ManagersDDL).SelectedValue);
                t.ReviewID = CurrentReview.ID;
                new ReviewManagerServices().Save(t); IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();
            }
            if (e.CommandName == RadGrid.UpdateCommandName)
            {
                if (e.Item is GridEditableItem)
                {
                    var t = new ReviewManagerServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                    t.RecievesNotifications = (e.Item.FindControl("cbRecievesNotifications") as IdeaSeed.Web.UI.CheckBox).Checked;
                    new ReviewManagerServices().Save(t); IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();
                }
            }
            if (e.CommandName == RadGrid.DeleteCommandName)
            {
                var t = new ReviewManagerServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                new ReviewManagerServices().Delete(t);
            }
            LoadManagers(true);

        }

        private void LoadManagers(bool bindData)
        {
            if (CurrentReview != null)
            {
                rgManager.DataSource = new ReviewManagerServices().GetByReviewID(CurrentReview.ID);
                if (bindData)
                    rgManager.DataBind();
            }
        }
        #endregion

        #region Notes

        protected void NotesNeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadNotes(false);
        }

        protected void NotesItemCreated(object o, GridItemEventArgs e)
        {
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {

                //TableCell cell = new TableCell();
                //RequiredFieldValidator requiredvalidator = new RequiredFieldValidator();
                //CompareValidator comparevalidator = new CompareValidator();

                //cell = (TableCell)(e.Item.FindControl("tbTitle") as IdeaSeed.Web.UI.TextBox).Parent;
                //requiredvalidator.ControlToValidate = (e.Item.FindControl("tbTitle") as IdeaSeed.Web.UI.TextBox).ID;
                //requiredvalidator.InitialValue = "";
                //requiredvalidator.Display = ValidatorDisplay.Dynamic;
                //requiredvalidator.CssClass = "error";
                //requiredvalidator.ErrorMessage = "Enter Scale Title";
                //cell.Controls.Add(requiredvalidator);


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

        protected void NotesItemDataBound(object o, GridItemEventArgs e)
        {

        }

        protected void NotesItemCommand(object o, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.InitInsertCommandName)
            {
                e.Canceled = true;
                var i = new HRR.Core.Domain.ReviewNote();
                i.ReviewID = 0;
                i.ChangedBy = 0;
                i.DateCreated = DateTime.Now;
                i.EnteredBy = 0;
                i.EnteredFor = 0;
                i.LastUpdated = DateTime.Now;
                i.Message = "";
                i.ID = 0;
                e.Item.OwnerTableView.InsertItem(i);
            }

            if (e.CommandName == RadGrid.PerformInsertCommandName)
            {
                var t = new HRR.Core.Domain.ReviewNote();
                t.Message = (e.Item.FindControl("tbNote") as IdeaSeed.Web.UI.TextBox).Text;
                t.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
                t.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
                t.EnteredFor = CurrentProfile.ID;
                t.LastUpdated = DateTime.Now;
                t.DateCreated = DateTime.Now;
                t.ReviewID = CurrentReview.ID;
                new ReviewNoteServices().Save(t); IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();
            }
            if (e.CommandName == RadGrid.UpdateCommandName)
            {
                if (e.Item is GridEditableItem)
                {
                    var t = new ReviewNoteServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                    t.Message = (e.Item.FindControl("tbNote") as IdeaSeed.Web.UI.TextBox).Text;
                    t.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
                    t.LastUpdated = DateTime.Now;
                    new ReviewNoteServices().Save(t); IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();
                }
            }
            if (e.CommandName == RadGrid.DeleteCommandName)
            {
                var t = new ReviewNoteServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                new ReviewNoteServices().Delete(t);
            }
            LoadNotes(true);

        }

        private void LoadNotes(bool bindData)
        {
            if (CurrentReview != null)
            {
                rgNotes.DataSource = new ReviewNoteServices().GetAllByReview(CurrentReview.ID);
                if (bindData)
                    rgNotes.DataBind();
            }
        }

        #endregion

        protected void CommentsItemDataBound(object o, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var p = ((HRR.Core.Domain.Comment)e.Item.DataItem);
                var lbl = (IdeaSeed.Web.UI.Label)e.Item.FindControl("lblMessage"); var responses = (IdeaSeed.Web.UI.LinkButton)e.Item.FindControl("lbResponseCount");
                responses.Text = p.Communication.Count().ToString() + " responses left";
                if (p.CommentType == -1)
                {
                    if (((Person)SecurityContextManager.Current.CurrentUser).RoleID == (int)SecurityRole.EXECUTIVE_MANAGEMENT || ((Person)SecurityContextManager.Current.CurrentUser).RoleID == (int)SecurityRole.ADMIN)
                    {
                        lbl.Text = p.Message;
                    }
                    else
                    {
                        if (SecurityContextManager.Current.CurrentUser.ID != p.EnteredFor && SecurityContextManager.Current.CurrentUser.ID != p.EnteredBy)
                        {
                            if (((Person)SecurityContextManager.Current.CurrentUser).RoleID < (int)SecurityRole.MANAGER)
                            {
                                ((HtmlGenericControl)e.Item.FindControl("divContainer")).Visible = false;
                                lbl.Text = "<i><b>Contstructive Comment Made</b></i>";
                            }
                            else
                            {
                                if (((Person)SecurityContextManager.Current.CurrentUser).ID == p.EnteredForRef.ManagerID || ((Person)SecurityContextManager.Current.CurrentUser).ID == p.EnteredByRef.ManagerID)
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
                        else
                        {
                            lbl.Text = p.Message;
                        }
                    }
                    ((HtmlGenericControl)e.Item.FindControl("lblEnteredBy")).Visible = false;
                }
                else
                    lbl.Text = p.Message;
            }
        }

        private void LoadComments()
        {
            var list = new CommentServices().GetCommentsForReview(CurrentProfile.ID, CurrentReview.StartDate, CurrentReview.DueDate).OrderByDescending(o => o.DateCreated);
            switch (((Person)SecurityContextManager.Current.CurrentUser).RoleID)
            {
                case (int)SecurityRole.ADMIN:
                case (int)SecurityRole.EXECUTIVE_MANAGEMENT:
                    var mine = from l in list
                               where l.EnteredBy == SecurityContextManager.Current.CurrentProfile.ID ||
                               l.EnteredFor == SecurityContextManager.Current.CurrentProfile.ID
                               orderby l.DateCreated descending
                               select l;
                    dlComments.DataSource = mine;
                    dlComments.DataBind();
                    break;
                case (int)SecurityRole.MANAGER:
                    var team = ((Person)SecurityContextManager.Current.CurrentUser).DepartmentRef.People;
                    var comments = new List<Comment>();
                    foreach (var member in team)
                    {
                        mine = from l in list
                               where l.EnteredBy == member.ID ||
                               l.EnteredFor == member.ID
                               orderby l.DateCreated descending
                               select l;
                        comments.AddRange(mine);
                    }
                    dlComments.DataSource = comments.Distinct();
                    dlComments.DataBind();
                    break;
                default:
                    mine = from l in list
                           where (l.EnteredBy == SecurityContextManager.Current.CurrentUser.ID && l.EnteredFor == SecurityContextManager.Current.CurrentProfile.ID) ||
                           (l.EnteredFor == SecurityContextManager.Current.CurrentUser.ID && l.EnteredBy == SecurityContextManager.Current.CurrentProfile.ID)
                           orderby l.DateCreated descending
                           select l;
                    dlComments.DataSource = mine;
                    dlComments.DataBind();
                    break;
            }

            if (list.Count() > 0)
            {
                rtsReview.Tabs.FindTabByValue("4").Text = "";
                rtsReview.Tabs.FindTabByValue("4").Text += "comments (" + list.Count().ToString() + ")";
            }
            //dlComments.DataSource = list.Distinct();
            //dlComments.DataBind();
        }

        protected void SaveCommentsClicked(object o, EventArgs e)
        {
            foreach (DataListItem row in dlComments.Items)
            {
                if (row.ItemType == ListItemType.Item || row.ItemType == ListItemType.AlternatingItem)
                {
                    var c = new CommentServices().GetByID(Convert.ToInt32(((IdeaSeed.Web.UI.CheckBox)row.FindControl("cbSelected")).Attributes["itemid"]));
                    c.IncludedInReview = ((IdeaSeed.Web.UI.CheckBox)row.FindControl("cbSelected")).Checked;
                    new CommentServices().Save(c);
                }
            }
        }

        protected void ResponseCountClicked(object o, EventArgs e)
        {
            Response.Redirect("/Comments/" + ((LinkButton)o).Attributes["itemid"]);
        }

        protected void ExportToCalendar(object o, EventArgs e)
        {

            string desc = "Click here to view review: " + ConfigurationManager.AppSettings["BASEURL"] + "/Reviews/" + CurrentReview.ID.ToString();
            HttpPageHelper.ExportToCalendar((DateTime)CurrentReview.DueDate, (DateTime)CurrentReview.DueDate, "TBD", desc, "Goal:" + CurrentReview.Title + " is due!!");
        }

        private void LoadTabRecordCount()
        {
            if (CurrentReview.Managers.Count > 0)
            {
                rtsReview.Tabs.FindTabByValue("1").Text = "";
                rtsReview.Tabs.FindTabByValue("1").Text += "managers (" + CurrentReview.Managers.Count.ToString() + ")";
            }
            if (CurrentReview.ReviewQuestionScores.Count > 0)
            {
                rtsReview.Tabs.FindTabByValue("2").Text = "";
                rtsReview.Tabs.FindTabByValue("2").Text += "questions (" + CurrentReview.ReviewQuestionScores.Count.ToString() + ")";
            }
            if (CurrentReview.Goals.Count > 0)
            {
                rtsReview.Tabs.FindTabByValue("3").Text = "";
                rtsReview.Tabs.FindTabByValue("3").Text += "goals (" + CurrentReview.Goals.Count.ToString() + ")";
            }
            if (CurrentReview.Notes.Count > 0)
            {
                rtsReview.Tabs.FindTabByValue("5").Text = "";
                rtsReview.Tabs.FindTabByValue("5").Text += "notes (" + CurrentReview.Notes.Count.ToString() + ")";
            }
        }
    }
}