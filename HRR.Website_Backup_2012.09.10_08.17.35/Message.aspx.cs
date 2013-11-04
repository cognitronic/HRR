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
using HRR.Web.Utils;
using System.Text;
using System.Configuration;
using IdeaSeed.Core;
using Telerik.Web.UI;
using HRR.Core;
using System.Web.UI.HtmlControls;

namespace HRR.Website
{
    public partial class Message : HRRBasePage
    {
        private HRR.Core.Domain.Message CurrentMessage
        {
            get
            {
                if (!SecurityContextManager.Current.CurrentURL.Contains("New"))
                {
                    var m = new MessageServices().GetByID(Convert.ToInt32(HttpContext.Current.Request.Url.Segments[HttpContext.Current.Request.Url.Segments.Count() - 1]));
                    if (m != null)
                        return m;
                    return null;
                }
                return null;
            }
            set
            {
                Session["CurrentMessage"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (CurrentMessage != null)
                {
                    divEditable.Visible = false;
                    divReadonly.Visible = true;
                    lblReadOnlyTitle.Text = CurrentMessage.Subject;
                    lblFrom.Text = "<a href='/People/" + CurrentMessage.SentByRef.Email + "'>" + CurrentMessage.SentByRef.Name + "</a>";
                    string sTo = "";
                    foreach(var r in CurrentMessage.Recipients)
                    {
                        sTo += "<a href='/People/" + r.RecipientRef.Email + "'>" + r.RecipientRef.Name + "</a>, ";
                    }
                    lblTo.Text = sTo.Substring(0, sTo.Length - 2);
                    lblSubject.Text = CurrentMessage.Subject;
                    lblMessage.Text = CurrentMessage.Body;
                    lblSent.Text = CurrentMessage.DateCreated.ToString();
                }
                else
                {
                    lblTitle.Text = "Untitled Message";
                    divEditable.Visible = true;
                    divReadonly.Visible = false;
                }
            }
        }

        protected void SendMessageClicked(object o, EventArgs e)
        { 
            
        }

        protected void CancelMessageClicked(object o, EventArgs e)
        { 
            
        }

        protected void ReplyMessageClicked(object o, EventArgs e)
        { 
        
        }

        protected void ForwardMessageClicked(object o, EventArgs e)
        {

        }

        protected void DeleteMessageClicked(object o, EventArgs e)
        {

        }

        protected void ArchiveMessageClicked(object o, EventArgs e)
        {

        }
    }
}