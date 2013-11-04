using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Configuration;
using IdeaSeed.Core.Mail;
using System.Web.UI.HtmlControls;
using IdeaSeed.Web.UI;
using HRR.Services;
using HRR.Core.Security;
using HRR.Core.Domain;
using HRR.Core;
using System.Web.Security;

namespace HRR.Website.MasterPages
{
    public partial class Main : System.Web.UI.MasterPage
    {
        
        public HtmlGenericControl MasterProfileInfo
        {
            get
            {
                return divProfileInfo;
            }
        }

        public IdeaSeed.Web.UI.LinkButton MasterProfilePicLink
        {
            get
            {
                return lbProfilePic;
            }
        }

        public Telerik.Web.UI.RadBinaryImage ProfileImage
        {
            get
            {
                return rbiProfile;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.Url.Segments.Count() > 1)
            {
                switch (HttpContext.Current.Request.Url.Segments[1])
                {
                    case "Overview/":
                    case "Overview":
                        ulOverview.Attributes["class"] = "my-list-selected list-1";
                        break;
                    case "People/":
                    case "People":
                        ulPeople.Attributes["class"] = "my-list-selected list-2";
                        break;
                    case "Comments/":
                    case "Comments":
                        ulComments.Attributes["class"] = "my-list-selected list-3";
                        break;
                    case "Goals/":
                    case "Goals":
                        ulGoals.Attributes["class"] = "my-list-selected list-4";
                        break;
                    case "Reviews/":
                    case "Reviews":
                        ulReviews.Attributes["class"] = "my-list-selected list-5";
                        break;
                    case "Reports/":
                    case "Reports":
                        ulReports.Attributes["class"] = "my-list-selected list-6";
                        break;
                    case "Messages/":
                    case "Messages":
                        ulMessages.Attributes["class"] = "my-list-selected list-8";
                        break;
                    case "Settings/":
                    case "Settings":
                        ulSettings.Attributes["class"] = "my-list-selected list-7";
                        break;
                    case "Blogs/":
                    case "Blogs":
                        ulBlog.Attributes["class"] = "my-list-selected list-9";
                        break;
                    case "Polls/":
                    case "Polls":
                        ulPolls.Attributes["class"] = "my-list-selected list-10";
                        break;
                }
            }
            else
            {
                ulOverview.Attributes["class"] = "my-list-selected list-1";
            }
            
            if (SecurityContextManager.Current != null)
            {
                if (SecurityContextManager.Current.CurrentProfile != null)
                {
                    ApplyPageSecurity();

                    lbName.Text = SecurityContextManager.Current.CurrentProfile.Name;
                    HRR.Web.Utils.ImageResize.ResizeImage(180, ResourceStrings.AvatarBasePath +  ((Person)SecurityContextManager.Current.CurrentProfile).AvatarPath, rbiProfile);
                    rbiProfile.ResizeMode = Telerik.Web.UI.BinaryImageResizeMode.Fit;
                    //rbiProfile.ImageUrl = ((Person)SecurityContextManager.Current.CurrentProfile).AvatarPath;
                    lblTitle.Text = ((Person)SecurityContextManager.Current.CurrentProfile).Title;
                }
                else
                {
                    lbName.Text = SecurityContextManager.Current.CurrentUser.Name;
                    HRR.Web.Utils.ImageResize.ResizeImage(180, ResourceStrings.AvatarBasePath + ((Person)SecurityContextManager.Current.CurrentUser).AvatarPath, rbiProfile);
                    rbiProfile.ResizeMode = Telerik.Web.UI.BinaryImageResizeMode.Fit;
                    lblTitle.Text = ((Person)
                        SecurityContextManager.Current.CurrentUser).Title;
                    divEditProfilePanel.Visible = true;
                }
                if (((Person)SecurityContextManager.Current.CurrentUser).RoleID < (int)SecurityRole.EXECUTIVE_MANAGEMENT)
                {

                    if (((Person)SecurityContextManager.Current.CurrentUser).RoleID < (int)SecurityRole.MANAGER)
                    {
                        ulReports.Visible = false;
                    }
                    ulSettings.Visible = false;
                    ulBlog.Visible = false;
                    ulPolls.Visible = false;
                }
            }
        }

        protected void LogoutClicked(object o, EventArgs e)
        {

            if (SecurityContextManager.Current != null)
            {
                SecurityServices.ClearUserCouchbaseCache((Person)SecurityContextManager.Current.CurrentUser);
                SecurityContextManager.Current.LogEvent(SecurityContextManager.Current.CurrentUser.ID, DateTime.Now, (int)ApplicationLogTypes.USER_LOGOUT, SecurityContextManager.Current.CurrentUser.AccountID, "User clicked logout button", "", "");
            }
            SecurityContextManager.Current = null;
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Response.Cookies.Clear();
            FormsAuthentication.SignOut();
            HttpContext.Current.Response.Redirect(ResourceStrings.Page_Login);

        }

        protected void EditProfileClicked(object o, EventArgs e)
        {
            if (SecurityContextManager.Current.CurrentProfile != null)
            {
                Response.Redirect("/People/" + SecurityContextManager.Current.CurrentProfile.Email + "/Edit");
            }
            else if (SecurityContextManager.Current.CurrentUser != null)
            {
                Response.Redirect("/People/" + SecurityContextManager.Current.CurrentUser.Email + "/Edit");
            }
        }

        protected void ProfileClicked(object o, EventArgs e)
        {
            if (SecurityContextManager.Current.CurrentProfile != null)
            {
                Response.Redirect("/People/" + SecurityContextManager.Current.CurrentProfile.Email);
            }
            else if (SecurityContextManager.Current.CurrentUser != null)
            {
                Response.Redirect("/People/" + SecurityContextManager.Current.CurrentUser.Email);
            }
        }

        private void ApplyPageSecurity()
        {
            divEditProfilePanel.Visible = false;
            if (((Person)SecurityContextManager.Current.CurrentUser).RoleID == (int)SecurityRole.ADMIN)
            {
                divEditProfilePanel.Visible = true;
            }
            else if (SecurityContextManager
            .Current
            .CurrentUser
            .ID == SecurityContextManager.Current.CurrentProfile.ID)
            {
                divEditProfilePanel.Visible = true;
            }
        }
    }
}