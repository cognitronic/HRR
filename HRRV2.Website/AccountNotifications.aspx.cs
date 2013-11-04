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

namespace HRRV2.Website
{
    public partial class AccountNotifications : HRRBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadNotifications(true); 
            }
        }

        #region Notifications

        protected void NotificationsNeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadNotifications(false);
        }

        protected void NotificationsItemCreated(object o, GridItemEventArgs e)
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

        protected void NotificationsItemCommand(object o, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.InitInsertCommandName)
            {

                //e.Canceled = true;
                //var i = new HRR.Core.Domain.NotificationSubscriber();
                //i.IsActive = false;
                //i.NotificationID = 0;
                //i.PersonID = 0;
                //i.ID = 0;
                //e.Item.OwnerTableView.InsertItem(i);
            }

            if (e.CommandName == RadGrid.PerformInsertCommandName)
            {
                var t = new HRR.Core.Domain.NotificationSubscriber();
                t.NotificationID = Convert.ToInt32((e.Item.FindControl("ddlNotification") as HRR.Web.Controls.NotificationsDDL).SelectedValue);
                t.PersonID = Convert.ToInt32((e.Item.FindControl("ddlSubscriber") as HRR.Web.Controls.ManagersDDL).SelectedValue);
                t.IsActive = (e.Item.FindControl("cbIsActive") as IdeaSeed.Web.UI.CheckBox).Checked;
                t.AccountID = ((Person)SecurityContextManager.Current.CurrentUser).AccountID;
                new NotificationSubscriberServices().Save(t);
            }
            if (e.CommandName == RadGrid.UpdateCommandName)
            {
                if (e.Item is GridEditableItem)
                {
                    var t = new NotificationSubscriberServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                    t.NotificationID = Convert.ToInt32((e.Item.FindControl("ddlNotification") as HRR.Web.Controls.NotificationsDDL).SelectedValue);
                    t.PersonID = Convert.ToInt32((e.Item.FindControl("ddlSubscriber") as HRR.Web.Controls.ManagersDDL).SelectedValue);
                    t.IsActive = (e.Item.FindControl("cbIsActive") as IdeaSeed.Web.UI.CheckBox).Checked;
                    t.AccountID = ((Person)SecurityContextManager.Current.CurrentUser).AccountID;
                    new NotificationSubscriberServices().Save(t);
                }
            }
            if (e.CommandName == RadGrid.DeleteCommandName)
            {
                var t = new NotificationSubscriberServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                new NotificationSubscriberServices().Delete(t);
            }
            LoadNotifications(true);
        }

        private void LoadNotifications(bool bindData)
        {
            var d = new NotificationSubscriberServices().GetAllByAccountID(SecurityContextManager.Current.CurrentAccount.ID);
            rgNotifications.DataSource = d;
            if (bindData)
                rgNotifications.DataBind();
        }
        #endregion
    }
}