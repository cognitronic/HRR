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
    public class DepartmentsDDL : DropDownList
    {
        public DepartmentsDDL()
        {
            this.Items.Clear();
            this.EmptyMessage = "-- Select --";
            this.Items.Add(new RadComboBoxItem("", ""));
            this.Skin = "Metro";
            foreach (var s in new DepartmentServices().GetAll())
            {
                this.Items.Add(new RadComboBoxItem(s.Name, s.ID.ToString()));
            }
        }
    }
}
