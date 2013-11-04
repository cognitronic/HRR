using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRR.Core.Domain;
using HRR.Services;
using Telerik.Web.UI;
using IdeaSeed.Web.UI;
using HRR.Core.Security;

namespace HRR.Web.Controls
{
    public class UserTeamsDDL : DropDownList
    {
        public UserTeamsDDL()
        {
            this.Items.Clear();
            this.EmptyMessage = "-- Select --";
            this.Items.Add(new RadComboBoxItem("", ""));
            this.Skin = "Metro";

            var list = new List<Team>();
            foreach (var i in ((Person)SecurityContextManager.Current.CurrentUser).Memberships)
            {
                list.Add(i.TeamRef);
            }

            foreach (var l in list.OrderBy(o => o.Name))
            {
                this.Items.Add(new RadComboBoxItem(l.Name, l.ID.ToString()));
            }
        }
    }
}
