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
    public partial class Blogs : HRRBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (((Person)SecurityContextManager.Current.CurrentUser).RoleID < (int)SecurityRole.ADMIN || SecurityContextManager.Current.PreviousURL.Contains("/Blogs/"))
                {
                    Response.Redirect("/Overview");
                }

                LoadBlogs(true);
                LoadCategories(true);
            }
        }

        protected void NeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadBlogs(false);
        }

        private void LoadBlogs(bool bindData)
        {
            var list = new BlogServices().GetAllByAccount();
            rgList.DataSource = list;
            if (bindData)
                rgList.DataBind();
        }

        protected void ItemCommand(object o, GridCommandEventArgs e)
        {

            if (e.CommandName == RadGrid.InitInsertCommandName)
            {
                e.Canceled = true;
                var i = new HRR.Core.Domain.Blog();
                i.Title = "";
                i.AccountID = 0;
                i.BlogCategoryID = 0;
                i.BlogContent = "";
                i.EndDate = DateTime.Now;
                i.EnteredBy = 0;
                i.IsActive = false;
                i.StartDate = DateTime.Now;
                i.ID = 0;
                e.Item.OwnerTableView.InsertItem(i);
            }

            if (e.CommandName == RadGrid.PerformInsertCommandName)
            {
                var t = new HRR.Core.Domain.Blog();
                t.Title = (e.Item.FindControl("tbTitle") as IdeaSeed.Web.UI.TextBox).Text;
                t.BlogCategoryID = Convert.ToInt16((e.Item.FindControl("ddlCategory") as HRR.Web.Controls.BlogCategoryDDL).SelectedValue);
                t.BlogContent = (e.Item.FindControl("reContent") as Telerik.Web.UI.RadEditor).Content;
                t.EndDate = (DateTime)(e.Item.FindControl("tbEndDate") as Telerik.Web.UI.RadDatePicker).SelectedDate;
                t.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
                t.IsActive = (e.Item.FindControl("cbIsActive") as IdeaSeed.Web.UI.CheckBox).Checked;
                t.StartDate = (DateTime)(e.Item.FindControl("tbStartDate") as Telerik.Web.UI.RadDatePicker).SelectedDate;
                t.AccountID = ((Person)SecurityContextManager.Current.CurrentUser).AccountID;
                new BlogServices().Save(t);
            }
            if (e.CommandName == RadGrid.UpdateCommandName)
            {
                if (e.Item is GridEditableItem)
                {
                    var t = new BlogServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                    t.Title = (e.Item.FindControl("tbTitle") as IdeaSeed.Web.UI.TextBox).Text;
                    t.BlogCategoryID = Convert.ToInt16((e.Item.FindControl("ddlCategory") as HRR.Web.Controls.BlogCategoryDDL).SelectedValue);
                    t.BlogContent = (e.Item.FindControl("reContent") as Telerik.Web.UI.RadEditor).Content;
                    t.EndDate = (DateTime)(e.Item.FindControl("tbEndDate") as Telerik.Web.UI.RadDatePicker).SelectedDate;
                    t.IsActive = (e.Item.FindControl("cbIsActive") as IdeaSeed.Web.UI.CheckBox).Checked;
                    t.StartDate = (DateTime)(e.Item.FindControl("tbStartDate") as Telerik.Web.UI.RadDatePicker).SelectedDate;
                    new BlogServices().Save(t);
                }
            }
            if (e.CommandName == RadGrid.DeleteCommandName)
            {
                var t = new BlogServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                new BlogServices().Delete(t);
            }
            IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();
            LoadBlogs(true);
        }

        protected void ItemCreated(object o, GridItemEventArgs e)
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

        #region Categories

        protected void CategoryNeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadCategories(false);
        }

        private void LoadCategories(bool bindData)
        {
            var list = new BlogCategoryServices().GetAllByAccount();
            rgCategories.DataSource = list;
            if (bindData)
                rgCategories.DataBind();
        }

        protected void CategoryItemCommand(object o, GridCommandEventArgs e)
        {

            if (e.CommandName == RadGrid.InitInsertCommandName)
            {
                e.Canceled = true;
                var i = new HRR.Core.Domain.BlogCategory();
                i.Name = "";
                i.AccountID = 0;
                i.Description = "";
                i.ID = 0;
                e.Item.OwnerTableView.InsertItem(i);
            }

            if (e.CommandName == RadGrid.PerformInsertCommandName)
            {
                var t = new HRR.Core.Domain.BlogCategory();
                t.Name = (e.Item.FindControl("tbName") as IdeaSeed.Web.UI.TextBox).Text;
                t.Description = (e.Item.FindControl("tbDescription") as IdeaSeed.Web.UI.TextBox).Text;
                t.AccountID = ((Person)SecurityContextManager.Current.CurrentUser).AccountID;
                new BlogCategoryServices().Save(t);
            }
            if (e.CommandName == RadGrid.UpdateCommandName)
            {
                if (e.Item is GridEditableItem)
                {
                    var t = new BlogCategoryServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                    t.Name = (e.Item.FindControl("tbName") as IdeaSeed.Web.UI.TextBox).Text;
                    t.Description = (e.Item.FindControl("tbDescription") as IdeaSeed.Web.UI.TextBox).Text;
                    new BlogCategoryServices().Save(t);
                }
            }
            if (e.CommandName == RadGrid.DeleteCommandName)
            {
                var t = new BlogCategoryServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                new BlogCategoryServices().Delete(t);
            }
            //IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();
            //LoadCategories(true);
        }

        protected void CategoryItemCreated(object o, GridItemEventArgs e)
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

        #endregion
    }
}