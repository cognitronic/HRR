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

namespace HRRV2.Website
{
    public partial class AccountProfile : HRRBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAccount(); 
            }
        }

        #region Account Info

        protected void LoadAccount()
        {
            if (SecurityContextManager.Current.CurrentAccount != null)
            {
                tbDomain.Text = SecurityContextManager.Current.CurrentAccount.Domain;
                tbCompanyName.Text = SecurityContextManager.Current.CurrentAccount.Company;
                rbiProfile.DataValue = HRR.Web.Utils.ImageResize.GetImageBytes(SecurityContextManager.Current.CurrentAccount.LogoPath);
                tbCommentsWeight.Text = SecurityContextManager.Current.CurrentAccount.CommentsWeight.ToString();
                tbGoalsWeight.Text = SecurityContextManager.Current.CurrentAccount.GoalsWeight.ToString();
                tbQuestionsWeight.Text = SecurityContextManager.Current.CurrentAccount.QuestionsWeight.ToString();
            }
        }

        protected void SaveAccountClicked(object o, EventArgs e)
        {
            if (SecurityContextManager.Current.CurrentAccount != null)
            {
                var a = new AccountServices().GetByID(SecurityContextManager.Current.CurrentAccount.ID);
                a.Company = tbCompanyName.Text.Replace("-", "_").Replace(",", "_");
                a.Domain = tbDomain.Text;
                a.CommentsWeight = Convert.ToInt16(tbCommentsWeight.Text);
                a.GoalsWeight = Convert.ToInt16(tbGoalsWeight.Text);
                a.QuestionsWeight = Convert.ToInt16(tbQuestionsWeight.Text);
                if (radAsyncUpload.UploadedFiles.Count > 0)
                {
                    UploadedFile file = radAsyncUpload.UploadedFiles[0];
                    string filePath = DateTime.Now.Ticks.ToString() + "_" +
                        file.FileName.Replace(" ", "_").Replace("-", "_").Replace(",", "_");
                    //string filePath = file.FileName;
                    file.SaveAs(Server.MapPath("/Images/companyLogos/") + filePath, false);
                    a.LogoPath = "/Images/companyLogos/" + filePath;
                }
                new AccountServices().Save(a);
                IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();
                SecurityContextManager.Current.CurrentAccount = a;
            }
        }

        protected void CancelAccountClicked(object o, EventArgs e)
        {
            Response.Redirect(SecurityContextManager.Current.PreviousURL);
        }
        #endregion
    }
}