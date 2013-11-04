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
    public class BlogCategoryDDL : DropDownList
    {
        public BlogCategoryDDL()
        {
            this.Items.Clear();
            this.EmptyMessage = "-- Select --";
            this.Items.Add(new RadComboBoxItem("", "0"));
            this.Skin = "Metro";
            foreach (var s in new BlogCategoryServices().GetAllByAccount().OrderBy(o => o.Name))
            {
                this.Items.Add(new RadComboBoxItem(s.Name, s.ID.ToString()));
            }
        }
    }
}
