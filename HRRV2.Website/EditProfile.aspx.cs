using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRR.Core.Domain;
using HRR.Services;
using HRR.Core.Security;
using HRR.Web.Bases;
using HRR.Web.Utils;
using Telerik.Web.UI;
using System.Configuration;
using IdeaSeed.Core;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using HRR.Core;
using System.IO;

namespace HRRV2.Website
{
    public partial class EditProfile : HRRBasePage
    {
        ICacheStorage _cache = new MemcacheCacheAdapter();
        const int MaxTotalBytes = 1048576; // 1 MB
        int totalBytes;
        private Person _currentProfile = null;
        private Person CurrentProfile
        {
            get
            {
                if (SecurityContextManager.Current.CurrentProfile == null)
                {
                    _currentProfile = new PersonServices().GetByEmail(Request.Url.Segments[Request.Url.Segments.Length - 2].Replace("/", ""));
                    return _currentProfile;
                }
                return SecurityContextManager.Current.CurrentProfile;
            }
            set
            {
                _currentProfile = value;
                SecurityContextManager.Current.CurrentProfile = _currentProfile;
            }
        }

        public bool? IsRadAsyncValid
        {
            get
            {
                if (Session["IsRadAsyncValid"] == null)
                {
                    Session["IsRadAsyncValid"] = true;
                }

                return Convert.ToBoolean(Session["IsRadAsyncValid"].ToString());
            }
            set
            {
                Session["IsRadAsyncValid"] = value;
            }
        }

        public void RadAsyncUpload1_ValidatingFile(object sender, Telerik.Web.UI.Upload.ValidateFileEventArgs e)
        {
            if ((totalBytes < MaxTotalBytes) && (e.UploadedFile.ContentLength < MaxTotalBytes))
            {
                e.IsValid = true;
                totalBytes += (int)e.UploadedFile.ContentLength;
                IsRadAsyncValid = true;
            }
            else
            {
                e.IsValid = false;
                IsRadAsyncValid = false;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (CurrentProfile != null &&
                SecurityContextManager
                .Current
                .CurrentUser
                .ID != CurrentProfile.ID)
            {
                if (((Person)SecurityContextManager.Current.CurrentUser).RoleID < (int)SecurityRole.EXECUTIVE_MANAGEMENT)
                {
                    Response.Redirect(SecurityContextManager.Current.PreviousURL);
                }
            }
            if (!IsPostBack)
            {
                //this.Master.MasterProfileInfo.Visible = false;
                //this.Master.MasterProfilePicLink.Enabled = false;
                LoadProfile();
                LoadDocuments(true);
                LoadAbsences(true);
                //LoadTabRecordCount();
                if (((Person)SecurityContextManager.Current.CurrentUser).RoleID < (int)SecurityRole.ADMIN)
                {
                    ddlManager.Enabled = false;
                    divAbsencesContent.Visible = false;
                }
            }
        }

        protected void SaveClicked(object o, EventArgs e)
        {
            SaveProfile();
        }

        protected void CancelClicked(object o, EventArgs e)
        {
            Response.Redirect(SecurityContextManager.Current.PreviousURL);
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            if (SecurityContextManager.Current != null)
            {
                SecurityContextManager.Current.CurrentProfile = (Person)SecurityContextManager.Current.CurrentUser;
            }
        }

        #region Documents
        protected void SaveDocumentClicked(object o, EventArgs e)
        {
            SaveDocument();
        }

        protected void CancelDocumentClicked(object o, EventArgs e)
        {
            Response.Redirect(SecurityContextManager.Current.PreviousURL);
        }

        protected void DocumentDeleteClicked(object o, EventArgs e)
        {
            var d = new DocumentServices().GetByID(Convert.ToInt32((o as LinkButton).Attributes["itemid"]));
            new DocumentServices().Delete(d);
            LoadDocuments(true);

        }

        protected void DocumentsNeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadDocuments(false);
        }

        protected void DocumentsItemCommand(object o, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.InitInsertCommandName)
            {
                e.Canceled = true;
                var i = new HRR.Core.Domain.Document();
                i.ChangedBy = 0;
                i.Description = "";
                i.IsPrivate = false;
                i.Path = "";
                i.DateCreated = DateTime.Now;
                i.EnteredBy = 0;
                i.PersonID = 0;
                i.Title = "";
                i.ID = 0;
                e.Item.OwnerTableView.InsertItem(i);
            }

            if (e.CommandName == RadGrid.PerformInsertCommandName)
            {
                var t = new HRR.Core.Domain.Document();
                t.IsPrivate = (e.Item.FindControl("cbIsPrivate") as IdeaSeed.Web.UI.CheckBox).Checked;
                t.Title = (e.Item.FindControl("tbTitle") as IdeaSeed.Web.UI.TextBox).Text;
                t.Description = (e.Item.FindControl("tbDescription") as IdeaSeed.Web.UI.TextBox).Text;
                new DocumentServices().Save(t); IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();
            }
            if (e.CommandName == RadGrid.UpdateCommandName)
            {
                if (e.Item is GridEditableItem)
                {
                    var t = new DocumentServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                    t.IsPrivate = (e.Item.FindControl("cbIsPrivate") as IdeaSeed.Web.UI.CheckBox).Checked;
                    t.Title = (e.Item.FindControl("tbTitle") as IdeaSeed.Web.UI.TextBox).Text;
                    t.Description = (e.Item.FindControl("tbDescription") as IdeaSeed.Web.UI.TextBox).Text;
                    new DocumentServices().Save(t); IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();
                }
            }
            if (e.CommandName == RadGrid.DeleteCommandName)
            {
                var t = new DocumentServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                new DocumentServices().Delete(t);
            }
            LoadDocuments(true);
        }

        protected void DocumentsItemCreated(object o, GridItemEventArgs e)
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

        private void LoadDocuments(bool bindData)
        {
            if (CurrentProfile != null)
            {
                rgDocuments.DataSource = new DocumentServices().GetByPersonID(CurrentProfile.ID);
                if (bindData)
                    rgDocuments.DataBind();
            }
        }

        private void SaveDocument()
        {
            var d = new Document();
            d.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
            d.DateCreated = DateTime.Now;
            d.IsPrivate = cbIsPrivate.Checked;
            d.Description = tbDocumentDescription.Text;
            d.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
            d.LastUpdated = DateTime.Now;
            if (rauDocument.UploadedFiles.Count > 0)
            {
                UploadedFile file = rauDocument.UploadedFiles[0];
                string filePath = DateTime.Now.Ticks.ToString() + "_" +
                    file.FileName.Replace(" ", "_").Replace("-", "_").Replace(",", "_");
                if (!System.IO.Directory.Exists(ConfigurationManager.AppSettings["EMPLOYEEDOCUMENTPATH"] + CurrentProfile.AccountRef.Company.Replace(" ", "_").Replace(",", "_")))
                {
                    System.IO.Directory.CreateDirectory(ConfigurationManager.AppSettings["EMPLOYEEDOCUMENTPATH"] + CurrentProfile.AccountRef.Company.Replace(" ", "_").Replace("-", "_").Replace(",", "_"));
                }
                file.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["EMPLOYEEDOCUMENTURL"]) + CurrentProfile.AccountRef.Company.Replace(" ", "_").Replace("-", "_").Replace(",", "_") + "/" + filePath, true);
                d.Path = ConfigurationManager.AppSettings["EMPLOYEEDOCUMENTURL"] + CurrentProfile.AccountRef.Company.Replace(" ", "_").Replace("-", "_").Replace(",", "_") + "/" + filePath;
            }
            d.PersonID = CurrentProfile.ID;
            d.Title = tbDocumentTitle.Text;
            new DocumentServices().Save(d);
            tbDocumentDescription.Text = "";
            tbDocumentTitle.Text = "";
            LoadDocuments(true);
        }
        #endregion

        private void LoadProfile()
        {
            if (CurrentProfile != null)
            {
                AuthorizeAccount(CurrentProfile.AccountID);
                if (((Person)SecurityContextManager.Current.CurrentUser).RoleID == (int)SecurityRole.ADMIN)
                {
                    divHROnly.Visible = true;
                }
                else
                {
                    divHROnly.Visible = false;
                }

                if (((Person)SecurityContextManager.Current.CurrentUser).RoleID < (int)SecurityRole.MANAGER ||
                    SecurityContextManager.Current.CurrentUser.ID == SecurityContextManager.Current.CurrentProfile.ID)
                {
                    divAbsencesContent.Visible = false;
                    divDocumentsContainer.Visible = false;
                }
                //lblName.Text = CurrentProfile.Name;
                tbFirstName.Text = CurrentProfile.FirstName;
                tbLastName.Text = CurrentProfile.LastName;
                tbEmail.Text = CurrentProfile.Email;
                tbTitle.Text = CurrentProfile.Title;
                ddlDepartments.SelectedValue = CurrentProfile.DepartmentID.ToString();
                ddlManager.SelectedValue = CurrentProfile.ManagerID.ToString();
                ddlSecurityRole.SelectedValue = CurrentProfile.RoleID.ToString();
                tbBirthdate.SelectedDate = CurrentProfile.Birthdate;
                //tbFacebookURL.Text = CurrentProfile.FacebookPath;
                tbHireDate.SelectedDate = CurrentProfile.HireDate;
                //tbLinkedInURL.Text = CurrentProfile.LinkedInPath;
                tbSecurityAnswer.Text = CurrentProfile.PasswordAnswer;
                tbSecurityQuestion.Text = CurrentProfile.PasswordQuestion;
                if (CurrentProfile.TerminationDate != null)
                    tbTerminationDate.SelectedDate = CurrentProfile.TerminationDate;
                //tbTwitterURL.Text = CurrentProfile.TwitterPath;
                cbIsActive.Checked = CurrentProfile.IsActive;
                cbIsManager.Checked = CurrentProfile.IsManager;
                cbReceivesNotifications.Checked = CurrentProfile.ReceiveCommentNotifications;
            }
            else
            {

                cbReceivesNotifications.Checked = true;
            }
        }

        private void SaveProfile()
        {
            string url = "";
            if (CurrentProfile != null)
            {
                if (((Person)SecurityContextManager.Current.CurrentUser).RoleID == (int)SecurityRole.ADMIN)
                {
                    CurrentProfile.IsActive = cbIsActive.Checked;
                    CurrentProfile.IsManager = cbIsManager.Checked;
                    CurrentProfile.HireDate = (DateTime)tbHireDate.SelectedDate;
                    if (tbTerminationDate.SelectedDate != null)
                    {
                        CurrentProfile.TerminationDate = (DateTime)tbTerminationDate.SelectedDate;
                    }
                    CurrentProfile.RoleID = Convert.ToInt16(ddlSecurityRole.SelectedValue);
                }
                url = SecurityContextManager.Current.CurrentURL;
            }
            else
            {
                CurrentProfile = new Person();
                CurrentProfile.DateCreated = DateTime.Now;
                CurrentProfile.AcceptedTerms = false;
                CurrentProfile.AccountID = ((Person)SecurityContextManager.Current.CurrentUser).AccountID;
                if (((Person)SecurityContextManager.Current.CurrentUser).RoleID == (int)SecurityRole.ADMIN)
                {
                    CurrentProfile.IsActive = cbIsActive.Checked;
                    CurrentProfile.IsManager = cbIsManager.Checked;
                    CurrentProfile.HireDate = (DateTime)tbHireDate.SelectedDate;
                    if (tbTerminationDate.SelectedDate != null)
                    {
                        CurrentProfile.TerminationDate = (DateTime)tbTerminationDate.SelectedDate;
                    }
                    CurrentProfile.RoleID = Convert.ToInt16(ddlSecurityRole.SelectedValue);
                }
                CurrentProfile.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
                CurrentProfile.DateCreated = DateTime.Now;
                CurrentProfile.AvatarPath = ResourceStrings.DefaultImageNotFound;
            }

            CurrentProfile.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
            CurrentProfile.LastUpdated = DateTime.Now;
            CurrentProfile.FirstName = tbFirstName.Text;
            CurrentProfile.LastName = tbLastName.Text;
            CurrentProfile.Email = tbEmail.Text;
            //CurrentProfile.DateAcceptedTerms = DateTime.Now;
            CurrentProfile.Title = tbTitle.Text;
            CurrentProfile.Birthdate = (DateTime)tbBirthdate.SelectedDate;
            CurrentProfile.DepartmentID = Convert.ToInt16(ddlDepartments.SelectedValue);
            CurrentProfile.ManagerID = Convert.ToInt16(ddlManager.SelectedValue);
            if (!string.IsNullOrEmpty(tbPassword.Text))
            {
                CurrentProfile.Password = IdeaSeed.Core.SecurityUtils.GetMd5Hash(tbPassword.Text);
            }
            CurrentProfile.PasswordAnswer = tbSecurityAnswer.Text;
            CurrentProfile.PasswordQuestion = tbSecurityQuestion.Text;
            CurrentProfile.FacebookPath = "";// tbFacebookURL.Text;
            CurrentProfile.TwitterPath = "";// tbTwitterURL.Text;
            CurrentProfile.LinkedInPath = "";// tbLinkedInURL.Text;
            CurrentProfile.ReceiveCommentNotifications = cbReceivesNotifications.Checked;
            if (radAsyncUpload.UploadedFiles.Count > 0)
            {
                UploadedFile file = radAsyncUpload.UploadedFiles[0];
                string filePath = CurrentProfile.Email + "_" +
                    file.FileName.Replace(" ", "_").Replace("-", "_").Replace(",", "_");
                string thumbPath = "thumb_" + filePath;

                file.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["AVATARIMAGEPATH"]) + filePath, true);
                CurrentProfile.AvatarPath = filePath;

                //MemoryStream imgStream = new MemoryStream();
                //Bitmap newimg = new Bitmap(Server.MapPath(CurrentProfile.AvatarPath));
                //newimg.Save(imgStream, ImageFormat.Jpeg);
                byte[] data = HRR.Web.Utils.ImageResize.ResizeFromImagePath(50, ResourceStrings.AvatarBasePath + CurrentProfile.AvatarPath, CurrentProfile.AvatarPath);
                MemoryStream imgStream = new MemoryStream(data);
                System.Drawing.Image img = System.Drawing.Image.FromStream(imgStream);
                img.Save(Server.MapPath(ConfigurationManager.AppSettings["AVATARIMAGEPATH"] + thumbPath));

            }

            new PersonServices().Save(CurrentProfile);
            _cache.Remove(SecurityContextManager
                     .Current
                     .CurrentUser.ID.ToString() + "_DepartmentsList");
            if (SecurityContextManager.Current.CurrentUser.ID == CurrentProfile.ID)
                SecurityContextManager.Current.CurrentUser.AvatarPath = CurrentProfile.AvatarPath;
            //SecurityContextManager.Current.CurrentProfile = CurrentProfile;
            //SecurityContextManager.Current.CurrentUser = CurrentProfile;
            if (string.IsNullOrEmpty(url))
                url = "/People/" + CurrentProfile.Email + "/Edit";
            Response.Redirect(url);
        }

        #region Absence Tracking

        protected void SaveAbsenceClicked(object o, EventArgs e)
        {
            var a = new Absence();
            a.AbsentCategoryID = Convert.ToInt16(ddlType.SelectedValue);
            a.AccountID = SecurityContextManager.Current.CurrentAccount.ID;
            a.FromDate = (DateTime)tbFromDate.SelectedDate;
            a.ToDate = (DateTime)tbToDate.SelectedDate;
            a.DateCreated = DateTime.Now;
            a.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
            a.EnteredFor = CurrentProfile.ID;
            a.LastUpdated = DateTime.Now;
            a.Note = tbAbsenceNote.Text;
            new AbsenceServices().Save(a);
            ddlType.SelectedValue = "";
            tbAbsenceNote.Text = "";
            tbFromDate.SelectedDate = null;
            tbToDate.SelectedDate = null;
            LoadAbsences(true);
        }

        protected void CancelAbsenceClicked(object o, EventArgs e)
        {
            Response.Redirect(SecurityContextManager.Current.PreviousURL);
        }

        protected void AbsenceNeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadAbsences(false);
        }

        protected void AbsenceItemDataBound(object o, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                var edit = e.Item.FindControl("lbEdit") as IdeaSeed.Web.UI.LinkButton;
                var delete = e.Item.FindControl("lbDelete") as IdeaSeed.Web.UI.LinkButton;

                if (((Person)SecurityContextManager.Current.CurrentUser).RoleID < (int)SecurityRole.ADMIN)
                {
                    edit.Visible = false;
                    delete.Visible = false;
                }
            }
        }

        protected void AbsenceItemCreated(object o, GridItemEventArgs e)
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

        protected void AbsenceItemCommand(object o, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.InitInsertCommandName)
            {
                e.Canceled = true;
                var i = new HRR.Core.Domain.Absence();
                i.AbsentCategoryID = 0;
                i.AccountID = 0;
                i.FromDate = DateTime.Now;
                i.ToDate = DateTime.Now;
                i.DateCreated = DateTime.Now;
                i.EnteredBy = 0;
                i.EnteredFor = 0;
                i.LastUpdated = DateTime.Now;
                i.Note = "";
                i.ID = 0;
                e.Item.OwnerTableView.InsertItem(i);
            }

            if (e.CommandName == RadGrid.PerformInsertCommandName)
            {
                var t = new HRR.Core.Domain.Absence();
                t.AbsentCategoryID = Convert.ToInt16((e.Item.FindControl("ddlAbsence") as HRR.Web.Controls.AbsenceTypeDDL).SelectedValue);
                t.FromDate = (DateTime)(e.Item.FindControl("tbFromAbsent") as Telerik.Web.UI.RadDatePicker).SelectedDate;
                t.ToDate = (DateTime)(e.Item.FindControl("tbToAbsent") as Telerik.Web.UI.RadDatePicker).SelectedDate;
                t.Note = (e.Item.FindControl("tbNote") as IdeaSeed.Web.UI.TextBox).Text;
                new AbsenceServices().Save(t); IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();
            }
            if (e.CommandName == RadGrid.UpdateCommandName)
            {
                if (e.Item is GridEditableItem)
                {
                    var t = new AbsenceServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                    t.AbsentCategoryID = Convert.ToInt16((e.Item.FindControl("ddlAbsence") as HRR.Web.Controls.AbsenceTypeDDL).SelectedValue);
                    t.FromDate = (DateTime)(e.Item.FindControl("tbFromAbsent") as Telerik.Web.UI.RadDatePicker).SelectedDate;
                    t.ToDate = (DateTime)(e.Item.FindControl("tbToAbsent") as Telerik.Web.UI.RadDatePicker).SelectedDate;
                    t.Note = (e.Item.FindControl("tbNote") as IdeaSeed.Web.UI.TextBox).Text;
                    new AbsenceServices().Save(t); IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();
                }
            }
            if (e.CommandName == RadGrid.DeleteCommandName)
            {
                var t = new AbsenceServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                new AbsenceServices().Delete(t);
            }
            LoadAbsences(true);

        }

        private void LoadAbsences(bool bindData)
        {
            if (CurrentProfile != null)
            {
                rgAbsences.DataSource = new AbsenceServices().GetByEnteredFor(CurrentProfile.ID);
                if (bindData)
                    rgAbsences.DataBind();
            }
        }
        #endregion

        #region Notes
        protected void SaveNoteClicked(object o, EventArgs e)
        {
            SaveNote();
        }

        protected void CancelNoteClicked(object o, EventArgs e)
        {
            Response.Redirect(SecurityContextManager.Current.PreviousURL);
        }

        protected void NoteDeleteClicked(object o, EventArgs e)
        {
            var d = new NoteServices().GetByID(Convert.ToInt32((o as LinkButton).Attributes["itemid"]));
            new NoteServices().Delete(d);
            LoadNotes(true);

        }

        protected void NotesNeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadNotes(false);
        }

        protected void NotesItemCommand(object o, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.InitInsertCommandName)
            {
                e.Canceled = true;
                var i = new HRR.Core.Domain.Note();
                i.ChangedBy = 0;
                i.Body = "";
                i.DateCreated = DateTime.Now;
                i.EnteredBy = 0;
                i.Title = "";
                i.ID = 0;
                e.Item.OwnerTableView.InsertItem(i);
            }

            if (e.CommandName == RadGrid.PerformInsertCommandName)
            {
                var t = new HRR.Core.Domain.Note();
                t.Title = (e.Item.FindControl("tbTitle") as IdeaSeed.Web.UI.TextBox).Text;
                t.Body = (e.Item.FindControl("tbDescription") as IdeaSeed.Web.UI.TextBox).Text;
                new NoteServices().Save(t); IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();
            }
            if (e.CommandName == RadGrid.UpdateCommandName)
            {
                if (e.Item is GridEditableItem)
                {
                    var t = new NoteServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                    t.Title = (e.Item.FindControl("tbTitle") as IdeaSeed.Web.UI.TextBox).Text;
                    t.Body = (e.Item.FindControl("tbDescription") as IdeaSeed.Web.UI.TextBox).Text;
                    new NoteServices().Save(t); IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();
                }
            }
            if (e.CommandName == RadGrid.DeleteCommandName)
            {
                var t = new NoteServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                new NoteServices().Delete(t);
            }
            LoadNotes(true);
        }

        protected void NotesItemCreated(object o, GridItemEventArgs e)
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

        private void LoadNotes(bool bindData)
        {
            if (CurrentProfile != null)
            {
                rgNote.DataSource = new NoteServices().GetByEnteredFor(CurrentProfile.ID);
                if (bindData)
                    rgNote.DataBind();
            }
        }

        private void SaveNote()
        {
            var d = new Note();
            d.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
            d.DateCreated = DateTime.Now;
            d.Body = tbNoteBody.Text;
            d.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
            d.EnteredFor = SecurityContextManager.Current.CurrentProfile.ID;
            d.LastUpdated = DateTime.Now;
            d.NoteType = Convert.ToInt16(ddlNoteType.SelectedValue);
            d.Title = tbNoteTitle.Text;
            new NoteServices().Save(d);
            tbDocumentDescription.Text = "";
            tbDocumentTitle.Text = "";
            LoadNotes(true);
        }
        #endregion

        private void LoadTabRecordCount()
        {
            //if (CurrentProfile != null)
            //{
            //    if (CurrentProfile.Documents.Count > 0)
            //    {
            //        rtsProfile.Tabs.FindTabByValue("1").Text = "";
            //        rtsProfile.Tabs.FindTabByValue("1").Text += "documents (" + CurrentProfile.Documents.Count.ToString() + ")";
            //    }
            //    if (CurrentProfile.Absences.Count > 0)
            //    {
            //        rtsProfile.Tabs.FindTabByValue("2").Text = "";
            //        rtsProfile.Tabs.FindTabByValue("2").Text += "absences (" + CurrentProfile.Absences.Count.ToString() + ")";
            //    }
            //    if (CurrentProfile.Notes.Count > 0)
            //    {
            //        rtsProfile.Tabs.FindTabByValue("3").Text = "";
            //        rtsProfile.Tabs.FindTabByValue("3").Text += "notes (" + CurrentProfile.Notes.Count.ToString() + ")";
            //    }
            //}
        }
    }
}