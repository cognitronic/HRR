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
using HRR.Core;
using System.Text;
using HRR.Web.Utils;
using System.Configuration;
using Telerik.Web.UI;
using System.Drawing;
using System.IO;

namespace HRRV2.Website
{
    public partial class ImportStaff : HRRBasePage
    {
        #region Declarations

        string[] emaillist = { };
        int emailsAdded = 0;
        int duplicateEmails = 0;
        List<int> tags = new List<int>();
        IList<Person> subscribers = new List<Person>();
        #endregion

        #region Properties
        private IList<Person> ImportedEmployees
        {
            get
            {
                if (Session["ImportedEmployees"] != null)
                {
                    return (IList<Person>)Session["ImportedEmployees"];
                }
                return null;
            }
            set
            {
                Session["ImportedEmployees"] = value;
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImportClicked(object o, EventArgs e)
        {
            UpdateProgressContext();
            ImportSubscriberList();
        }

        private void UpdateProgressContext()
        {
            const int total = 100;

            RadProgressContext progress = RadProgressContext.Current;
            progress.Speed = "N/A";

            for (int i = 0; i < total; i++)
            {
                progress.PrimaryTotal = 1;
                progress.PrimaryValue = 1;
                progress.PrimaryPercent = 100;

                progress.SecondaryTotal = total;
                progress.SecondaryValue = i;
                progress.SecondaryPercent = i;

                progress.CurrentOperationText = "Percentage complete: " + i.ToString();

                if (!Response.IsClientConnected)
                {
                    //Cancel button was clicked or the browser was closed, so stop processing
                    break;
                }

                progress.TimeEstimated = (total - i) * 100;
                //Stall the current thread for 0.1 seconds
                System.Threading.Thread.Sleep(100);
            }
        }

        private void ImportSubscriberList()
        {
            if (ruImport.UploadedFiles.Count > 0)
            {
                foreach (UploadedFile validFile in ruImport.UploadedFiles)
                {
                    using (StreamReader reader = new StreamReader(validFile.InputStream))
                    {
                        emaillist = reader.ReadToEnd().Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    }
                }
            }

            foreach (var email in emaillist)
            {
                if (!new PersonServices().IsDuplicate(email))
                {
                    var person = new Person();
                    var vals = email.Split(',');
                    person.FirstName = vals[0];
                    person.LastName = vals[1];
                    person.Email = vals[2];
                    person.AccountID = SecurityContextManager.Current.CurrentUser.AccountID;
                    person.AvatarPath = ResourceStrings.GravatarBasePath + DateTime.Now.ToBinary().ToString().Replace("-","") + "?d=identicon&s=";
                    person.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
                    person.DateCreated = DateTime.Now;
                    person.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
                    person.IsActive = false;
                    person.LastUpdated = DateTime.Now;
                    person.Password = person.FirstName.ToLower() + person.LastName.ToLower();
                    person.UserName = person.Email;
                    new PersonServices().Save(person);
                    subscribers.Add(person);
                    emailsAdded++;
                }
                else
                {
                    duplicateEmails++;
                }
            }
            ImportedEmployees = subscribers;
            lblReadyForImport.Text = emaillist.Length.ToString();
            lblEmailsImported.Text = emailsAdded.ToString();
            lblEmailsSkipped.Text = duplicateEmails.ToString();
        }
    }
}