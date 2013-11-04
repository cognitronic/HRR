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
            LoadAutoSuggest();
            if (!IsPostBack)
            {
                if (CurrentMessage != null)
                {
                    AuthorizeAccount(CurrentMessage.SentByRef.AccountID);
                    if(!CurrentMessage.Recipients.Any(r => r.RecipientID == SecurityContextManager.Current.CurrentUser.ID))
                    {
                        Response.Redirect("/Messages");
                    }
                    UpdateMessageStatus();
                    divEditable.Visible = false;
                    divReadonly.Visible = true;
                    lblReadOnlyTitle.Text = CurrentMessage.Subject;
                    lblFrom.Text = "<a href='/People/" + CurrentMessage.SentByRef.Email + "'>" + CurrentMessage.SentByRef.Name + "</a>";
                    string sTo = "";
                    string sCc = "";
                    foreach(var r in CurrentMessage.Recipients)
                    {
                        if (r.RecipientTypeID == (int)RecipientType.TO)
                        {
                            if (r.RecipientID != CurrentMessage.SentByRef.ID)
                                sTo += "<a href='/People/" + r.RecipientRef.Email + "'>" + r.RecipientRef.Name + "</a>, ";
                        }
                        if (r.RecipientTypeID == (int)RecipientType.CC)
                            sCc += "<a href='/People/" + r.RecipientRef.Email + "'>" + r.RecipientRef.Name + "</a>, ";
                    }
                    lblTo.Text = sTo.Substring(0, sTo.Length - 2);
                    if (sCc.Length > 3)
                    {
                        lblCc.Text = sCc.Substring(0, sCc.Length - 2);
                    }
                    lblSubject.Text = CurrentMessage.Subject;
                    lblMessage.Text = CurrentMessage.Body;
                    lblSent.Text = CurrentMessage.DateCreated.ToLongDateString();
                }
                else
                {
                    lblTitle.Text = "Untitled Message";
                    divEditable.Visible = true;
                    divReadonly.Visible = false;
                }
            }
        }

        IList<MessageRecipient> RecipientList = new List<MessageRecipient>();

        protected void SendMessageClicked(object o, EventArgs e)
        {
            if (tbTo.Entries.Count > 0)
            {
                var m = new HRR.Core.Domain.Message();
                m.Body = reContent.Content;
                m.DateCreated = DateTime.Now;
                m.MessageTypeID = (int)MessageType.MESSAGE;
                m.SentBy = SecurityContextManager.Current.CurrentUser.ID;
                m.Subject = tbSubject.Text;
                new MessageServices().Save(m);

                //save to sent folder
                var sentby = new MessageRecipient();
                sentby.MessageFolderID = (int)MessageFolder.SENT;
                sentby.MessageID = m.ID;
                sentby.MessageStatusTypeID = (int)MessageStatusType.UNREAD;
                sentby.RecipientID = m.SentBy;
                sentby.RecipientTypeID = (int)RecipientType.TO;
                new MessageRecipientServices().Save(sentby);

                BuildRecipientList(m);
                Response.Redirect("/Messages");
            }
        }

        private void UpdateMessageStatus()
        {
            var r = new MessageRecipientServices().GetByRecipientMessageID(SecurityContextManager.Current.CurrentUser.ID, CurrentMessage.ID);
            if (r != null)
            {
                r.MessageStatusTypeID = (int)MessageStatusType.READ;
                new MessageRecipientServices().Save(r);
            }
        }

        private void LoadAutoSuggest()
        {
            List<HRR.Core.Domain.Interfaces.IAutoSuggestRecipient> list = new MessageServices().GetAutoSuggestRecipients();
            tbTo.DataSource = list; 
            tbTo.DataTextField = "Name";
            tbTo.DataValueField = "Email";

            tbCc.DataSource = list;
            tbCc.DataTextField = "Name";
            tbCc.DataValueField = "Email";

            tbBcc.DataSource = list;
            tbBcc.DataTextField = "Name";
            tbBcc.DataValueField = "Email";
        }

        protected void CancelMessageClicked(object o, EventArgs e)
        {
            Response.Redirect(SecurityContextManager.Current.CurrentURL);
        }

        protected void ReplyMessageClicked(object o, EventArgs e)
        {
            divEditable.Visible = true;
            divReadonly.Visible = false;
            lblTitle.Text = "RE: " + CurrentMessage.Subject;
            tbSubject.Text = "RE: " + CurrentMessage.Subject;
            tbTo.Entries.Add(new AutoCompleteBoxEntry(CurrentMessage.SentByRef.Name, CurrentMessage.SentByRef.Email));
            reContent.Focus();
            reContent.Content = "<br /><br /><hr/>" +
                "<b>From:</b> " + lblFrom.Text + "<br />" +
                "<b>Sent:</b> " + lblSent.Text + "<br />" +
                "<b>To:</b> " + lblTo.Text + "<br />" +
                "<b>Cc:</b> " + lblCc.Text + "<br />" +
                "<b>Subject:</b> " + lblSubject.Text + "<br /><br />" +
                CurrentMessage.Body;
        }

        protected void ReplyAllClicked(object o, EventArgs e)
        {
            divEditable.Visible = true;
            divReadonly.Visible = false;
            lblTitle.Text = "RE: " + CurrentMessage.Subject;
            tbSubject.Text = "RE: " + CurrentMessage.Subject;
            reContent.Focus();
            reContent.Content = "<br /><br /><hr/>" +
                "<b>From:</b> " + lblFrom.Text + "<br />" +
                "<b>Sent:</b> " + lblSent.Text + "<br />" +
                "<b>To:</b> " + lblTo.Text + "<br />" +
                "<b>Cc:</b> " + lblCc.Text + "<br />" +
                "<b>Subject:</b> " + lblSubject.Text + "<br /><br />" +
                CurrentMessage.Body;
            foreach (var cc in CurrentMessage.Recipients)
            {
                switch (cc.RecipientTypeID)
                {
                    case (int)RecipientType.TO:
                        if(cc.RecipientID != SecurityContextManager.Current.CurrentUser.ID)
                            tbTo.Entries.Add(new AutoCompleteBoxEntry(cc.RecipientRef.Name, cc.RecipientRef.Email));
                        break;
                    case (int)RecipientType.CC:
                        if (cc.RecipientID != SecurityContextManager.Current.CurrentUser.ID)
                            tbCc.Entries.Add(new AutoCompleteBoxEntry(cc.RecipientRef.Name, cc.RecipientRef.Email));
                        break;
                    case (int)RecipientType.BCC:
                        if (cc.RecipientID != SecurityContextManager.Current.CurrentUser.ID)
                            tbBcc.Entries.Add(new AutoCompleteBoxEntry(cc.RecipientRef.Name, cc.RecipientRef.Email));
                        break;
                }
            }
        }

        protected void ForwardMessageClicked(object o, EventArgs e)
        {
            divEditable.Visible = true;
            divReadonly.Visible = false;
            lblTitle.Text = "FW: " + CurrentMessage.Subject;
            tbSubject.Text = "FW: " + CurrentMessage.Subject;
            tbTo.Focus();
            reContent.Content = "<br /><br /><hr/>" +
                "<b>From:</b> " + lblFrom.Text + "<br />" +
                "<b>Sent:</b> " + lblSent.Text + "<br />" +
                "<b>To:</b> " + lblTo.Text + "<br />" +
                "<b>Subject:</b> " + lblSubject.Text + "<br /><br />" +
                CurrentMessage.Body;
        }

        protected void DeleteMessageClicked(object o, EventArgs e)
        {
            var r = new MessageRecipientServices().GetByRecipientMessageID(SecurityContextManager.Current.CurrentUser.ID, CurrentMessage.ID);
            if (r != null)
            {
                r.MessageFolderID = (int)MessageFolder.TRASH;
                new MessageRecipientServices().Save(r);
                Response.Redirect("/Messages");
            }
        }

        protected void ArchiveMessageClicked(object o, EventArgs e)
        {
            var r = new MessageRecipientServices().GetByRecipientMessageID(SecurityContextManager.Current.CurrentUser.ID, CurrentMessage.ID);
            if (r != null)
            {
                r.MessageFolderID = (int)MessageFolder.ARCHIVE;
                new MessageRecipientServices().Save(r);
                Response.Redirect("/Messages");
            }
        }

       
        private void BuildRecipientList(HRR.Core.Domain.Message msg)
        {
            BuildRecipients(this.tbTo.Entries, msg, (int)RecipientType.TO);
            BuildRecipients(this.tbCc.Entries, msg, (int)RecipientType.CC);
            BuildRecipients(this.tbBcc.Entries, msg, (int)RecipientType.BCC);
            

            //entries = this.tbCc.Entries;
            //for (int i = 0; i < entries.Count; i++)
            //{
            //    var p = new PersonServices().GetByEmail(entries[i].Value);
            //    var r = new MessageRecipient();
            //    r.MessageFolderID = (int)MessageFolder.INBOX;
            //    r.MessageStatusTypeID = (int)MessageStatusType.UNREAD;
            //    r.RecipientID = p.ID;
            //    r.RecipientTypeID = (int)RecipientType.CC;
            //    r.MessageID = msg.ID;
            //    new MessageRecipientServices().Save(r);
            //    var sentby = new PersonServices().GetByID(msg.SentBy);
            //    EmailHelper.SendMessageNotification(msg, p);
            //}

            //entries = this.tbBcc.Entries;
            //for (int i = 0; i < entries.Count; i++)
            //{
            //    var p = new PersonServices().GetByEmail(entries[i].Value);
            //    var r = new MessageRecipient();
            //    r.MessageFolderID = (int)MessageFolder.INBOX;
            //    r.MessageStatusTypeID = (int)MessageStatusType.UNREAD;
            //    r.RecipientID = p.ID;
            //    r.RecipientTypeID = (int)RecipientType.BCC;
            //    r.MessageID = msg.ID;
            //    new MessageRecipientServices().Save(r);
            //    var sentby = new PersonServices().GetByID(msg.SentBy);
            //    EmailHelper.SendMessageNotification(msg, p);
            //}
        }

        private void BuildRecipients(AutoCompleteBoxEntryCollection entries, HRR.Core.Domain.Message msg, int recipientType)
        {
            for (int i = 0; i < entries.Count; i++)
            {
                if (entries[i].Value.StartsWith("team:"))
                {
                    var t = new TeamServices().GetByID(Convert.ToInt32(entries[i].Value.Replace("team:", "")));
                    foreach (var m in t.Members)
                    {
                        var r = new MessageRecipient();
                        r.MessageFolderID = (int)MessageFolder.INBOX;
                        r.MessageStatusTypeID = (int)MessageStatusType.UNREAD;
                        r.RecipientID = m.PersonID;
                        r.RecipientTypeID = recipientType;
                        r.MessageID = msg.ID;
                        new MessageRecipientServices().Save(r);
                        var sentby = new PersonServices().GetByID(msg.SentBy);
                        EmailHelper.SendMessageNotification(msg, m.PersonRef);
                    }
                }
                else
                {
                    var p = new PersonServices().GetByEmail(entries[i].Value);
                    var r = new MessageRecipient();
                    r.MessageFolderID = (int)MessageFolder.INBOX;
                    r.MessageStatusTypeID = (int)MessageStatusType.UNREAD;
                    r.RecipientID = p.ID;
                    r.RecipientTypeID = recipientType;
                    r.MessageID = msg.ID;
                    new MessageRecipientServices().Save(r);
                    var sentby = new PersonServices().GetByID(msg.SentBy);
                    EmailHelper.SendMessageNotification(msg, p);
                }
            }
        }

        private string BuildBccList()
        {
            string s = "";
            AutoCompleteBoxEntryCollection entries = this.tbBcc.Entries;
            for (int i = 0; i < entries.Count; i++)
            {
                s += entries[i].Value + ",";
            }
            if (s.Length > 3)
            {
                return s.Substring(0, s.Length - 1);
            }
            return s;
        }
    }
}