using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using HRR.Core.Domain;
using HRR.Core.Security;
using HRR.Services;
using HRR.Web.Bases;
using IdeaSeed.Core;
using HRR.Core;
using System.Text;
using HRR.Web.Utils;
using System.Configuration;
using Telerik.Web.UI;

namespace HRRV2.Website
{
    public partial class GoalTemplate : HRRBasePage
    {
        public HRR.Core.Domain.Goal CurrentGoal
        {
            get
            {
                if (!SecurityContextManager.Current.CurrentURL.Contains("New"))
                {
                    var g = new GoalServices().GetByID(Convert.ToInt32(HttpContext.Current.Request.Url.Segments[HttpContext.Current.Request.Url.Segments.Count() - 1]));
                    if (g != null)
                        return g;
                    return null;
                }
                return null;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGoalTemplate();
            }
        }

        private void LoadGoalTemplate()
        {
            tbDueDate.SelectedDate = CurrentGoal.DueDate;
            tbWeight.Text = CurrentGoal.Weight.ToString();
            tbTitle.Text = CurrentGoal.Title;
            tbDescription.Text = CurrentGoal.Description;
        }
    }
}