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
    public partial class RatingScales : HRRBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                LoadScales(true);
        }

        protected void NeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadScales(false);
        }

        protected void ValuesClicked(object o, EventArgs e)
        {
            Response.Redirect("/Reviews/RatingScales/" + ((IdeaSeed.Web.UI.LinkButton)o).Attributes["itemname"].Replace(" ", "-"));
        }

        private void LoadScales(bool bindData)
        {
            var list = new QuestionRatingScaleServices().GetAll();
            rgList.DataSource = list;
            if (bindData)
                rgList.DataBind();
        }

        protected void ItemCommand(object o, GridCommandEventArgs e)
        {

            if (e.CommandName == RadGrid.InitInsertCommandName)
            {
                //e.Canceled = true;
                //var i = new HRR.Core.Domain.QuestionRatingScale();
                //i.Title = "";
                //i.ID = 0;
                //e.Item.OwnerTableView.InsertItem(i);
            }

            if (e.CommandName == RadGrid.PerformInsertCommandName)
            {
                var t = new HRR.Core.Domain.QuestionRatingScale();
                t.Title = (e.Item.FindControl("tbTitle") as IdeaSeed.Web.UI.TextBox).Text;
                t.AccountID = ((Person)SecurityContextManager.Current.CurrentUser).AccountID;
                new QuestionRatingScaleServices().Save(t);
            }
            if (e.CommandName == RadGrid.UpdateCommandName)
            {
                if (e.Item is GridEditableItem)
                {
                    var t = new QuestionRatingScaleServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                    t.Title = (e.Item.FindControl("tbTitle") as IdeaSeed.Web.UI.TextBox).Text;
                    t.AccountID = ((Person)SecurityContextManager.Current.CurrentUser).AccountID;
                    new QuestionRatingScaleServices().Save(t);
                }
            }
            if (e.CommandName == RadGrid.DeleteCommandName)
            {
                var t = new QuestionRatingScaleServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                new QuestionRatingScaleServices().Delete(t);
            }
            IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();
            LoadScales(true);
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
    }
}