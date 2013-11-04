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
    [ViewStateModeById]
    public partial class GoalMilestoneView : System.Web.UI.UserControl
    {
        private GoalMilestone _milestone = null;
        public GoalMilestone Milestone
        {
            get
            {
                return _milestone;
            }
            set
            {
                _milestone = value;
            }
        }

        private HRR.Core.Domain.Goal CurrentGoal
        {
            get
            {
                return ((HRR.Website.Goal)this.Parent.Page).CurrentGoal;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            LoadMilestone();
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SaveMilestoneClicked(object o, EventArgs e)
        {
            SaveMilestone();
            HttpPageHelper.UpdateTabs((HRR.Website.Goal)this.Parent.Page);
        }

        protected void CancelMilestoneClicked(object o, EventArgs e)
        {

        }

        private void SaveMilestone()
        {
            var m = new GoalMilestone();
            if (Milestone != null)
            {
                m = Milestone;
            }
            else
            {
                m.DateCreated = DateTime.Now;
                m.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
            }
            m.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
            m.LastUpdated = DateTime.Now;
            m.AccountID = SecurityContextManager.Current.CurrentAccount.ID;
            m.Description = tbDescription.Text;
            m.DueDate = (DateTime)tbMilestoneDueDate.SelectedDate;
            m.EmployeeEvaluation = tbSelfEvaluation.Text;
            m.EnteredFor = ((HRR.Website.Goal)this.Parent.Page).CurrentProfile.ID;
            m.GoalID = ((HRR.Website.Goal)this.Parent.Page).CurrentGoal.ID;
            m.IsAccepted = true;
            m.ManagerEvaluation = tbManagerEvaluation.Text;
            m.IsComplete = cbMileStoneCompleted.Checked;
            m.Status = (int)GoalStatus.ACCEPTED;
            m.Title = tbTitle.Text;
            new GoalMilestoneServices().Save(m);
            Milestone = m;
            lblTitle.Text = m.Title;
            this.CurrentGoal.StatusID = ((HRR.Website.Goal)this.Parent.Page).CalculateProgress();
            new GoalServices().Save(this.CurrentGoal);
            IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();
        }

        private void LoadMilestone()
        {
            if (Milestone != null)
            {
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
                        tbManagerEvaluation.ReadOnly = true;
                        tbTitle.ReadOnly = true;
                        tbDescription.ReadOnly = true;
                        tbMilestoneDueDate.DateInput.ReadOnly = true;
                        tbMilestoneDueDate.DatePopupButton.Enabled = false;
                        lbUpdate.Visible = false;
                        lbCancelMilestone.Visible = false;
                    }
                    tbSelfEvaluation.ReadOnly = true;
                }
                else
                {
                    tbManagerEvaluation.ReadOnly = true;
                    tbTitle.ReadOnly = true;
                    tbDescription.ReadOnly = true;
                    tbSelfEvaluation.ReadOnly = false;
                    tbMilestoneDueDate.DateInput.ReadOnly = true;
                    tbMilestoneDueDate.DatePopupButton.Enabled = false;
                    lbUpdate.Visible = false;
                    lbCancelMilestone.Visible = false;
                }

                lblTitle.Text = Milestone.Title;
                tbTitle.Text = Milestone.Title;
                tbMilestoneDueDate.SelectedDate = Milestone.DueDate;
                tbDescription.Text = Milestone.Description;
                tbManagerEvaluation.Text = Milestone.ManagerEvaluation;
                tbSelfEvaluation.Text = Milestone.EmployeeEvaluation;
                cbMileStoneCompleted.Checked = Milestone.IsComplete;
                spnUpdate.Visible = true;
                spnSave.Visible = false;
            }
            else
            {
                spnUpdate.Visible = false;
                spnSave.Visible = true;
                tbTitle.Text = "";
                tbMilestoneDueDate.SelectedDate = null;
                lblTitle.Text = "Untitled";
                tbDescription.Text = "";
                tbManagerEvaluation.Text = "";
                tbSelfEvaluation.Text = "";
                cbMileStoneCompleted.Checked = false;
            }
        }
    }
}