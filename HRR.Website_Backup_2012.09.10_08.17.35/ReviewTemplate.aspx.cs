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
using HRR.Core.Security;
using System.Text;
using Telerik.Web.UI;

namespace HRR.Website
{
    public partial class ReviewTemplate : HRRBasePage
    {
        private HRR.Core.Domain.ReviewTemplate CurrentReview
        {
            get
            { 
                if (!HttpContext.Current.Request.Url.PathAndQuery.Contains("New"))
                {
                    if (Session["CurrentReviewTemplate"] == null)
                    {
                        Session["CurrentReviewTemplate"] = new ReviewTemplateServices().GetByID(Convert.ToInt32(HttpContext.Current.Request.Url.Segments[HttpContext.Current.Request.Url.Segments.Count() - 1]));
                    }
                    return (HRR.Core.Domain.ReviewTemplate)Session["CurrentReviewTemplate"];
                }
                return null;
            }
            set
            {
                Session["CurrentReviewTemplate"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (CurrentReview != null)
                {
                    divQuestions.Visible = true;
                    LoadTemplate(true);
                }
                else
                {
                    divQuestions.Visible = false;
                }
            }
        }

        protected void NeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            if (CurrentReview != null)
                LoadTemplate(false);
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

        protected void CancelClicked(object o, EventArgs e)
        {
            Response.Redirect(SecurityContextManager.Current.PreviousURL);
        }

        protected void SaveClicked(object o, EventArgs e)
        {
            if (CurrentReview != null)
            {
                CurrentReview.IsActive = cbIsActive.Checked;
                CurrentReview.Title = tbTitle.Text;
                new ReviewTemplateServices().Save(CurrentReview);
            }
            else
            {
                var t = new HRR.Core.Domain.ReviewTemplate();
                t.IsActive = cbIsActive.Checked;
                t.Title = tbTitle.Text;
                new ReviewTemplateServices().Save(t);
                Response.Redirect("/Review/Template/" + t.ID.ToString());
            }
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            CurrentReview = null;
        }

        protected void ItemDataBound(object o, GridItemEventArgs e)
        {
            //if (e.Item is GridDataItem)
            //{
            //    var lbl = (e.Item.FindControl("lblCategory") as IdeaSeed.Web.UI.Label);
            //    var c = new CommentCategoryServices().GetByID(Convert.ToInt32(lbl.Attributes["itemid"]));
            //    if (c != null)
            //        lbl.Text = c.Name;
            //} 
        }

        protected void ItemCommand(object o, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.InitInsertCommandName)
            {
                e.Canceled = true;
                var i = new HRR.Core.Domain.ReviewTemplateQuestion();
                i.CategoryID = 0;
                i.Question = "";
                i.ReviewTemplateID = CurrentReview.ID;
                i.QuestionRatingScaleID = 0;
                i.ID = 0;
                e.Item.OwnerTableView.InsertItem(i);
            }

            if (e.CommandName == RadGrid.PerformInsertCommandName)
            {
                var t = new HRR.Core.Domain.ReviewTemplateQuestion();
                t.Question = (e.Item.FindControl("tbQuestion") as IdeaSeed.Web.UI.TextBox).Text;
                t.ReviewTemplateID = CurrentReview.ID;
                t.CategoryID = Convert.ToInt16((e.Item.FindControl("ddlCategory") as IdeaSeed.Web.UI.DropDownList).SelectedValue);
                t.QuestionRatingScaleID = Convert.ToInt16((e.Item.FindControl("ddlScale") as IdeaSeed.Web.UI.DropDownList).SelectedValue);
                new ReviewTemplateQuestionServices().Save(t);
            }
            if (e.CommandName == RadGrid.UpdateCommandName)
            {
                if (e.Item is GridEditableItem)
                {
                    var t = new ReviewTemplateQuestionServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                    t.Question = (e.Item.FindControl("tbQuestion") as IdeaSeed.Web.UI.TextBox).Text;
                    t.CategoryID = Convert.ToInt16((e.Item.FindControl("ddlCategory") as IdeaSeed.Web.UI.DropDownList).SelectedValue);
                    t.QuestionRatingScaleID = Convert.ToInt16((e.Item.FindControl("ddlScale") as IdeaSeed.Web.UI.DropDownList).SelectedValue);
                    new ReviewTemplateQuestionServices().Save(t);
                }
            }
            if (e.CommandName == RadGrid.DeleteCommandName)
            {
                var t = new ReviewTemplateQuestionServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                new ReviewTemplateQuestionServices().Delete(t);
            }
            CurrentReview = new ReviewTemplateServices().GetByID(Convert.ToInt32(HttpContext.Current.Request.Url.Segments[HttpContext.Current.Request.Url.Segments.Count() - 1]));
        }

        private void LoadTemplate(bool bindData)
        {
            cbIsActive.Checked = CurrentReview.IsActive;
            tbTitle.Text = CurrentReview.Title;
            rgList.DataSource = CurrentReview.Questions;
            if (bindData)
                rgList.DataBind();

        }
    }
}