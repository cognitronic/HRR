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
using Telerik.Web.UI;
using System.Web.UI.HtmlControls;

namespace HRR.Website.Views
{
    public partial class ReviewTemplateListView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadTemplates(true);
        }

        protected void NewTemplateClicked(object o, EventArgs e)
        {
            Response.Redirect("/Reviews/Templates/New");
        }

        protected void ItemDataBound(object o, GridItemEventArgs e)
        {
        }

        protected void NeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadTemplates(false);
        }

        private void LoadTemplates(bool bindData)
        {
            var list = new ReviewTemplateServices().GetAll();
            rgList.DataSource = list;
            if (bindData)
                rgList.DataBind();
        }

        protected void EditClicked(object o, EventArgs e)
        {
            Response.Redirect("/Reviews/Templates/" + ((LinkButton)o).Attributes["itemid"]);
        }

        protected void ItemCommand(object o, GridCommandEventArgs e)
        {

            if (e.CommandName == RadGrid.InitInsertCommandName)
            {
                //Response.Redirect("/Review/Template/New");
            }
            if (e.CommandName == RadGrid.DeleteCommandName)
            {
                var t = new ReviewTemplateQuestionServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                new ReviewTemplateQuestionServices().Delete(t);
            }
        }
    }
}