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
    public class ManagersDDL : System.Web.UI.WebControls.DropDownList
    {
        public ManagersDDL()
        {
            this.Items.Clear();
            //this.EmptyMessage = "-- Select --";
            this.Items.Add(new System.Web.UI.WebControls.ListItem(" -- Select --", ""));
            //this.Skin = "Metro";
            foreach (var s in new PersonServices().GetAllManagers())
            {
                this.Items.Add(new System.Web.UI.WebControls.ListItem(s.FirstName + " " + s.LastName, s.ID.ToString()));
            }
        }
    }
}
