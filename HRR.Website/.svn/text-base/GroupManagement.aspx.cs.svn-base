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
    public partial class GroupManagement : HRRBasePage
    {
        private HRR.Core.Domain.Team CurrentTeam
        {
            get
            {
                if (!SecurityContextManager.Current.CurrentURL.Contains("New"))
                {
                    var g = new TeamServices().GetByNameAccountID(HttpContext.Current.Request.Url.Segments[HttpContext.Current.Request.Url.Segments.Count() - 1].Replace("-"," "), ((Person)SecurityContextManager.Current.CurrentUser).AccountID);
                    if (g != null)
                        return g;
                    return null;
                }
                return null;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblGroupTitle.Text = "Manage Team: <span style='color: #ff6600;'>" + CurrentTeam.Name + "</span>";
                LoadManagers(true);
                LoadMember(true);
            }
        }

        protected void ManagementNeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadManagers(false);
        }

        protected void ManagementItemCreated(object o, GridItemEventArgs e)
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

        protected void ManagementItemCommand(object o, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.UpdateCommandName)
            {
                if (e.Item is GridEditableItem)
                {
                    var t = new TeamMemberServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                    //t.IsActive = (e.Item.FindControl("cbIsActive") as IdeaSeed.Web.UI.CheckBox).Checked;
                    t.RecievesNotifications = (e.Item.FindControl("cbRecievesNotifications") as IdeaSeed.Web.UI.CheckBox).Checked;
                    new TeamMemberServices().Save(t);
                }
            }
            if (e.CommandName == RadGrid.DeleteCommandName)
            {
                var t = new TeamMemberServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                new TeamMemberServices().Delete(t);
            }
            IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();
            LoadManagers(true);
        }

        protected void SaveManagerClicked(object o, EventArgs e)
        {
            var m = new TeamMember();
            m.IsActive = true;
            m.IsManager = true;
            m.HasAccess = true;
            m.PersonID = Convert.ToInt32(ddlManager.SelectedValue);
            m.RecievesNotifications = true;
            m.TeamID = CurrentTeam.ID;
            new TeamMemberServices().Save(m);
        IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();
            LoadManagers(true);
        }

        private void LoadManagers(bool bindData)
        {
            var list = new TeamMemberServices().GetByTeamID(CurrentTeam.ID);
            var results = new List<TeamMember>();
            foreach (var m in list)
            {
                if (m.IsManager)
                {
                    results.Add(m);
                }
            }
            rgManagement.DataSource = results;
            if (bindData)
                rgManagement.DataBind();
        }

        #region Members

        protected void MemberNeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadMember(false);
        }

        protected void MemberItemCreated(object o, GridItemEventArgs e)
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

        protected void MemberItemCommand(object o, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.UpdateCommandName)
            {
                if (e.Item is GridEditableItem)
                {
                    var t = new TeamMemberServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                    //t.IsActive = (e.Item.FindControl("cbIsActive") as IdeaSeed.Web.UI.CheckBox).Checked;
                    t.HasAccess = (e.Item.FindControl("cbHasAccess") as IdeaSeed.Web.UI.CheckBox).Checked;
                    t.RecievesNotifications = (e.Item.FindControl("cbRecievesNotifications") as IdeaSeed.Web.UI.CheckBox).Checked;
                    new TeamMemberServices().Save(t);
                    IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();
                }
            }
            if (e.CommandName == RadGrid.DeleteCommandName)
            {
                var t = new TeamMemberServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                new TeamMemberServices().Delete(t);
            }
            LoadMember(true);
        }

        protected void SaveMemberClicked(object o, EventArgs e)
        {
            var m = new TeamMember();
            m.IsActive = true;
            m.IsManager = false;
            m.HasAccess = true;
            m.PersonID = Convert.ToInt32(ddlMembers.SelectedValue);
            m.RecievesNotifications = true;
            m.TeamID = CurrentTeam.ID;
            new TeamMemberServices().Save(m);
            IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();
            LoadMember(true);
        }

        private void LoadMember(bool bindData)
        {
            var list = new TeamMemberServices().GetByTeamID(CurrentTeam.ID);
            var results = new List<TeamMember>();
            foreach (var m in list)
            {
                if (!m.IsManager)
                {
                    results.Add(m);
                }
            }
            rgMembers.DataSource = results;
            if (bindData)
                rgMembers.DataBind();
        }

        #endregion
    }
}