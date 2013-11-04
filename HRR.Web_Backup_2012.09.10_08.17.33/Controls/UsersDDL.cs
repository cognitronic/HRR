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
    public class UsersDDL : DropDownList
    {
        public int ManagerID
        {
            get;
            set;
        }

        public UsersDDL()
        {
            LoadUsers();
        }
        public void LoadUsers()
        {
            this.Items.Clear();
            this.EmptyMessage = "-- Select --";
            this.Items.Add(new RadComboBoxItem("", ""));
            this.Skin = "Metro";
            if (SecurityContextManager.Current != null)
            {
                foreach (var s in new PersonServices().GetAll().OrderBy(o => o.LastName))
                {
                    this.Items.Add(new RadComboBoxItem(s.FirstName + " " + s.LastName, s.ID.ToString()));
                }

                #region Old Code
                //if (((Person)SecurityContextManager.Current.CurrentUser).RoleID == (int)SecurityRole.MANAGER || ((Person)SecurityContextManager.Current.CurrentUser).RoleID == (int)SecurityRole.EMPLOYEE)
                //{
                //    foreach (var s in new PersonServices().GetByDepartmentID(((Person)SecurityContextManager.Current.CurrentUser).DepartmentID))
                //    {
                //        this.Items.Add(new RadComboBoxItem(s.FirstName + " " + s.LastName, s.ID.ToString()));
                //    }
                //}






                //if (SecurityContextManager.Current.CurrentTeamID != null)
                //{
                //    foreach (var s in new TeamMemberServices().GetByTeamID((int)SecurityContextManager.Current.CurrentTeamID))
                //    {
                //        this.Items.Add(new RadComboBoxItem(s.PersonRef.FirstName + " " + s.PersonRef.LastName, s.PersonRef.ID.ToString()));
                //    }
                //}







                //if (((Person)SecurityContextManager.Current.CurrentUser).RoleID == (int)SecurityRole.ADMIN)
                //{
                //    foreach (var s in new PersonServices().GetAll())
                //    {
                //        this.Items.Add(new RadComboBoxItem(s.FirstName + " " + s.LastName, s.ID.ToString()));
                //    }
                //}
                //else
                //{
                //    foreach (var t in ((Person)SecurityContextManager.Current.CurrentUser).Memberships)
                //    {
                //        foreach (var m in t.TeamRef.Members)
                //        {
                //            if(this.Items.FindItemByValue(m.PersonID.ToString()) 
                //                == null)
                //            {
                //            this.Items.Add(new RadComboBoxItem(m.PersonRef.FirstName + " " + m.PersonRef.LastName, m.PersonID.ToString()));
                //            }
                //        }
                //    }
                //}
                #endregion
            }
        }
    }
}
