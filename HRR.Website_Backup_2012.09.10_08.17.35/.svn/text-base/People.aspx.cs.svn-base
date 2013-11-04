using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRR.Core.Domain;
using HRR.Services;
using HRR.Web.Bases;
using IdeaSeed.Core;
using HRR.Core.Security;
using System.Text;

namespace HRR.Website
{
    public partial class People : HRRBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (((Person)SecurityContextManager.Current.CurrentUser).RoleID < (int)SecurityRole.EXECUTIVE_MANAGEMENT)
            //{
            //    Response.Redirect("/Overview");
            //}
            if (!IsPostBack)
            {
                LoadPeople();
                if (((Person)SecurityContextManager.Current.CurrentUser).RoleID < (int)SecurityRole.ADMIN)
                {
                    lbAddEmployee.Visible = false;
                    lbInactiveEmployees.Visible = false;
                }
            }
        }

        protected void AddEmployeeClicked(object o, EventArgs e)
        {
            Response.Redirect("/People/New");
        }

        protected void InactiveEmployeeClicked(object o, EventArgs e)
        {
            Response.Redirect("/People/Inactive");
        }

        private void LoadPeople()
        {
            var sb = new StringBuilder();
            var list = new DepartmentServices().GetAll();
            sb.Append("<div style='overflow:auto;'>");
            foreach (var depts in list)
            {
                //sb.Append("<h3 class='collapsibleContainerTitle'><b>");
                //sb.Append(depts.Name);
                //sb.Append("</b></h3>");
                sb.Append("<div class='collapsibleContainer' title='");
                sb.Append(depts.Name);
                sb.Append(" (");
                sb.Append(depts.People.Count().ToString());
                sb.Append(")");
                sb.Append("' style='margin-bottom: 5px;'>");
                //sb.Append("<hr style='margin-top: -5px !important; margin-top: 10px; border: 1px solid #333333;' />");
                sb.Append("<div class='containerouter '><div class='containerinner'>");
                if (depts.People.Count < 1)
                {
                    sb.Append("<div style='margin-left: 35px; margin-right: 15px;'>");
                    sb.Append("<span>No Employees Found</span>");
                    sb.Append("</div>");
                }
                else
                {
                    foreach (var p in depts.People.OrderBy(b => b.LastName).OrderByDescending(o => o.IsManager))
                    {
                        if (p.IsActive)
                        {
                            sb.Append("<div style='float: left; margin-left: 5px; margin-right: 15px;'>");
                            sb.Append("<img src='");
                            sb.Append(p.AvatarPath);
                            sb.Append("' alt='' width='50px' height='50px'/></div>");
                            sb.Append("<div style='float: left; margin-left: 0px; margin-bottom: 10px; width: 580px;'>");
                            sb.Append("<span style='font-size: 14pt;'>");
                            sb.Append("<a href='/People/");
                            sb.Append(p.Email);
                            sb.Append("'>");
                            sb.Append(p.FirstName);
                            sb.Append(" ");
                            sb.Append(p.LastName);
                            sb.Append("</a></span> - ");
                            sb.Append("<span style='font-size: 10pt; color: #333333;'>");
                            sb.Append(p.Title);
                            sb.Append("</span><div><table style='font-size: 8pt; color: #000000;padding: 15px; width: 580px; '><tr><td style='width: 350px;'>email: <a href='mailto:");
                            sb.Append(p.Email);
                            sb.Append("'>");
                            sb.Append(p.Email);
                            sb.Append("</a></td>");
                            sb.Append("<td>manager: <a href='/People/");
                            sb.Append(p.Manager.Email);
                            sb.Append("'>");
                            sb.Append(p.Manager.FirstName);
                            sb.Append(" ");
                            sb.Append(p.Manager.LastName);
                            sb.Append("</a></td></tr></table>");
                            sb.Append("</div>");
                            sb.Append("</div><hr style='margin-left: 35px; margin-right: 15px; margin-top: 10px;' />");
                        }
                    }
                }
                sb.Append("</div></div></div>");
            }
            sb.Append("</div>");
            divPeople.InnerHtml = sb.ToString();
        }
    }
}