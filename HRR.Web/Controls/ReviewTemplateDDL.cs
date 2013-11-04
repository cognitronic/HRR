using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRR.Core.Domain;
using HRR.Services;
using Telerik.Web.UI;
using IdeaSeed.Web.UI;

namespace HRR.Web.Controls
{
    public class ReviewTemplateDDL : System.Web.UI.WebControls.DropDownList
    {
        public ReviewTemplateDDL()
        {
            this.Items.Clear();
            //this.EmptyMessage = "-- Select --";
            this.Items.Add(new System.Web.UI.WebControls.ListItem("", ""));
            //this.Skin = "Metro";
            foreach (var s in new ReviewTemplateServices().GetAll().OrderBy(o => o.Title))
            {
                this.Items.Add(new System.Web.UI.WebControls.ListItem(s.Title, s.ID.ToString()));
            }
        }
    }
}
