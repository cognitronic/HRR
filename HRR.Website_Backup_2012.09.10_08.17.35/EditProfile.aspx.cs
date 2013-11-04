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
using System.Text;
using HRR.Core;

namespace HRR.Website
{
    public partial class EditProfile : HRRBasePage
    {

        const int MaxTotalBytes = 1048576; // 1 MB
        int totalBytes;
        private Person _currentProfile = null;
        private Person CurrentProfile
        {
            get
            {
                
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
                totalBytes += e.UploadedFile.ContentLength;
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
            if (!IsPostBack)
            {
                this.Master.MasterProfileInfo.Visible = false;
                this.Master.MasterProfilePicLink.Enabled = false;
                LoadProfile();
                LoadDocuments(true);
                LoadAbsences(true);
                LoadTabRecordCount();
                if (((Person)SecurityContextManager.Current.CurrentUser).RoleID < (int)SecurityRole.ADMIN)
                {
                    ddlManager.Enabled = false;
                    divAbsenceTracking.Visible = false;
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

        protected void SaveDocumentClicked(object o, EventArgs e)
        {
            SaveDocument();
        }

        protected void CancelDocumentClicked(object o, EventArgs e)
        {
            Response.Redirect(SecurityContextManager.Current.PreviousURL);
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            if (SecurityContextManager.Current != null)
            {
                SecurityContextManager.Current.CurrentProfile = null;
            }
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

        private void LoadProfile()
        {
            if (CurrentProfile != null)
            {
                if (((Person)SecurityContextManager.Current.CurrentUser).RoleID == (int)SecurityRole.ADMIN)
                {
                    divHROnly.Visible = true;
                }
                else
                {
                    divHROnly.Visible = false;
                }
                lblName.Text = CurrentProfile.Name;
                tbFirstName.Text = CurrentProfile.FirstName;
                tbLastName.Text = CurrentProfile.LastName;
                tbEmail.Text = CurrentProfile.Email;
                tbTitle.Text = CurrentProfile.Title;
                ddlDepartments.SelectedValue = CurrentProfile.DepartmentID.ToString();
                ddlManager.SelectedValue = CurrentProfile.ManagerID.ToString();
                ddlSecurityRole.SelectedValue = CurrentProfile.RoleID.ToString();
                tbBirthdate.SelectedDate = CurrentProfile.Birthdate;
                tbFacebookURL.Text = CurrentProfile.FacebookPath;
                tbHireDate.SelectedDate = CurrentProfile.HireDate;
                tbLinkedInURL.Text = CurrentProfile.LinkedInPath;
                tbSecurityAnswer.Text = CurrentProfile.PasswordAnswer;
                tbSecurityQuestion.Text = CurrentProfile.PasswordQuestion;
                if(CurrentProfile.TerminationDate != null)
                    tbTerminationDate.SelectedDate = CurrentProfile.TerminationDate;
                tbTwitterURL.Text = CurrentProfile.TwitterPath;
                cbIsActive.Checked = CurrentProfile.IsActive;
                cbIsManager.Checked = CurrentProfile.IsManager;
                //cbCommentNotifications.Checked = CurrentProfile.ReceiveCommentNotifications;

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
                    CurrentProfile.ReceiveCommentNotifications = true;
                    CurrentProfile.HireDate = (DateTime)tbHireDate.SelectedDate;
                    if (tbTerminationDate.SelectedDate != null)
                    {
                        CurrentProfile.TerminationDate = (DateTime)tbTerminationDate.SelectedDate;
                    }
                    CurrentProfile.RoleID = Convert.ToInt16(ddlSecurityRole.SelectedValue);
                }
                CurrentProfile.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
                CurrentProfile.LastUpdated = DateTime.Now;
                url = SecurityContextManager.Current.CurrentURL;
            }
            else
            {
                CurrentProfile = new Person();
                CurrentProfile.AccountID = ((Person)SecurityContextManager.Current.CurrentUser).AccountID;
                if (((Person)SecurityContextManager.Current.CurrentUser).RoleID == (int)SecurityRole.ADMIN)
                {
                    CurrentProfile.IsActive = cbIsActive.Checked;
                    CurrentProfile.ReceiveCommentNotifications = true;
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
                CurrentProfile.AvatarPath = ResourceStrings.DummyImagePath;
            }


            CurrentProfile.FirstName = tbFirstName.Text;
            CurrentProfile.LastName = tbLastName.Text;
            CurrentProfile.Email = tbEmail.Text;
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
            CurrentProfile.FacebookPath = tbFacebookURL.Text;
            CurrentProfile.TwitterPath = tbTwitterURL.Text;
            CurrentProfile.LinkedInPath = tbLinkedInURL.Text;

            if (radAsyncUpload.UploadedFiles.Count > 0)
            {
                UploadedFile file = radAsyncUpload.UploadedFiles[0];
                string filePath = DateTime.Now.Ticks.ToString() + "_" +
                    file.FileName;
                //string filePath = file.FileName;
                file.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["AVATARIMAGEPATH"]) + filePath, false);
                CurrentProfile.AvatarPath = ConfigurationManager.AppSettings["AVATARIMAGEPATH"] + filePath;
            }

            new PersonServices().Save(CurrentProfile);
            if (SecurityContextManager.Current.CurrentUser.ID == CurrentProfile.ID)
                SecurityContextManager.Current.CurrentUser.AvatarPath = CurrentProfile.AvatarPath;
            if (string.IsNullOrEmpty(url))
                url = "/People/" + CurrentProfile.Email + "/Edit";
            Response.Redirect(url);
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
            d.Description = tbDocumentDescription.Text;
            d.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
            d.LastUpdated = DateTime.Now;
            if (rauDocument.UploadedFiles.Count > 0)
            {
                UploadedFile file = rauDocument.UploadedFiles[0];
                string filePath = DateTime.Now.Ticks.ToString() + "_" +
                    file.FileName.Replace("-", "_");
                if (!System.IO.Directory.Exists(ConfigurationManager.AppSettings["EMPLOYEEDOCUMENTPATH"] + CurrentProfile.AccountRef.Company.Replace(" ", "_").Replace(",", "_")))
                {
                    System.IO.Directory.CreateDirectory(ConfigurationManager.AppSettings["EMPLOYEEDOCUMENTPATH"] + CurrentProfile.AccountRef.Company.Replace(" ", "_").Replace(",", "_"));
                }
                file.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["EMPLOYEEDOCUMENTURL"]) + CurrentProfile.AccountRef.Company.Replace(" ", "_").Replace(",", "_") + "/" + filePath, true);
                d.Path = ConfigurationManager.AppSettings["EMPLOYEEDOCUMENTURL"] + CurrentProfile.AccountRef.Company.Replace(" ", "_") + "/" + filePath;
            }
            d.PersonID = CurrentProfile.ID;
            d.Title = tbDocumentTitle.Text;
            new DocumentServices().Save(d);
            tbDocumentDescription.Text = "";
            tbDocumentTitle.Text = "";
            LoadDocuments(true);
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

        private void LoadTabRecordCount()
        {
            if (CurrentProfile != null)
            {
                if (CurrentProfile.Documents.Count > 0)
                {
                    rtsProfile.Tabs.FindTabByValue("1").Text = "";
                    rtsProfile.Tabs.FindTabByValue("1").Text += "documents (" + CurrentProfile.Documents.Count.ToString() + ")";
                }
                if (CurrentProfile.Absences.Count > 0)
                {
                    rtsProfile.Tabs.FindTabByValue("2").Text = "";
                    rtsProfile.Tabs.FindTabByValue("2").Text += "absences (" + CurrentProfile.Absences.Count.ToString() + ")";
                }
            }
        }
    }
}