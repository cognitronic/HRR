using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRR.Core.Domain;
using HRR.Services;
using HRR.Web.Bases;
using IdeaSeed.Core;
using System.Configuration;
using HRR.Core.Security;
using System.Text;
using Telerik.Web.UI;

namespace HRR.Website
{
    public partial class Settings : HRRBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDepartments(true);
                LoadCategories(true);
                LoadGroups(true);
                LoadAccount();
                LoadNotifications(true);
            }
        }

        protected void TabClicked(object o, RadTabStripEventArgs e)
        { 
            
        }

        #region Groups

        protected void AddMemberClicked(object o, EventArgs e)
        {
            Response.Redirect("/Settings/Group/" + ((IdeaSeed.Web.UI.LinkButton)o).Attributes["itemname"].Replace(" ", "-"));
        }

        protected void GroupsItemCreated(object o, GridItemEventArgs e)
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

        protected void GroupsNeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadGroups(false);
        }

        protected void GroupsItemCommand(object o, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.InitInsertCommandName)
            {
                e.Canceled = true;
                var i = new HRR.Core.Domain.Team();
                i.Name = "";
                i.Description = "";
                i.AccountID = ((Person)SecurityContextManager.Current.CurrentUser).AccountID;
                i.ID = 0;
                e.Item.OwnerTableView.InsertItem(i);
            }

            if (e.CommandName == RadGrid.PerformInsertCommandName)
            {
                var t = new HRR.Core.Domain.Team();
                t.Name = (e.Item.FindControl("tbName") as IdeaSeed.Web.UI.TextBox).Text;
                t.Description = (e.Item.FindControl("tbDescription") as IdeaSeed.Web.UI.TextBox).Text;
                t.AccountID = ((Person)SecurityContextManager.Current.CurrentUser).AccountID;
                new TeamServices().Save(t);
                IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();
            }
            if (e.CommandName == RadGrid.UpdateCommandName)
            {
                if (e.Item is GridEditableItem)
                {
                    var t = new TeamServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                    t.Name = (e.Item.FindControl("tbName") as IdeaSeed.Web.UI.TextBox).Text;
                    t.Description = (e.Item.FindControl("tbDescription") as IdeaSeed.Web.UI.TextBox).Text;
                    t.AccountID = ((Person)SecurityContextManager.Current.CurrentUser).AccountID;
                    new TeamServices().Save(t);
                }
            }
            if (e.CommandName == RadGrid.DeleteCommandName)
            {
                var t = new TeamServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                new TeamServices().Delete(t);
            }
            IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();
            LoadGroups(true);
        }



        private void LoadGroups(bool bindData)
        {
            var d = new TeamServices().GetAll();
            rgGroups.DataSource = d;
            if (bindData)
                rgGroups.DataBind();
        }

        #endregion

        #region Departments
        protected void NeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadDepartments(false);
        }

        protected void DepartmentItemCreated(object o, GridItemEventArgs e)
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
                //e.Canceled = true;
                //var i = new HRR.Core.Domain.Department();
                //i.Name = "";
                //i.Description = "";
                //i.AccountID = ((Person)SecurityContextManager.Current.CurrentUser).AccountID;
                //i.ID = 0;
                //e.Item.OwnerTableView.InsertItem(i);
            }

            if (e.CommandName == RadGrid.PerformInsertCommandName)
            {
                var t = new HRR.Core.Domain.Department();
                t.Name = (e.Item.FindControl("tbName") as IdeaSeed.Web.UI.TextBox).Text;
                t.Description = (e.Item.FindControl("tbDescription") as IdeaSeed.Web.UI.TextBox).Text;
                t.AccountID = ((Person)SecurityContextManager.Current.CurrentUser).AccountID;
                new DepartmentServices().Save(t);
            }
            if (e.CommandName == RadGrid.UpdateCommandName)
            {
                if (e.Item is GridEditableItem)
                {
                    var t = new DepartmentServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                    t.Name = (e.Item.FindControl("tbName") as IdeaSeed.Web.UI.TextBox).Text;
                    t.Description = (e.Item.FindControl("tbDescription") as IdeaSeed.Web.UI.TextBox).Text;
                    t.AccountID = ((Person)SecurityContextManager.Current.CurrentUser).AccountID;
                    new DepartmentServices().Save(t);
                }
            }
            if (e.CommandName == RadGrid.DeleteCommandName)
            {
                var t = new DepartmentServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                new DepartmentServices().Delete(t);
            }
            LoadDepartments(true);
        }

        private void LoadDepartments(bool bindData)
        {
            var d = new DepartmentServices().GetAll();
            rgDepartment.DataSource = d;
            if (bindData)
                rgDepartment.DataBind();
        }

#endregion

        #region Categories
        protected void CommentItemCreated(object o, GridItemEventArgs e)
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

        protected void CommentItemCommand(object o, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.InitInsertCommandName)
            {
                //e.Canceled = true;
                //var i = new HRR.Core.Domain.CommentCategory();
                //i.Name = "";
                //i.AccountID = ((Person)SecurityContextManager.Current.CurrentUser).AccountID;
                //i.ID = 0;
                //e.Item.OwnerTableView.InsertItem(i);
            }

            if (e.CommandName == RadGrid.PerformInsertCommandName)
            {
                var t = new HRR.Core.Domain.CommentCategory();
                t.Name = (e.Item.FindControl("tbName") as IdeaSeed.Web.UI.TextBox).Text;
                t.AccountID = ((Person)SecurityContextManager.Current.CurrentUser).AccountID;
                new CommentCategoryServices().Save(t);
            }
            if (e.CommandName == RadGrid.UpdateCommandName)
            {
                if (e.Item is GridEditableItem)
                {
                    var t = new CommentCategoryServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]); t.Name = (e.Item.FindControl("tbName") as IdeaSeed.Web.UI.TextBox).Text;
                    t.AccountID = ((Person)SecurityContextManager.Current.CurrentUser).AccountID;
                    new CommentCategoryServices().Save(t);
                }
            }
            if (e.CommandName == RadGrid.DeleteCommandName)
            {
                var t = new CommentCategoryServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                new CommentCategoryServices().Delete(t);
            }
            //LoadCategories(true);
        }

        protected void CommentNeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadCategories(false);
        }

        private void LoadCategories(bool bindData)
        {
            var l = new CommentCategoryServices().GetAll();
            rgCommentCategories.DataSource = l;
            if (bindData)
                rgCommentCategories.DataBind();
        }

        #endregion

        #region Account Info

        protected void LoadAccount()
        {
            if (SecurityContextManager.Current.CurrentAccount != null)
            {
                tbDomain.Text = SecurityContextManager.Current.CurrentAccount.Domain;
                tbCompanyName.Text = SecurityContextManager.Current.CurrentAccount.Company;
                rbiProfile.DataValue = HRR.Web.Utils.ImageResize.GetImageBytes(SecurityContextManager.Current.CurrentAccount.LogoPath);
                tbCommentsWeight.Text = SecurityContextManager.Current.CurrentAccount.CommentsWeight.ToString();
                tbGoalsWeight.Text = SecurityContextManager.Current.CurrentAccount.GoalsWeight.ToString();
                tbQuestionsWeight.Text = SecurityContextManager.Current.CurrentAccount.QuestionsWeight.ToString();
            }
        }

        protected void SaveAccountClicked(object o, EventArgs e)
        {
            if (SecurityContextManager.Current.CurrentAccount != null)
            {
                var a = new AccountServices().GetByID(SecurityContextManager.Current.CurrentAccount.ID);
                a.Company = tbCompanyName.Text.Replace("-", "_").Replace(",", "_");
                a.Domain = tbDomain.Text;
                a.CommentsWeight = Convert.ToInt16(tbCommentsWeight.Text);
                a.GoalsWeight = Convert.ToInt16(tbGoalsWeight.Text);
                a.QuestionsWeight = Convert.ToInt16(tbQuestionsWeight.Text);
                if (radAsyncUpload.UploadedFiles.Count > 0)
                {
                    UploadedFile file = radAsyncUpload.UploadedFiles[0];
                    string filePath = DateTime.Now.Ticks.ToString() + "_" +
                        file.FileName.Replace(" ", "_").Replace("-", "_").Replace(",", "_");
                    //string filePath = file.FileName;
                    file.SaveAs(Server.MapPath("/Images/companyLogos/") + filePath, false);
                    a.LogoPath = "/Images/companyLogos/" + filePath;
                }
                new AccountServices().Save(a);
                                IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();
                                SecurityContextManager.Current.CurrentAccount = a;
            }
        }

        protected void CancelAccountClicked(object o, EventArgs e)
        {
            Response.Redirect(SecurityContextManager.Current.PreviousURL);
        }
        #endregion

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