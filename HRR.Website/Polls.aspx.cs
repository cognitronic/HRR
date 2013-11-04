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
    public partial class Polls : HRRBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadPolls(true);
        }

        protected void NeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadPolls(false);
        }

        protected void OptionsClicked(object o, EventArgs e)
        {
            Response.Redirect("/Polls/RatingScales/" + ((IdeaSeed.Web.UI.LinkButton)o).Attributes["itemname"].Replace(" ", "-"));
        }

        private void LoadPolls(bool bindData)
        {
            var list = new PollServices().GetAllByAccount();
            rgList.DataSource = list;
            if (bindData)
                rgList.DataBind();
        }

        protected void ItemDataBound(object o, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                var lbl = e.Item.FindControl("lblResponses") as IdeaSeed.Web.UI.Label;
                var list = new PollResultServices().GetByPollID(Convert.ToInt32(lbl.Attributes["itemid"]));
                if (list != null && list.Count > 0)
                    lbl.Text = list.Count.ToString();
                else
                    lbl.Text = "0";
            }
        }

        protected void ItemCommand(object o, GridCommandEventArgs e)
        {

            if (e.CommandName == RadGrid.InitInsertCommandName)
            {
                Response.Redirect("/Polls/New/" + SecurityContextManager.Current.CurrentAccount.ID.ToString());
            }

            if (e.CommandName == RadGrid.PerformInsertCommandName)
            {
                Response.Redirect("/Polls/New/" + SecurityContextManager.Current.CurrentAccount.ID.ToString());
            }
            if (e.CommandName == RadGrid.EditCommandName)
            {
                if (e.Item is GridEditableItem)
                {
                    Response.Redirect("/Polls/" + e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                }
            }
            if (e.CommandName == RadGrid.DeleteCommandName)
            {
                var t = new PollServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                new PollServices().Delete(t);
            }
            IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();
            LoadPolls(true);
        }
    }
}