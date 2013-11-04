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
using Telerik.Web.UI;

namespace HRR.Website
{
    public partial class Documentation : HRRBasePage
    {
        public HRR.Core.Domain.Documentation CurrentDocumentation
        {
            get
            {
                if (HttpPageHelper.CurrentDocumentation != null)
                    return HttpPageHelper.CurrentDocumentation;
                return null;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadNav();
                if(CurrentDocumentation != null)
                    divContent.InnerHtml = CurrentDocumentation.HelpContent;
            }
        }

        private void LoadNav()
        {
            dlNav.DataSource = new DocumentationServices().GetAll();
            dlNav.DataBind();
        }
    }
}