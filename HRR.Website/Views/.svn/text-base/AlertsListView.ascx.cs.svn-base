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
using System.Web.UI.HtmlControls;

namespace HRR.Website.Views
{
    public partial class AlertsListView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadAlerts();
        }

        protected void ItemDataBound(object o, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var item = ((HRR.Core.Domain.Interfaces.IAlert)e.Item.DataItem);
                var lbl = (IdeaSeed.Web.UI.Label)e.Item.FindControl("lblMessage");
                var img = (Telerik.Web.UI.RadBinaryImage)e.Item.FindControl("rbiProfile");
                switch (item.ItemType)
                {
                    case AlertType.GOAL:
                        var g = (HRR.Core.Domain.Goal)item;
                        lbl.Text = "<span style='font-size: 10pt;'><a href='/People/" + g.EnteredForRef.Email + "'>" + g.EnteredForRef.Name + "'s</a></span> goal: <a href='/Goals/" + g.ID.ToString() + "'>" + g.Title + "</a><br /> is due <span style='color: #ff0000;'>" + g.DueDate.ToShortDateString() + "</span>";
                        //img.ImageUrl = g.EnteredForRef.AvatarPath;
                        break;
                    case AlertType.MILESTONE:
                        var m = (HRR.Core.Domain.GoalMilestone)item;
                        lbl.Text = "<span style='font-size: 10pt;'><a href='/People/" + m.GoalRef.EnteredForRef.Email + "'>" + m.GoalRef.EnteredForRef.Name + "'s</a></span> milestone: <a href='/Goals/" + m.GoalRef.ID.ToString() + "'>" + m.Title + "</a><br /> is due <span style='color: #ff0000;'>" + m.DueDate.ToShortDateString() + "</span>";
                        //img.ImageUrl = m.GoalRef.EnteredForRef.AvatarPath;
                        break;
                    case AlertType.REVIEW:
                        var r = (HRR.Core.Domain.Review)item;
                        lbl.Text = "<span style='font-size: 10pt;'><a href='/People/" + r.EnteredForRef.Email + "'>" + r.EnteredForRef.Name + "'s</a></span> review: <a href='/Reviews/" + r.ID.ToString() + "'>" + r.Title + "</a><br /> is due <span style='color: #ff0000;'>" + r.DueDate.ToShortDateString() + "</span>";
                        //img.ImageUrl = r.EnteredForRef.AvatarPath;
                        break;
                    
                }
            }
        }

        private void LoadAlerts()
        {
            var list = new AlertServices().GetAlertsByDueDate(DateTime.Now.AddDays(21));
            if (list.Count < 1)
                divAlerts.Visible = true;
            else
                divAlerts.Visible = false;
            dlAlerts.DataSource = list;
            dlAlerts.DataBind();
        }
    }
}