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
    public partial class BreadCrumbView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BuildSiteMap();
        }

        private void BuildSiteMap()
        {
            string[] items = HttpContext.Current.Request.Url.Segments;
            string domain = Request.Url.GetLeftPart(UriPartial.Authority);
            //string result = "";
            string url = "";
            var sb = new StringBuilder();
            sb.Append("<ul id='breadcrumbs'>");
            for (int i = 0; items.Length > i; i++)
            {
                if (i == 0)
                {
                    sb.Append("<li><a href='");
                    sb.Append(domain);
                    sb.Append("/Overview'>Overview</a></li>");
                    //result += "<span><a href='" + domain + "/Home'>Home</a><span>";
                }
                else
                {
                    if (i == (items.Length - 1))
                    {
                        url += items[i];
                        //result += "<span style='color: #999999;font: 12px 'Trebuchet MS', 'Tahoma', 'Verdana', sans-serif !important;'>" + items[i].Replace("-", " ").Replace("/", "") + "<span>";
                        sb.Append("<li>");
                        sb.Append(items[i].Replace("-", " ").Replace("/", ""));
                        sb.Append("</li>");
                    }
                    else
                    {
                        url += items[i];
                        sb.Append("<li><a href='");
                        sb.Append(domain);
                        sb.Append("/");
                        sb.Append(url.Remove(url.Length - 1));
                        sb.Append("'>");
                        sb.Append(items[i].Replace("-", " ").Replace("/", ""));
                        sb.Append("</a></li>");
                        //result += "<span><a href='" + domain + url + "'>" + items[i].Replace("-", " ").Replace("/", "") + "</a> > <span>";
                    }
                }
            }
            sb.Append("</ul>");
            //var div = new HtmlGenericControl("Div");
            divBreadCrumb.InnerHtml = sb.ToString();
            //phSiteMap.Controls.Add(div);

        }
    }
}