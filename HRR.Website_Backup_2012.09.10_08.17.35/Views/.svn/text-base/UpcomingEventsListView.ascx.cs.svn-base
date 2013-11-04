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
    public partial class UpcomingEventsListView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadEvents();
        }

        protected void ItemDataBound(object o, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var item = ((HRR.Core.Domain.Person)e.Item.DataItem);
                var lbl = (IdeaSeed.Web.UI.Label)e.Item.FindControl("lblMessage");
                var img = (Telerik.Web.UI.RadBinaryImage)e.Item.FindControl("rbiProfile");
                if (item.Birthdate.Month.Equals(DateTime.Now.Month))
                {
                    lbl.Text = "<span style='font-size: 10pt;'><a href='/People/" + item.Email + "'>" + item.Name + "'s</a></span> birthday is <span style='color: #ff6600;'>" + item.Birthdate.Month.ToString() + "/" + item.Birthdate.Day.ToString() + "</span>";
                }
                else
                {
                    lbl.Text = "<span style='font-size: 10pt;'><a href='/People/" + item.Email + "'>" + item.Name + "'s</a></span> anniversary is <span style='color: #ff6600;'>" + item.HireDate.Month.ToString() + "/" + item.HireDate.Day.ToString() + "</span>";
                }
                img.ImageUrl = item.AvatarPath;
                //switch (item.ItemType)
                //{
                //    case AlertType.GOAL:
                //        var g = (HRR.Core.Domain.Person)item;
                //        lbl.Text = "<span style='font-size: 10pt;'><a href='/Profile" + g.EnteredForRef.Email + "'>" + g.EnteredForRef.Name + "'s</a></span> birthday is<span style='color: #00ff00;'>" + g.DueDate.ToShortDateString() + "</span>";
                //        img.ImageUrl = g.EnteredForRef.AvatarPath;
                //        break;
                //    case AlertType.MILESTONE:
                //        var m = (HRR.Core.Domain.GoalMilestone)item;
                //        lbl.Text = "<span style='font-size: 10pt;'><a href='/Profile" + m.GoalRef.EnteredForRef.Email + "'>" + m.GoalRef.EnteredForRef.Name + "'s</a></span> milestone: <a href='/Goal/" + m.GoalRef.ID.ToString() + "'>" + m.Title + "</a><br /> is due <span style='color: #ff0000;'>" + m.DueDate.ToShortDateString() + "</span>";
                //        img.ImageUrl = m.GoalRef.EnteredForRef.AvatarPath;
                //        break;
                //    case AlertType.REVIEW:
                //        var r = (HRR.Core.Domain.Review)item;
                //        lbl.Text = "<span style='font-size: 10pt;'><a href='/Profile" + r.EnteredForRef.Email + "'>" + r.EnteredForRef.Name + "'s</a></span> review: <a href='/Review/" + r.ID.ToString() + "'>" + r.Title + "</a><br /> is due <span style='color: #ff0000;'>" + r.DueDate.ToShortDateString() + "</span>";
                //        img.ImageUrl = r.EnteredForRef.AvatarPath;
                //        break;

                //}
            }
        }

        private void LoadEvents()
        {
            var list = new PersonServices().GetByUpcomingEvent(DateTime.Today);
            if (list.Count < 1)
                divEvents.Visible = true;
            else
                divEvents.Visible = false;
            dlEvents.DataSource = list;
            dlEvents.DataBind();
        }
    }
}