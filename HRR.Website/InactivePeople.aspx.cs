using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using HRR.Core.Domain;
using HRR.Services;
using HRR.Web.Bases;
using IdeaSeed.Core;
using HRR.Core.Security;
using System.Text;

namespace HRR.Website
{
    public partial class InactivePeople : HRRBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (((Person)SecurityContextManager.Current.CurrentUser).RoleID < (int)SecurityRole.EXECUTIVE_MANAGEMENT)
            {
                Response.Redirect("/Overview");
            }
            if (!IsPostBack)
            {
                LoadPeople();
                if (((Person)SecurityContextManager.Current.CurrentUser).RoleID < (int)SecurityRole.ADMIN)
                    lbAddEmployee.Visible = false;
            }
        }

        protected void AddEmployeeClicked(object o, EventArgs e)
        {
            Response.Redirect("/People/New");
        }

        private void LoadPeople()
        {
            var list = new DepartmentServices().GetAll();
            dlPeople.DataSource = list;
            dlPeople.DataBind();
        }

        protected void MasterItemDataBound(object o, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var div = e.Item.FindControl("divTitle") as HtmlGenericControl;
                div.Attributes["paneltitle"] = ((Department)e.Item.DataItem).Name + " (" + ((Department)e.Item.DataItem).People.Where(p => p.IsActive == false).Count().ToString() + ")";
                BindNestedDataList((Repeater)e.Item.FindControl("nestedDataList"), (Department)e.Item.DataItem);
            }
        }

        protected void NestedItemDataBound(object o, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (((Person)e.Item.DataItem).IsActive)
                {
                    var div = e.Item.FindControl("divPerson") as HtmlGenericControl;
                    div.Visible = false;
                }
            }
        }

        public void BindNestedDataList(Repeater dl, Department dept)
        {
            switch (((Person)SecurityContextManager.Current.CurrentUser).RoleID)
            {
                case (int)SecurityRole.ADMIN:
                case (int)SecurityRole.EXECUTIVE_MANAGEMENT:
                case (int)SecurityRole.MANAGER:
                    dl.DataSource = dept.People.OrderBy(o => o.IsManager);
                    break;
                case (int)SecurityRole.EMPLOYEE:
                case (int)SecurityRole.READ_ONLY:
                    var peeps = new List<HRR.Core.Domain.Person>();
                    peeps.Add(dept.People.Where(p => p.ID == SecurityContextManager.Current.CurrentUser.ID).FirstOrDefault<Person>());

                    dl.DataSource = peeps;
                    break;
            }
            dl.DataBind();
        }

        public void BindNestedDataList(Repeater dl, Person person)
        {
            dl.DataSource = person.Goals;
            dl.DataBind();
        }
    }
}