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
    public partial class GoalListView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGoals();
        }

        private void LoadGoals()
        {
            var sb = new StringBuilder();
            var l = new List<HRR.Core.Domain.Person>();
            switch (((Person)SecurityContextManager.Current.CurrentUser).RoleID)
            { 
                case (int)SecurityRole.ADMIN:
                case (int)SecurityRole.EXECUTIVE_MANAGEMENT:
                    l = new PersonServices().GetAll().ToList();
                break;
                case (int)SecurityRole.MANAGER:
                    l = new PersonServices().GetByDepartmentID(((Person)SecurityContextManager.Current.CurrentUser).DepartmentID).ToList();
                break;
                case (int)SecurityRole.EMPLOYEE:
                case (int)SecurityRole.READ_ONLY:
                    l.Add(new PersonServices().GetByID(SecurityContextManager.Current.CurrentUser.ID));
                break;
            }
            //l = new GoalServices().GetByEnteredFor(SecurityContextManager.Current.CurrentUser.ID, (int)GoalStatus.ACCEPTED);
            var list =
                from w in l
                group w by w.DepartmentRef into g
                select new { Goals = g.Key, User = g };
            sb.Append("<div style='overflow:auto;'>");

            foreach (var m in list.OrderBy(o => o.Goals.Name))
            {
                sb.Append("<div class='collapsibleContainer' title='");
                //sb.Append("<h3><b>");
                sb.Append(m.Goals.Name);
                sb.Append(" (");
                sb.Append(m.Goals.People.Count().ToString());
                sb.Append(")");
                sb.Append("' style='margin-bottom: 5px;'>");
                //sb.Append("</b></h3>");
                //sb.Append("<hr style='margin-top: -5px !important; margin-top: 10px; border: 1px solid #333333;' />");
                foreach (var p in m.User.OrderBy(b => b.LastName).OrderByDescending(o => o.IsManager))
                {
                    if (p.IsActive)
                    {
                        sb.Append("<div runat='server'id='divMilestones' style='padding: 3px; background-color: #eeeeee; margin-top: 15px;'><div style='overflow:auto; background-color: #ffffff; padding: 10px;'>");
                        sb.Append("<div style='float: left; margin-left: 5px; margin-right: 15px;'>");
                        sb.Append("<img src='");
                        sb.Append(p.AvatarPath);
                        sb.Append("' alt='' width='50px' height='50px'/></div>");
                        sb.Append("<div style='float: left; margin-left: 0px; margin-bottom: 10px; width: 600px;'>");
                        sb.Append("<span style='font-size: 12pt;'>");
                        sb.Append("<a href='/People/");
                        sb.Append(p.Email);
                        sb.Append("'>");
                        sb.Append(p.FirstName);
                        sb.Append(" ");
                        sb.Append(p.LastName);
                        sb.Append("</a></span> - ");
                        sb.Append("<span style='font-size: 10pt; color: #333333;'>");
                        sb.Append(p.Title);
                        sb.Append("</span>");
                        if (((Person)SecurityContextManager.Current.CurrentUser).RoleID > (int)SecurityRole.READ_ONLY)
                        {
                            sb.Append("<span style='float: right;'>");
                            sb.Append("<a href='/Goals/New/");
                            sb.Append(p.ID.ToString());
                            sb.Append("'><img src='/Images/add.png' title='Create New Goal' alt=''/>New Goal</a></span>");
                        }
                        sb.Append("</div>");
                        sb.Append("<div style='clear: both;float:left; margin-top: 3px;margin-left: 5px; margin-right: 15px; width: 670px;'><table style='font-size: 8pt; color: #000000;padding: 15px; width: 670px; margin-bottom: 25px;'><tr style='background-color: #30a9de; color: #ffffff; padding: 25px; height: 25px; font-size: 14px;'><td style='width: 275px; padding-left: 5px;'><b>Title</b></td><td style='width:75px;'>Due Date</td><td style='width:150px;'>Status</td><td style='125px;'>&nbsp;</td></tr>");
                        foreach (var gl in p.Goals)
                        {
                            sb.Append("<tr><td style='padding-left: 5px;'>");
                            sb.Append(gl.Title);
                            sb.Append("</td><td>");
                            sb.Append(gl.DueDate.ToShortDateString());
                            sb.Append("</td><td>");
                            sb.Append(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Enum.GetName(typeof(GoalStatus), gl.StatusID)).Replace("_or_", @"/").Replace("_", " ").ToLower());
                            sb.Append("</td><td style='width: 150px;'><div style='float: left; margin-right: 15px;'><img src='/images/green_flag.png' border='0' alt='Milestones' title='");
                            sb.Append(gl.Milestones.Count().ToString());
                            sb.Append(" milestone(s) have been entered'/></div> ");
                            sb.Append("<div style='float: left; margin-left: -35px; margin-top: 3px; height: 24px !important; color: #ffffff; font-weight: bolder;' title='");
                            sb.Append(gl.Milestones.Count().ToString());
                            sb.Append(" milestone(s) have been entered'>");
                            sb.Append(gl.Milestones.Count().ToString());
                            sb.Append("</div>");
                            sb.Append("<div style='float: left; margin-right: 15px; margin-top: 3px;'><img src='/images/comment.png' border='0' alt='Communication' title='");
                            sb.Append(gl.Communication.Count().ToString());
                            sb.Append(" comment(s) have been entered'/></div> ");
                            sb.Append("<div style='float: left; margin-left: -31px; margin-top: 9px; height: 24px !important; color: #ffffff; font-weight: bolder;' title='");
                            sb.Append(gl.Communication.Count().ToString());
                            sb.Append(" comment(s) have been entered'>");
                            sb.Append(gl.Communication.Count().ToString());
                            sb.Append("</div><div style='float: left; margin-top: 10px;'><a href='/Goals/");
                            sb.Append(gl.ID.ToString());
                            sb.Append("'><img src='/images/pencil.png' border='0' title='View Goal' />View</a></div></td></tr>");
                        }
                        sb.Append("</table></div>");
                        sb.Append("</div></div>");
                        sb.Append("<br /><br />");
                    }
                }
                sb.Append("</div>");
            }
            sb.Append("</div>");
            divGoals.InnerHtml = sb.ToString();
        }
    }
}