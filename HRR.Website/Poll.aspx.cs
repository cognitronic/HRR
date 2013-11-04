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
    public partial class Poll : HRRBasePage
    {
        private HRR.Core.Domain.Poll CurrentPoll
        {
            get
            {
                if (!HttpContext.Current.Request.Url.PathAndQuery.Contains("New"))
                {
                    if (Session["CurrentPoll"] == null)
                    {
                        Session["CurrentPoll"] = new PollServices().GetByID(Convert.ToInt32(HttpContext.Current.Request.Url.Segments[HttpContext.Current.Request.Url.Segments.Count() - 1]));
                    }
                    return (HRR.Core.Domain.Poll)Session["CurrentPoll"];
                }
                return null;
            }
            set
            {
                Session["CurrentPoll"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadAutoSuggest();
            if (!IsPostBack)
            {
                if (CurrentPoll != null)
                {
                    divOptions.Visible = true;
                    LoadPoll(true);
                    divEditable.Visible = true;
                }
                else
                {
                    divOptions.Visible = false;
                    divEditable.Visible = false;
                }
            }
        }

        protected void NeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            if (CurrentPoll != null)
                LoadPoll(false);
        }

        protected void ItemCreated(object o, GridItemEventArgs e)
        {
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                if (!e.Item.OwnerTableView.IsItemInserted)
                {
                    LinkButton updateButton = (LinkButton)e.Item.FindControl("UpdateButton");
                    updateButton.Text = "Update ";
                    updateButton.CssClass = "button small round sky-blue";
                    updateButton.Style["margin-top"] = "15px !important";
                    updateButton.Style["margin-bottom"] = "15px !important";
                }
                else
                {
                    LinkButton insertButton = (LinkButton)e.Item.FindControl("PerformInsertButton");
                    insertButton.Text = "Insert";
                    insertButton.CssClass = "button small round sky-blue";
                    insertButton.Style["margin-top"] = "15px !important";
                    insertButton.Style["margin-bottom"] = "15px !important";
                }
                LinkButton cancelButton = (LinkButton)e.Item.FindControl("CancelButton");
                cancelButton.Text = "Cancel";
                cancelButton.CssClass = "button small round sky-blue";
                cancelButton.Style["margin-top"] = "15px !important";
                cancelButton.Style["margin-bottom"] = "15px !important";
            }
        }

        protected void CancelClicked(object o, EventArgs e)
        {
            Response.Redirect(SecurityContextManager.Current.PreviousURL);
        }

        protected void SaveClicked(object o, EventArgs e)
        {
            if (CurrentPoll != null)
            {
                //CurrentPoll.IsActive = cbIsActive.Checked;
                //CurrentPoll.EndDate = (DateTime)tbEndDate.SelectedDate;
                CurrentPoll.LastUpdated = DateTime.Now;
                CurrentPoll.Question = tbQuestion.Text;
                //CurrentPoll.StartDate = (DateTime)tbStartDate.SelectedDate;
                new PollServices().Save(CurrentPoll);
            }
            else
            {
                var p = new HRR.Core.Domain.Poll();
                p.IsActive = true;
                p.Question = tbQuestion.Text;
                p.EndDate = DateTime.Now.AddDays(14);
                p.StartDate = DateTime.Now;
                p.LastUpdated = DateTime.Now;
                p.DateCreated = DateTime.Now;
                p.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
                p.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
                p.AccountID = SecurityContextManager.Current.CurrentAccount.ID;
                new PollServices().Save(p);
                Response.Redirect("/Polls/" + p.ID.ToString());
            }
        }

        protected void CheckChanged(object o, EventArgs e)
        {
            if (cbSendToEveryone.Checked)
            {
                tbTo.Visible = false;
            }
            else 
            {
                tbTo.Enabled = true;
            }
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            CurrentPoll = null;
        }

        protected void ItemDataBound(object o, GridItemEventArgs e)
        {
            
        }

        protected void ItemCommand(object o, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.InitInsertCommandName)
            {
                e.Canceled = true;
                var i = new HRR.Core.Domain.PollOption();
                i.Title = "";
                i.PollID = 0;
                i.ID = 0;
                e.Item.OwnerTableView.InsertItem(i);
            }

            if (e.CommandName == RadGrid.PerformInsertCommandName)
            {
                var p = new HRR.Core.Domain.PollOption();
                p.Title = (e.Item.FindControl("tbTitle") as IdeaSeed.Web.UI.TextBox).Text;
                p.PollID = CurrentPoll.ID;
                new PollOptionServices().Save(p);
            }
            if (e.CommandName == RadGrid.UpdateCommandName)
            {
                if (e.Item is GridEditableItem)
                {
                    var p = new PollOptionServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                    p.Title = (e.Item.FindControl("tbTitle") as IdeaSeed.Web.UI.TextBox).Text;
                    p.PollID = CurrentPoll.ID;
                    new PollOptionServices().Save(p);
                }
            }
            if (e.CommandName == RadGrid.DeleteCommandName)
            {
                var p = new PollOptionServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                new PollOptionServices().Delete(p);
            }
            CurrentPoll = new PollServices().GetByID(Convert.ToInt32(HttpContext.Current.Request.Url.Segments[HttpContext.Current.Request.Url.Segments.Count() - 1]));
        }

        private void LoadPoll(bool bindData)
        {
            //cbIsActive.Checked = CurrentPoll.IsActive;
            tbQuestion.Text = CurrentPoll.Question;
            //tbStartDate.SelectedDate = CurrentPoll.StartDate;
            //tbEndDate.SelectedDate = CurrentPoll.EndDate;
            rgList.DataSource = CurrentPoll.Options;
            if (bindData)
                rgList.DataBind();

        }

        private void BuildRecipients(AutoCompleteBoxEntryCollection entries, HRR.Core.Domain.Message msg, int recipientType)
        {
            int total = 0;
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
                        EmailHelper.SendPollNotification(msg, m.PersonRef);
                        total++;
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
                    EmailHelper.SendPollNotification(msg, p);
                    total++;
                }
            }
            var poll = new PollServices().GetByID(CurrentPoll.ID);
            poll.TotalPolled = total;
            new PollServices().Save(poll);
        }

        private void BuildAllRecipients(HRR.Core.Domain.Message msg)
        {
            int total = 0;
            foreach (var p in new PersonServices().GetByAccountID(SecurityContextManager.Current.CurrentUser.AccountID))
            {
                if (p.ReceiveCommentNotifications)
                {
                    var r = new MessageRecipient();
                    r.MessageFolderID = (int)MessageFolder.INBOX;
                    r.MessageStatusTypeID = (int)MessageStatusType.UNREAD;
                    r.RecipientID = p.ID;
                    r.RecipientTypeID = (int)RecipientType.TO;
                    r.MessageID = msg.ID;
                    new MessageRecipientServices().Save(r);
                    var sentby = new PersonServices().GetByID(msg.SentBy);
                    EmailHelper.SendPollNotification(msg, p);
                    total++;
                }
            }
            var poll = new PollServices().GetByID(CurrentPoll.ID);
            poll.TotalPolled = total;
            new PollServices().Save(poll);
        }

        private void BuildRecipientList(HRR.Core.Domain.Message msg)
        {
            BuildRecipients(this.tbTo.Entries, msg, (int)RecipientType.TO);
        }

        protected void SendMessageClicked(object o, EventArgs e)
        {
            if (tbTo.Entries.Count > 0 || cbSendToEveryone.Checked)
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

                if (!cbSendToEveryone.Checked)
                {
                    BuildRecipientList(m);
                }
                else
                {
                    BuildAllRecipients(m);
                }
                Response.Redirect("/Polls");
            }
        }

        protected void CancelMessageClicked(object o, EventArgs e)
        {
            Response.Redirect(SecurityContextManager.Current.CurrentURL);
        }

        private void LoadAutoSuggest()
        {
            List<HRR.Core.Domain.Interfaces.IAutoSuggestRecipient> list = new MessageServices().GetAutoSuggestRecipients();
            tbTo.DataSource = list;
            tbTo.DataTextField = "Name";
            tbTo.DataValueField = "Email";
        }
    }
}