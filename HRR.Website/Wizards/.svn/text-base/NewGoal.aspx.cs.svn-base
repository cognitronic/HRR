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
using HRR.Web.Utils;
using System.Configuration;
using HRR.Core;
using System.Text;
using System.Web.Script.Serialization;
using Telerik.Web.UI;

namespace HRR.Website.Wizards
{
    public partial class NewGoal : HRRBasePage
    {
        private HRR.Core.Domain.Goal _tempgoal = null;
        protected HRR.Core.Domain.Goal TempGoal
        {
            get
            {
                if (_tempgoal == null)
                {
                    _tempgoal = new HRR.Core.Domain.Goal();
                    _tempgoal.Name = "Danny Schreber";
                    return _tempgoal;
                }
                return _tempgoal;
            }
            set
            {
                _tempgoal = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            enteredForID.Value = Request.Url.Query.Replace("?enteredfor=", "").Replace("/", "");
        }
    }
}