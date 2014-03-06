using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRR.Web.Bases;
using HRR.Core.Domain;
using HRR.Services;

namespace HRRV2.Website.Public
{
    public partial class Evaluation : NoSecurityBasePage
    {
        public PerformanceEvaluation CurrentEvaluation
        {
            get
            {
                if (!string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["id"]) &&
                    !string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["e"]))
                {
                    var g = new PerformanceEvaluationServices().GetEvaluationByID(Convert.ToInt32(HttpContext.Current.Request.Url.Segments[HttpContext.Current.Request.Url.Segments.Count() - 1]));
                    if (g != null)
                        return g;
                    return null;
                }
                return null;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}