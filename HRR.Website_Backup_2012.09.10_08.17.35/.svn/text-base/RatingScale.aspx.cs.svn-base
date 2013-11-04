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
    public partial class RatingScale : HRRBasePage
    {
        private HRR.Core.Domain.QuestionRatingScale CurrentScale
        {
            get
            { 
                if (!HttpContext.Current.Request.Url.PathAndQuery.Contains("New"))
                {
                    if (Session["CurrentReviewSclae"] == null)
                    {
                        Session["CurrentReviewSclae"] = new QuestionRatingScaleServices().GetByID(Convert.ToInt32(HttpContext.Current.Request.Url.Segments[HttpContext.Current.Request.Url.Segments.Count() - 1]));
                    }
                    return (HRR.Core.Domain.QuestionRatingScale)Session["CurrentReviewSclae"];
                }
                return null;
            }
            set
            {
                Session["CurrentReviewSclae"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (CurrentScale != null)
                {
                    lblTitle.Text = CurrentScale.Title + " Values";
                   LoadScale(true);
                }
            }
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            CurrentScale = null;
        }

        protected void NeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            if (CurrentScale != null)
            {
                LoadScale(false);
            }
        }

        protected void ItemCreated(object o, GridItemEventArgs e)
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


        protected void ItemCommand(object o, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.InitInsertCommandName)
            {
                e.Canceled = true;
                var i = new HRR.Core.Domain.QuestionRatingScaleValue();
                i.QuestionRatingScaleID = 0;
                //i.Title = "";
                i.Value = 0;
                i.ID = 0;
                e.Item.OwnerTableView.InsertItem(i);
            }

            if (e.CommandName == RadGrid.PerformInsertCommandName)
            {
                var t = new HRR.Core.Domain.QuestionRatingScaleValue();
                t.Title = (e.Item.FindControl("tbTitle") as IdeaSeed.Web.UI.TextBox).Text;
                t.QuestionRatingScaleID = CurrentScale.ID;
                t.Value = Convert.ToInt16((e.Item.FindControl("tbValue") as IdeaSeed.Web.UI.TextBox).Text);
                new QuestionRatingScaleValueServices().Save(t);
            }
            if (e.CommandName == RadGrid.UpdateCommandName)
            {
                if (e.Item is GridEditableItem)
                {
                    var t = new QuestionRatingScaleValueServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                    t.Title = (e.Item.FindControl("tbTitle") as IdeaSeed.Web.UI.TextBox).Text;
                t.Value = Convert.ToInt16((e.Item.FindControl("tbValue") as IdeaSeed.Web.UI.TextBox).Text);
                    new QuestionRatingScaleValueServices().Save(t);
                }
            }
            if (e.CommandName == RadGrid.DeleteCommandName)
            {
                var t = new QuestionRatingScaleValueServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                new QuestionRatingScaleValueServices().Delete(t);
            }
            CurrentScale = new QuestionRatingScaleServices().GetByID(Convert.ToInt32(HttpContext.Current.Request.Url.Segments[HttpContext.Current.Request.Url.Segments.Count() - 1]));
        }

        private void LoadScale(bool bindData)
        {
            if (CurrentScale != null)
            {
                rgList.DataSource = CurrentScale.Values;
                if (bindData)
                    rgList.DataBind();
            }
        }
    }
}