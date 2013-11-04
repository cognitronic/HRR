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
using System.Web.Script.Serialization;
using Telerik.Web.UI;

namespace HRRV2.Website
{
    public partial class EditGoal : HRRBasePage
    {
         public HRR.Core.Domain.Goal CurrentGoal
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
        internal Person CurrentProfile
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

        private string _milestoneprogress = "";
        protected string MilestoneProgress
        {
            get
            {
                return _milestoneprogress;
            }
            set
            {
                _milestoneprogress = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadAutoSuggest();
            RadAjaxManager.GetCurrent(this).AjaxRequest +=
                new RadAjaxControl.AjaxRequestDelegate(Goal_AjaxRequest);
            Authenticate();
            InitializePage();
            if (!IsPostBack)
            {
                if (CurrentGoal != null)
                {
                    //ConfigureByStatus();
                    LoadData();
                }
                else
                {
                    CheckForActiveReview();
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
                SecurityContextManager.Current.CurrentProfile = (Person)SecurityContextManager.Current.CurrentUser;
            }
        }

        private void LoadGoal()
        {
            if (CurrentGoal != null)
            {
                tbDescription.Text = CurrentGoal.Description;
                tbTitle.Text = CurrentGoal.Title;
                tbDueDate.SelectedDate = CurrentGoal.DueDate;
                //ddlType.SelectedValue = CurrentGoal.GoalType.ToString();
                rsQuestion.Value = CurrentGoal.Score;
                tbWeight.Text = CurrentGoal.Weight.ToString();
                tbManagerEvaluation.Text = CurrentGoal.ManagerEvaluation;
                tbSelfEvaluation.Text = CurrentGoal.EmployeeEvaluation;
            }
        }

        protected void SaveClicked(object o, EventArgs e)
        {
            SaveGoal();
        }

        protected void SaveResultsClicked(object o, EventArgs e)
        {
            if (CurrentGoal != null)
            {
                CurrentGoal.Score = Convert.ToInt16(rsQuestion.SelectedValue);
                CurrentGoal.EmployeeEvaluation = tbSelfEvaluation.Text;
                CurrentGoal.ManagerEvaluation = tbManagerEvaluation.Text;
                new GoalServices().Save(CurrentGoal);
                IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.ReGet<HRR.Core.Domain.Goal>(CurrentGoal);
            }
        }

        protected void CancelClicked(object o, EventArgs e)
        {
            Response.Redirect(SecurityContextManager.Current.PreviousURL);
        }

        protected void SaveGoal()
        {
            var g = new HRR.Core.Domain.Goal();
            string emails = "";
            if (g.Managers.Count > 0)
            {
                foreach (var m in g.Managers)
                {
                    emails += m.PersonRef.Email + ",";
                }
            }
            if (CurrentGoal == null)
            {
                var r = new ReviewServices().GetEmployeeActiveReview(CurrentProfile.ID);
                g.DateCreated = DateTime.Now;
                g.Description = tbDescription.Text;
                g.AccountID = ((Person)SecurityContextManager.Current.CurrentUser).AccountID;
                g.DueDate = (DateTime)tbDueDate.SelectedDate;
                g.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
                g.EnteredFor = CurrentProfile.ID;
                g.GoalType = 3;
                g.ReviewID = r.ID;
                g.Score = Convert.ToInt16(rsQuestion.SelectedValue);
                g.StatusID = (int)GoalStatus.ACCEPTED;
                g.Progress = CalculateProgress();
                g.IsAccepted = true;
                g.IsApproved = true;
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

                EmailHelper.SendNewGoalNotification(g, emails);
            }
            else
            {
                g = CurrentGoal;
                g.Description = tbDescription.Text;
                g.DueDate = (DateTime)tbDueDate.SelectedDate;
                g.Score = Convert.ToInt16(rsQuestion.SelectedValue);
                g.Progress = CalculateProgress();
                g.Title = tbTitle.Text;
                g.GoalType = 3;
                g.Weight = Convert.ToInt16(tbWeight.Text);
                new GoalServices().Save(g);

                var a = new Activity();
                a.AccountID = CurrentProfile.AccountID;
                a.ActivityType = (int)ActivityType.GOAL_UPDATED;
                a.DateCreated = DateTime.Now;
                a.URL = "/Goals/" + g.ID.ToString();
                a.PerformedBy = SecurityContextManager.Current.CurrentUser.ID;
                a.PerformedFor = CurrentProfile.ID;
                new ActivityServices().Save(a);

                EmailHelper.SendGoalUpdateNotification(g, emails);
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
            if (e.Item is GridDataItem)
            {
                var edit = e.Item.FindControl("lbEdit") as IdeaSeed.Web.UI.LinkButton;
                var delete = e.Item.FindControl("lbDelete") as IdeaSeed.Web.UI.LinkButton;
                if (CurrentGoal.EnteredFor != SecurityContextManager
                        .Current
                        .CurrentUser
                        .ID)
                {
                    var sub = CurrentGoal
                        .Managers
                        .FirstOrDefault(m => m.PersonID == SecurityContextManager
                            .Current
                            .CurrentUser
                            .ID);
                    if (CurrentGoal.EnteredForRef.ManagerID !=
                        SecurityContextManager
                        .Current
                        .CurrentUser
                        .ID &&
                        sub == null)
                    {
                        edit.Visible = false;
                        delete.Visible = false;
                    }

                }
                else
                {
                    edit.Visible = false;
                    delete.Visible = false;
                }
            }
        }

        protected void ManagerItemCreated(object o, GridItemEventArgs e)
        {
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                if (!e.Item.OwnerTableView.IsItemInserted)
                {
                    LinkButton updateButton = (LinkButton)e.Item.FindControl("UpdateButton");
                    updateButton.Text = "Update ";
                    updateButton.CssClass = "btn btn-small btn-info";
                    updateButton.Style["margin-top"] = "15px !important";
                    updateButton.Style["margin-bottom"] = "15px !important";
                }
                else
                {
                    LinkButton insertButton = (LinkButton)e.Item.FindControl("PerformInsertButton");
                    insertButton.Text = "Insert";
                    insertButton.CssClass = "btn btn-small btn-info";
                    insertButton.Style["margin-top"] = "15px !important";
                    insertButton.Style["margin-bottom"] = "15px !important";
                }
                LinkButton cancelButton = (LinkButton)e.Item.FindControl("CancelButton");
                cancelButton.Text = "Cancel";
                cancelButton.CssClass = "btn btn-small btn-danger";
                cancelButton.Style["margin-top"] = "15px !important";
                cancelButton.Style["margin-bottom"] = "15px !important";
            }
        }

        protected void ManagerItemCommand(object o, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.InitInsertCommandName)
            {
                //e.Canceled = true;
                //var i = new HRR.Core.Domain.GoalManager();
                //i.GoalID = 0;
                //i.PersonID = 0;
                //i.RecievesNotifications = true;
                //i.ID = 0;
                //e.Item.OwnerTableView.InsertItem(i);
            }

            if (e.CommandName == RadGrid.PerformInsertCommandName)
            {
                var t = new HRR.Core.Domain.GoalManager();
                t.RecievesNotifications = (e.Item.FindControl("cbRecievesNotifications") as IdeaSeed.Web.UI.CheckBox).Checked;
                t.PersonID = Convert.ToInt16((e.Item.FindControl("ddlPerson") as HRR.Web.Controls.ManagersDDL).SelectedValue);
                t.GoalID = CurrentGoal.ID;
                new GoalManagerServices().Save(t);
                Response.Redirect(SecurityContextManager.Current.CurrentURL);
                //HttpPageHelper.UpdateTabs(this);
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

        //protected void NeedDataSource(object o, GridNeedDataSourceEventArgs e)
        //{
        //    LoadMilestones(false);
        //}

        bool createAgain = false;
        IList<HRRV2.Website.Views.GoalMilestoneView> MilestoneControls
        {
            get
            {
                if (SessionManager.Current["milestone_controls"] != null)
                    return (IList<HRRV2.Website.Views.GoalMilestoneView>)SessionManager.Current["milestone_controls"];
                else
                    SessionManager.Current["milestone_controls"] = new List<HRRV2.Website.Views.GoalMilestoneView>();
                return (IList<HRRV2.Website.Views.GoalMilestoneView>)SessionManager.Current["milestone_controls"];
            }
            set
            {
                SessionManager.Current["milestone_controls"] = value;
            }
        }

        private Control FindControlRecursive(Control root, string id)
        {
            if (root.ID == id)
            {
                return root;
            }
            foreach (Control c in root.Controls)
            {
                Control t = FindControlRecursive(c, id);
                if (t != null)
                {
                    return t;
                }
            }
            return null;
        }

        protected Control GetPostBackControl(System.Web.UI.Page page)
        {
            Control control = null;
            string ctrlname = Page.Request.Params["__EVENTTARGET"];
            if (ctrlname != null && ctrlname != String.Empty && !ctrlname.Contains("lbLogout") && ctrlname.Split('$').Length > 1)
            {
                //crtlname must contain the id of the control inside my usercontrol that caused the postback
                if (ctrlname.Contains("SaveMilestone"))
                {
                    var c = new Control();
                    c.ID = ctrlname;
                    return c;
                }
                else
                {
                    if (ctrlname.Split('$').Length > 2)
                        control = FindControlRecursive(page, ctrlname.Split('$')[2]);
                }
            }
            else
            {
                string ctrlStr = String.Empty;
                Control c = null;
                foreach (string ctl in Page.Request.Form)
                {
                    if (ctl.EndsWith(".x") || ctl.EndsWith(".y"))
                    {
                        ctrlStr = ctl.Substring(0, ctl.Length - 2);
                        c = page.FindControl(ctrlStr);
                    }
                    else
                    {
                        c = page.FindControl(ctl);
                    }
                    if (c is System.Web.UI.WebControls.CheckBox ||
                    c is System.Web.UI.WebControls.CheckBoxList)
                    {
                        control = c;
                        break;
                    }
                }
            }
            return control;
        }

        protected void CreateUserControl(string controlID)
        {
            try
            {
                if (controlID.Contains("Update"))
                {
                    if (createAgain && divMilestonesContainer != null)
                    {
                        if (MilestoneControls.Count > 0)
                        {
                            divMilestonesContainer.Controls.Clear();
                            foreach (var ms in CurrentGoal.Milestones.OrderBy(o => o.DueDate))
                            {
                                Control c = LoadControl("/Views/GoalMilestoneView.ascx");
                                ((HRRV2.Website.Views.GoalMilestoneView)c).Milestone = ms;
                                divMilestonesContainer.Controls.Add(c);
                            }
                        }
                    }
                }
                else
                {
                    if (createAgain && divMilestonesContainer != null)
                    {
                        if (MilestoneControls.Count > 0)
                        {
                            divMilestonesContainer.Controls.Clear();
                            foreach (var c in MilestoneControls)
                            {
                                HRRV2.Website.Views.GoalMilestoneView foc = new HRRV2.Website.Views.GoalMilestoneView();
                                foc = Page.LoadControl("~/Views/GoalMilestoneView.ascx") as HRRV2.Website.Views.GoalMilestoneView;
                                foc.ID = c.ID;
                                divMilestonesContainer.Controls.Add(foc);
                            }
                            foreach (var ms in CurrentGoal.Milestones.OrderBy(o => o.DueDate))
                            {
                                Control c = LoadControl("/Views/GoalMilestoneView.ascx");
                                ((HRRV2.Website.Views.GoalMilestoneView)c).Milestone = ms;
                                divMilestonesContainer.Controls.Add(c);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void AddMilestoneClicked(object o, EventArgs e)
        {
            //divMilestoneContainer.Controls.Clear();
            //Control c = LoadControl("/Views/GoalMilestoneView.ascx");
            //c.ID = "milestones" + MilestoneControls.Count.ToString();
            //MilestoneControls = null;
            //MilestoneControls.Add((HRR.Website.Views.GoalMilestoneView)c);
            //divMilestoneContainer.Controls.Add(c);
            //CreateUserControl("lbAddNewMilestone");
            var ms = new GoalMilestone();
            ms.AccountID = SecurityContextManager.Current.CurrentUser.AccountID;
            ms.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
            ms.DateCreated = DateTime.Now;
            ms.Description = tbMilestoneDescription.Text;
            ms.DueDate = (DateTime)tbMilestoneDueDate.SelectedDate;
            ms.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
            ms.EnteredFor = CurrentProfile.ID;
            ms.GoalID = CurrentGoal.ID;
            ms.IsAccepted = true;
            ms.IsComplete = false;
            ms.LastUpdated = DateTime.Now;
            ms.Status = (int)GoalStatus.ACCEPTED;
            ms.Title = tbMilestoneTitle.Text;
            new GoalMilestoneServices().Save(ms);
            HttpPageHelper.UpdateTabs(this);
            tbMilestoneTitle.Text = "";
            tbMilestoneDueDate.SelectedDate = null;
            tbMilestoneDueDate.DateInput.Text = "";
            tbMilestoneDescription.Text = "";
            LoadMilestones(true);
        }

        internal void LoadMilestones(bool bindData)
        {
            if (CurrentGoal != null)
            {
                //MilestoneControls = null;
                //foreach (var ms in CurrentGoal.Milestones.OrderBy(o => o.DueDate))
                //{
                //    Control c = LoadControl("/Views/GoalMilestoneView.ascx");
                //    ((HRR.Website.Views.GoalMilestoneView)c).Milestone = ms;
                //    MilestoneControls.Add(((HRR.Website.Views.GoalMilestoneView)c));
                //    divMilestoneContainer.Controls.Add(c);
                //}
                //rgMilestones.DataSource = new GoalMilestoneServices().GetByGoalID(CurrentGoal.ID).OrderBy(o => o.DueDate);
                //if (bindData)
                //    rgMilestones.DataBind();

                dlMilestones.DataSource = new GoalMilestoneServices().GetByGoalID(CurrentGoal.ID).OrderBy(d => d.DueDate);
                dlMilestones.DataBind();

                dlMilestoneDueDates.DataSource = new GoalMilestoneServices().GetByGoalID(CurrentGoal.ID).OrderBy(d => d.DueDate);
                dlMilestoneDueDates.DataBind();
            }
        }

        protected void UpdateMilestoneClicked(object o, EventArgs e)
        {
            var milestone = new GoalMilestoneServices().GetByID(Convert.ToInt32(((LinkButton)o).Attributes["itemid"]));
        }

        protected void MilestonesItemCommand(object o, DataListCommandEventArgs e)
        {
            if (e.CommandName == "updatems")
            {
                var lb = e.Item.FindControl("lbUpdate") as LinkButton;
                var ms = new GoalMilestoneServices().GetByID(Convert.ToInt32(lb.Attributes["itemid"]));
                ms.DueDate = (DateTime)((RadDatePicker)e.Item.FindControl("tbMilestoneDueDate")).SelectedDate;
                ms.Description = ((IdeaSeed.Web.UI.TextBox)e.Item.FindControl("tbMilestoneDescription")).Text;
                ms.Title = ((IdeaSeed.Web.UI.TextBox)e.Item.FindControl("tbMilestoneTitle")).Text;
                ms.ManagerEvaluation = ((IdeaSeed.Web.UI.TextBox)e.Item.FindControl("tbManagerEvaluation")).Text;
                ms.EmployeeEvaluation = ((IdeaSeed.Web.UI.TextBox)e.Item.FindControl("tbSelfEvaluation")).Text;
                ms.IsComplete = ((IdeaSeed.Web.UI.CheckBox)e.Item.FindControl("cbMilestoneCompleted")).Checked;
                ms.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
                ms.LastUpdated = DateTime.Now;
                new GoalMilestoneServices().Save(ms);
                CurrentGoal.Progress = CalculateProgress();
                new GoalServices().Save(CurrentGoal);
                LoadData();
            }
            if (e.CommandName == "delete")
            {
                var lb = e.Item.FindControl("lbDeleteMilestone") as LinkButton;
                var ms = new GoalMilestoneServices().GetByID(Convert.ToInt32(lb.Attributes["itemid"]));
                new GoalMilestoneServices().Delete(ms);
                Response.Redirect(SecurityContextManager.Current.CurrentURL);
            }
        }

        protected void MilestonesItemDataBound(object o, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //var p = ((HRR.Core.Domain.GoalCommunication)e.Item.DataItem);

                var duedate = (Telerik.Web.UI.RadDatePicker)e.Item.FindControl("tbMilestoneDueDate");
                var iscomplete = (IdeaSeed.Web.UI.CheckBox)e.Item.FindControl("cbMilestoneCompleted");
                var title = (IdeaSeed.Web.UI.TextBox)e.Item.FindControl("tbMilestoneTitle");
                var description = (IdeaSeed.Web.UI.TextBox)e.Item.FindControl("tbMilestoneDescription");
                var managereval = (IdeaSeed.Web.UI.TextBox)e.Item.FindControl("tbManagerEvaluation");
                var selfeval = (IdeaSeed.Web.UI.TextBox)e.Item.FindControl("tbSelfEvaluation");
                var update = (IdeaSeed.Web.UI.LinkButton)e.Item.FindControl("lbUpdate");
                var delete = (IdeaSeed.Web.UI.LinkButton)e.Item.FindControl("lbDeleteMilestone");
                //var div = e.Item.FindControl("divTitle") as HtmlGenericControl;
                //div.Attributes["paneltitle"] = ((GoalMilestone)e.Item.DataItem).Title;
                if (CurrentGoal.EnteredFor != SecurityContextManager
                        .Current
                        .CurrentUser
                        .ID)
                {
                    var sub = CurrentGoal
                       .Managers
                       .FirstOrDefault(m => m.PersonID == SecurityContextManager
                           .Current
                           .CurrentUser
                           .ID);
                    if (CurrentGoal.EnteredForRef.ManagerID !=
                        SecurityContextManager
                        .Current
                        .CurrentUser
                        .ID &&
                        sub == null)
                    {
                        managereval.ReadOnly = true;
                        title.ReadOnly = true;
                        description.ReadOnly = true;
                        duedate.DateInput.ReadOnly = true;
                        duedate.DatePopupButton.Enabled = false;
                        update.Visible = false;
                        delete.Visible = false;
                    }
                    tbSelfEvaluation.ReadOnly = true;
                }
                else
                {
                    managereval.ReadOnly = true;
                    title.ReadOnly = true;
                    description.ReadOnly = true;
                    tbSelfEvaluation.ReadOnly = false;
                    duedate.DateInput.ReadOnly = true;
                    duedate.DatePopupButton.Enabled = false;
                    //update.Visible = false;
                    delete.Visible = false;
                }
            }
        }

        protected void MilestoneDueDatesItemDataBound(object o, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //var p = ((HRR.Core.Domain.GoalCommunication)e.Item.DataItem);

                var duedate = (Telerik.Web.UI.RadDatePicker)e.Item.FindControl("tbDueDate");
                
                
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

        protected void SaveCommunicationClicked(object o, EventArgs e)
        {
            SaveComment();
            IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();
            LoadComments();
            LoadTabRecordCount();
            tbNewComment.Text = "";
        }

        protected void CancelCommentClicked(object o, EventArgs e)
        {

        }

        private void LoadComments()
        {
            dlComments.DataSource = null;
            dlComments.DataBind();

            var list = new GoalCommunicationServices().GetByGoalID(CurrentGoal.ID).OrderByDescending(o => o.DateCreated);
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
            HttpPageHelper.UpdateTabs(this);

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
                if(m.RecievesNotifications)
                    emails += m.PersonRef.Email + ",";
            }

            EmailHelper.SendGoalCommentUpdateNotification(CurrentGoal, emails);

            
        }
        #endregion

        protected void TabClicked(object o, RadTabStripEventArgs e)
        {
            CalculateProgress();
        }

        public void LoadTabRecordCount()
        {
            if (CurrentGoal.Managers.Count > 0)
            {
                lblTabSubscribers.Text = "";
                lblTabSubscribers.Text += "subscribers <span class='badge badge-warning'>" + CurrentGoal.Managers.Count.ToString() + "</span>";
            }
            if (CurrentGoal.Milestones.Count > 0)
            {
                UpdateProgressIndicator();
                lblTabMilestone.Text = "";
                lblTabMilestone.Text += "Milestones <span class='badge badge-warning'>" + CurrentGoal.Milestones.Count.ToString() + "</span>";
            }
            if (CurrentGoal.Communication.Count > 0)
            {
                lblTabCommunication.Text = "";
                lblTabCommunication.Text += "Communication <span class='badge badge-warning'>" + CurrentGoal.Communication.Count.ToString() + "</span>";
            }
        }

        protected void ExportToCalendar(object o, EventArgs e)
        {

            string desc = "Click here to view goal: " + ConfigurationManager.AppSettings["BASEURL"] + "/Goals/" + CurrentGoal.ID.ToString();
            HttpPageHelper.ExportToCalendar((DateTime)CurrentGoal.DueDate, (DateTime)CurrentGoal.DueDate, "TBD", desc, "Goal:" + CurrentGoal.Title + " is due!!");
        }

        protected override void OnInit(EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    MilestoneControls = null;
            //}
            //base.OnInit(e);
            //Control control = GetPostBackControl(this);
            //if (control != null)
            //{
            //    if ((createAgain) || control.ID.Contains("NewMilestone") || control.ID.Contains("SaveMilestone"))
            //    {
            //        createAgain = true;
            //        CreateUserControl(control.ID);
            //    }
            //}
        }

        void Goal_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {
            if (e.Argument == "server")
            {
                IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();
                LoadTabRecordCount();
            }
        }

        private void InitializePage()
        {
            if (CurrentGoal == null)
            {
                lblName.Text = "New Goal";
                this.CurrentProfile = new PersonServices().GetByID(Convert.ToInt32(HttpContext.Current.Request.Url.Segments[HttpContext.Current.Request.Url.Segments.Count() - 1]));
                
            }
            else
            {
                AuthorizeAccount(CurrentGoal.EnteredByRef.AccountID);
                lblName.Text = "Goal - " + CurrentGoal.Title;
                this.CurrentProfile = CurrentGoal.EnteredForRef;
                if (CurrentGoal.EnteredFor != SecurityContextManager
                        .Current
                        .CurrentUser
                        .ID)
                {
                    var sub = CurrentGoal
                        .Managers
                        .FirstOrDefault(m => m.PersonID == SecurityContextManager
                            .Current
                            .CurrentUser
                            .ID);
                    if (CurrentGoal.EnteredForRef.ManagerID !=
                        SecurityContextManager
                        .Current
                        .CurrentUser
                        .ID &&
                        sub == null)
                    {
                        rsQuestion.Enabled = false;
                        tbManagerEvaluation.Enabled = false;
                        lbAddNewMilestone.Visible = false;
                        tbSelfEvaluation.Enabled = false;
                        tbDueDate.DateInput.Enabled = false;
                        tbDueDate.DatePopupButton.Enabled = false;
                        tbDescription.Enabled = false;
                        tbTitle.Enabled = false;
                        lbSaveGoal.Visible = false;
                        //lbSaveComment.Visible = false;
                        lbSaveResults.Visible = false;
                        lbCancel.Visible = false;
                        lbCancelComment.Visible = false;
                        lbCancelResults.Visible = false;
                        
                    }
                    tbSelfEvaluation.Enabled = false;

                }
                else
                {
                    if (CurrentGoal.EnteredBy != SecurityContextManager
                        .Current
                        .CurrentUser
                        .ID)
                    {
                        lbAddNewMilestone.Visible = false;
                        tbDueDate.DateInput.Enabled = false;
                        tbDueDate.DatePopupButton.Enabled = false;
                        tbDescription.Enabled = false;
                        tbTitle.Enabled = false;
                        tbSelfEvaluation.Enabled = true;
                        lbSaveGoal.Visible = false;
                        //lbSaveComment.Visible = false;
                        //lbSaveResults.Visible = false;
                        lbCancel.Visible = false;
                        lbCancelComment.Visible = false;
                        lbCancelResults.Visible = false;
                    }
                    rsQuestion.Enabled = false;
                    tbManagerEvaluation.Enabled = false;
                }
            }
        }

        private void ConfigureByStatus()
        {
            //if (CurrentGoal.IsAccepted)
            //    lbAccept.Visible = false;
            //if (CurrentGoal.IsApproved)
            //    lbApprove.Visible = false;
        }

        private void Authenticate()
        {
            switch (((Person)SecurityContextManager.Current.CurrentUser).RoleID)
            {
                case (int)SecurityRole.READ_ONLY:
                case (int)SecurityRole.EMPLOYEE:
                    if (CurrentGoal.EnteredFor != SecurityContextManager
                        .Current
                        .CurrentUser
                        .ID)
                        Response.Redirect(SecurityContextManager.Current.PreviousURL);

                    if (CurrentGoal.EnteredBy != SecurityContextManager
                        .Current
                        .CurrentUser
                        .ID)
                    {
                        //lbApprove.Visible = false;
                        lbSaveGoal.Visible = false;
                        rgManager.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    }
                    break;
                case (int)SecurityRole.MANAGER:
                case (int)SecurityRole.EXECUTIVE_MANAGEMENT:
                    var sub = CurrentGoal
                        .Managers
                        .FirstOrDefault(m => m.PersonID == SecurityContextManager
                            .Current
                            .CurrentUser
                            .ID);
                    if (CurrentGoal.EnteredFor != SecurityContextManager
                        .Current
                        .CurrentUser
                        .ID)
                    {
                        if (CurrentGoal.EnteredForRef.ManagerID !=
                            SecurityContextManager
                            .Current
                            .CurrentUser
                            .ID &&
                            sub == null)
                            Response.Redirect(SecurityContextManager.Current.PreviousURL);
                    }
                    else
                    {
                        rgManager.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    }
                    break;
            }
        }

        private void LoadData()
        {
            LoadGoal();
            LoadMilestones(true);
            LoadComments();
            LoadManagers(true);
            LoadTabRecordCount();
            divCommunicationContainer.Visible = true;
            divMilestonesContainer.Visible = true;
        }

        private void CheckForActiveReview()
        {
            if (this.CurrentProfile.Reviews.Count() < 1 || !this.CurrentProfile.Reviews[0].IsActive)
            {
                msgContainer.Visible = true;
                var sb = new StringBuilder();
                sb.Append("<span class='error' style='margin-top: 30px;'>This user does not have an active review.  Please add a new review <a href='/Reviews/New/" + this.CurrentProfile.ID.ToString() + "'>Here</a></span>");
                msgContainer.InnerHtml = sb.ToString();
                lbSaveGoal.Visible = false;
            }
            else
            {
                lbSaveGoal.Visible = true;
                msgContainer.Visible = false;
            }
            divCommunicationContainer.Visible = false;
            divMilestonesContainer.Visible = false;
        }

        internal int CalculateProgress()
        {
            int result = 0;
            if (CurrentGoal != null)
            {
                var complete = CurrentGoal.Milestones.Where(o => o.IsComplete == true);
                if (complete.Count() > 0)
                {
                    result = ((complete.Count() * 100) / CurrentGoal.Milestones.Count());
                }
            }
            return result;
        }

        private void UpdateProgressIndicator()
        {
            MilestoneProgress = CurrentGoal.Progress.ToString();
            lblProgressText.Text = MilestoneProgress + "% complete";
        }

        private void LoadAutoSuggest()
        {
            List<HRR.Core.Domain.Interfaces.IAutoSuggestRecipient> list = new MessageServices().GetAutoSuggestRecipients();

            note_name.DataSource = list;
            note_name.DataTextField = "Name";
            note_name.DataValueField = "Email";
        }

        protected void SaveCloneGoalClicked(object o, EventArgs e)
        {
            for (int i = 0; i < note_name.Entries.Count; i++)
            {
                if (note_name.Entries[i].Value.StartsWith("team:"))
                {
                    var t = new TeamServices().GetByID(Convert.ToInt32(note_name.Entries[i].Value.Replace("team:", "")));
                    foreach (var m in t.Members)
                    {
                        var goal = new Goal();
                        goal.AccountID = CurrentGoal.AccountID;
                        goal.Description = CurrentGoal.Description;
                        goal.IsAccepted = true;
                        goal.Name = CurrentGoal.Name;
                        goal.ReviewID = CurrentGoal.ReviewID;
                        goal.StatusID = CurrentGoal.StatusID;
                        goal.Title = CurrentGoal.Title;
                        goal.TypeOfItem = CurrentGoal.TypeOfItem;
                        goal.Weight = CurrentGoal.Weight;
                        goal.DueDate = (DateTime)tbCloneGoalDueDate.DateInput.SelectedDate;
                        goal.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
                        goal.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
                        goal.DateCreated = DateTime.Now;
                        goal.LastUpdated = DateTime.Now;
                        goal.EnteredFor = m.PersonID;
                        goal.IsTemplate = false;
                        goal.Progress = 0;
                        goal.Score = 0;
                        goal.EmployeeEvaluation = "";
                        goal.ManagerEvaluation = "";
                        new GoalServices().Save(goal);

                        foreach (DataListItem row in dlMilestoneDueDates.Items)
                        {
                            var date = row.FindControl("tbDueDate") as Telerik.Web.UI.RadDatePicker;
                            var oldms = new GoalMilestoneServices().GetByID(Convert.ToInt32(date.Attributes["milestoneid"]));
                            var ms = new GoalMilestone();
                            ms.AccountID = oldms.AccountID;
                            ms.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
                            ms.Description = oldms.Description;
                            ms.EmployeeEvaluation = "";
                            ms.ManagerEvaluation = "";
                            ms.Name = oldms.Name;
                            ms.Status = (int)GoalStatus.ACCEPTED;
                            ms.Title = oldms.Title;
                            ms.DateCreated = DateTime.Now;
                            ms.DueDate = (DateTime)date.SelectedDate;
                            ms.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
                            ms.EnteredFor = m.PersonID;
                            ms.GoalID = goal.ID;
                            ms.IsAccepted = true;
                            ms.IsComplete = false;
                            ms.LastUpdated = DateTime.Now;
                            new GoalMilestoneServices().Save(ms);

                        }

                        foreach (var s in CurrentGoal.Managers)
                        {
                            var subscriber = new GoalManager();
                            subscriber.GoalID = goal.ID;
                            subscriber.PersonID = s.PersonID;
                            subscriber.RecievesNotifications = s.RecievesNotifications;
                            new GoalManagerServices().Save(subscriber);
                        }
                    }
                }
                else
                {
                    var p = new PersonServices().GetByEmail(note_name.Entries[i].Value);

                    var goal = new Goal();
                    goal.AccountID = CurrentGoal.AccountID;
                    goal.Description = CurrentGoal.Description;
                    goal.IsAccepted = true;
                    goal.Name = CurrentGoal.Name;
                    goal.ReviewID = CurrentGoal.ReviewID;
                    goal.StatusID = CurrentGoal.StatusID;
                    goal.Title = CurrentGoal.Title;
                    goal.TypeOfItem = CurrentGoal.TypeOfItem;
                    goal.Weight = CurrentGoal.Weight;
                    goal.DueDate = (DateTime)tbCloneGoalDueDate.DateInput.SelectedDate;
                    goal.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
                    goal.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
                    goal.DateCreated = DateTime.Now;
                    goal.LastUpdated = DateTime.Now;
                    goal.EnteredFor = p.ID;
                    goal.IsTemplate = false;
                    goal.Progress = 0;
                    goal.Score = 0;
                    goal.EmployeeEvaluation = "";
                    goal.ManagerEvaluation = "";
                    new GoalServices().Save(goal);

                    foreach (DataListItem row in dlMilestoneDueDates.Items)
                    {
                        var date = row.FindControl("tbDueDate") as Telerik.Web.UI.RadDatePicker;
                        var oldms = new GoalMilestoneServices().GetByID(Convert.ToInt32(date.Attributes["milestoneid"]));
                        var ms = new GoalMilestone();
                        ms = oldms;
                        ms.DateCreated = DateTime.Now;
                        ms.DueDate = (DateTime)date.SelectedDate;
                        ms.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
                        ms.EnteredFor = p.ID;
                        ms.GoalID = goal.ID;
                        ms.IsAccepted = true;
                        ms.IsComplete = false;
                        ms.LastUpdated = DateTime.Now;
                        new GoalMilestoneServices().Save(ms);

                    }

                    foreach (var s in CurrentGoal.Managers)
                    {
                        var subscriber = new GoalManager();
                        subscriber.GoalID = goal.ID;
                        subscriber.PersonID = s.PersonID;
                        subscriber.RecievesNotifications = s.RecievesNotifications;
                        new GoalManagerServices().Save(subscriber);
                    }
                }

            }
            Response.Redirect(SecurityContextManager.Current.CurrentURL);
        }
    }
}