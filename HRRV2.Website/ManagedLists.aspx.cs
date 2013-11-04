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
    public partial class ManagedLists : HRRBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories(true);
                LoadDepartments(true);
            }
        }

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
    }
}