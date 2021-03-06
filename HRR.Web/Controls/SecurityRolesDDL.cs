﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRR.Core.Domain;
using HRR.Services;
using Telerik.Web.UI;
using IdeaSeed.Web.UI;

namespace HRR.Web.Controls
{
    public class SecurityRolesDDL : System.Web.UI.WebControls.DropDownList
    {
        public SecurityRolesDDL()
        {
            this.Items.Clear();
            //this.EmptyMessage = "-- Select --";
            this.Items.Add(new System.Web.UI.WebControls.ListItem("-- Select -- ", ""));
            //this.Skin = "Metro";
            foreach (var s in Enum.GetValues(typeof(HRR.Core.Domain.SecurityRole)))
            {
                this.Items.Add(new System.Web.UI.WebControls.ListItem(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Enum.GetName(typeof(HRR.Core.Domain.SecurityRole), Convert.ToInt16(s)).Replace("_or_", @"/").Replace("_", " ").ToLower()), Convert.ToInt16(s).ToString()));
            }
        }
    }
}
