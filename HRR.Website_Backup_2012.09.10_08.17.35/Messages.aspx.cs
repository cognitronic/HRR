using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using HRR.Core.Domain;
using HRR.Services;
using HRR.Core.Security;
using HRR.Web.Bases;
using HRR.Web.Utils;
using Telerik.Web.UI;
using System.Configuration;
using IdeaSeed.Core;
using System.Text;
using HRR.Core;
using System.Data;

namespace HRR.Website
{
    public partial class Messages : HRRBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblCurrentFolder.Text = "Inbox";
                LoadMessages();
            }
        }

        protected void ActionSelectedIndexChanged(object o, EventArgs e)
        {
            switch (ddlActions.SelectedValue)
            { 
                case "0":
                    foreach (DataListItem i in dlMessages.Items)
                    {
                        var cb = (IdeaSeed.Web.UI.CheckBox)i.FindControl("cbSelected");
                        if (cb.Checked)
                        {
                            var m = new MessageRecipientServices()
                                .GetByID(
                                Convert.ToInt32(
                                cb.Attributes["itemid"]));
                            m.MessageStatusTypeID = (int)MessageStatusType.READ;
                            new MessageRecipientServices().Save(m);
                        }
                    }
                        LoadMessages();
                    break;
                case "1":
                    foreach (DataListItem i in dlMessages.Items)
                    {
                        var cb = (IdeaSeed.Web.UI.CheckBox)i.FindControl("cbSelected");
                        if (cb.Checked)
                        {
                            var m = new MessageRecipientServices()
                                .GetByID(
                                Convert.ToInt32(
                                cb.Attributes["itemid"]));
                            m.MessageStatusTypeID = (int)MessageStatusType.UNREAD;
                            new MessageRecipientServices().Save(m);
                        }
                    }
                        LoadMessages();
                    break;
                case "2":
                    foreach (DataListItem i in dlMessages.Items)
                    {
                        var cb = (IdeaSeed.Web.UI.CheckBox)i.FindControl("cbSelected");
                        if (cb.Checked)
                        {
                            var m = new MessageRecipientServices()
                                .GetByID(
                                Convert.ToInt32(
                                cb.Attributes["itemid"]));
                            m.MessageFolderID = (int)MessageFolder.ARCHIVE;
                            new MessageRecipientServices().Save(m);
                        }
                    }
                        LoadMessages();
                    break;
                case "3":
                    foreach (DataListItem i in dlMessages.Items)
                    {
                        var cb = (IdeaSeed.Web.UI.CheckBox)i.FindControl("cbSelected");
                        if (cb.Checked)
                        {
                            var m = new MessageRecipientServices()
                                .GetByID(
                                Convert.ToInt32(
                                cb.Attributes["itemid"]));
                            m.MessageFolderID = (int)MessageFolder.TRASH;
                            new MessageRecipientServices().Save(m);
                        }
                    }
                        LoadMessages();
                    break;
                case "4":
                    foreach (DataListItem i in dlMessages.Items)
                    {
                        var cb = (IdeaSeed.Web.UI.CheckBox)i.FindControl("cbSelected");
                        if (cb.Checked)
                        {
                            var m = new MessageRecipientServices()
                                .GetByID(
                                Convert.ToInt32(
                                cb.Attributes["itemid"]));
                            m.MessageStatusTypeID = (int)MessageStatusType.REPORT_TO_HR;
                            new MessageRecipientServices().Save(m);
                            foreach (var s in new NotificationSubscriberServices().GetByNotificationID((int)Notification.REPORT_MESSAGE_TO_HR))
                            {
                                var n = new MessageRecipient();
                                n.MessageFolderID = (int)MessageFolder.INBOX;
                                n.MessageID = m.MessageID;
                                n.MessageStatusTypeID = (int)MessageStatusType.UNREAD;
                                n.RecipientID = s.ID;
                                n.RecipientTypeID = (int)RecipientType.TO;
                                new MessageRecipientServices().Save(n);
                                var sb = new StringBuilder();
                                sb.Append(EmailHelper.EmailHTMLStart());
                                sb.Append("<div class='maincontainer'>");
                                sb.Append("<h2><span>Message Flagged For Review</span></h2>");
                                sb.Append("<div class='maincontent'>");
                                sb.Append(SecurityContextManager.Current.CurrentUser.Name);
                                sb.Append(" reported a message as inappropriate and has flagged it for your review.  Click here to view: <a href='");
                                sb.Append(ConfigurationManager.AppSettings["BASEURL"]);
                                sb.Append("/Messages/");
                                sb.Append(n.ID.ToString());
                                sb.Append("'>HRRiver.com</a></div></div>");
                                sb.Append(EmailHelper.EmailHTMLEnd());
                                IdeaSeed.Core.Mail.EmailUtils.SendEmail(n.RecipientRef.Email, "flagged@hrriver.com", "Message Flagged For Review", sb.ToString());
                            }
                        }
                    }
                            LoadMessages();
                    break;
            }
        }

        private void LoadMessages()
        {
            var list = new List<MessageRecipient>();
            switch (HttpContext.Current.Request.Url.Segments[HttpContext.Current.Request.Url.Segments.Count() - 1])
            { 
                case "Messages":
                case "Inbox":
                    list = new MessageRecipientServices()
                        .GetByRecipientFolderID(SecurityContextManager.Current.CurrentUser.ID, (int)MessageFolder.INBOX)
                        .OrderByDescending(o => o.MessageRef.DateCreated)
                        .ToList<MessageRecipient>();
                    lblCurrentFolder.Text = "Inbox";
                    divInboxNav.Attributes.Remove("class");
                    divInboxNav.Attributes["class"] = "selecteditem";
                    break;
                case "Sent":
                    list = new MessageRecipientServices()
                        .GetByRecipientFolderID(SecurityContextManager.Current.CurrentUser.ID, (int)MessageFolder.SENT)
                        .OrderByDescending(o => o.MessageRef.DateCreated)
                        .ToList<MessageRecipient>();
                    lblCurrentFolder.Text = "Sent";
                    divSentNav.Attributes.Remove("class");
                    divSentNav.Attributes["class"] = "selecteditem";
                    break;
                case "Archived":
                    list = new MessageRecipientServices()
                        .GetByRecipientFolderID(SecurityContextManager.Current.CurrentUser.ID, (int)MessageFolder.ARCHIVE)
                        .OrderByDescending(o => o.MessageRef.DateCreated)
                        .ToList<MessageRecipient>();
                    lblCurrentFolder.Text = "Archive";
                    divArchivedNav.Attributes.Remove("class");
                    divArchivedNav.Attributes["class"] = "selecteditem";
                    break;
                case "Trash":
                    list = new MessageRecipientServices()
                        .GetByRecipientFolderID(SecurityContextManager.Current.CurrentUser.ID, (int)MessageFolder.TRASH)
                        .OrderByDescending(o => o.MessageRef.DateCreated)
                        .ToList<MessageRecipient>();
                    lblCurrentFolder.Text = "Trash";
                    divTrashNav.Attributes.Remove("class");
                    divTrashNav.Attributes["class"] = "selecteditem";
                    break;
                default:
                    list = new MessageRecipientServices()
                        .GetByRecipientFolderID(SecurityContextManager.Current.CurrentUser.ID, (int)MessageFolder.INBOX)
                        .OrderByDescending(o => o.MessageRef.DateCreated)
                        .ToList<MessageRecipient>();
                    lblCurrentFolder.Text = "Inbox";
                    divInboxNav.Attributes.Remove("class");
                    divInboxNav.Attributes["class"] = "selecteditem";
                    break;

            }
            if (list.Count > 0)
            {
                lblNoMessages.Visible = false;
                dlMessages.DataSource = list;
                dlMessages.DataBind();
            }
            else
            {
                lblNoMessages.Visible = true;
                lblNoMessages.Text = "No Messages Found";
            }
        }

        protected void NewMessageClicked(object o, EventArgs e)
        {
            Response.Redirect("/Messages/New");
        }

        protected void MessagesItemDataBound(object o, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var r = e.Item.DataItem as MessageRecipient;
                if (r != null)
                {
                    if (r.MessageStatusTypeID != (int)MessageStatusType.UNREAD)
                    {
                        var title = e.Item.FindControl("spnTitle") as HtmlControl;
                        title.Attributes.Remove("style");
                        title.Attributes["style"] = "font-size: 10pt;";
                    }
                }
            }
        }

        protected void InboxClicked(object o, EventArgs e)
        {
            Response.Redirect("/Messages/Inbox");
        }

        protected void SentClicked(object o, EventArgs e)
        {
            Response.Redirect("/Messages/Sent");
        }

        protected void ArchivedClicked(object o, EventArgs e)
        {
            Response.Redirect("/Messages/Archived");
        }

        protected void TrashClicked(object o, EventArgs e)
        {
            Response.Redirect("/Messages/Trash");
        }
    }
}