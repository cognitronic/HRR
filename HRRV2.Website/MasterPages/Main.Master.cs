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

namespace HRRV2.Website.MasterPages
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SecurityContextManager.Current != null)
            {
                lbName.Text = SecurityContextManager.Current.CurrentUser.Name;
                lblProfileName.Text = SecurityContextManager.Current.CurrentProfile.Name;
                lblProfileTitle.Text = SecurityContextManager.Current.CurrentProfile.Title;
                if (((Person)SecurityContextManager.Current.CurrentUser).AvatarPath.StartsWith("http://"))
                {
                    imgCurrentUserAvatar.ImageUrl = ((Person)SecurityContextManager.Current.CurrentUser).AvatarPath + "25";
                }
                else
                {
                    HRR.Web.Utils.ImageResize.ResizeImage(25, ResourceStrings.AvatarBasePath + ((Person)SecurityContextManager.Current.CurrentUser).AvatarPath, imgCurrentUserAvatar);
                    imgCurrentUserAvatar.ResizeMode = Telerik.Web.UI.BinaryImageResizeMode.Fit;
                }

                if (((Person)SecurityContextManager.Current.CurrentProfile).AvatarPath.StartsWith("http://"))
                {
                    rbiCurrentProfile.ImageUrl = ((Person)SecurityContextManager.Current.CurrentProfile).AvatarPath + "40";
                }
                else
                {
                    HRR.Web.Utils.ImageResize.ResizeImage(40, ResourceStrings.AvatarBasePath + ((Person)SecurityContextManager.Current.CurrentProfile).AvatarPath, rbiCurrentProfile);
                    rbiCurrentProfile.ResizeMode = Telerik.Web.UI.BinaryImageResizeMode.Fit;
                }


                if (((Person)SecurityContextManager.Current.CurrentUser).RoleID < (int)SecurityRole.EXECUTIVE_MANAGEMENT)
                {

                    //if (((Person)SecurityContextManager.Current.CurrentUser).RoleID < (int)SecurityRole.MANAGER)
                    //{
                    //    ulReports.Visible = false;
                    //}
                    //ulSettings.Visible = false;
                    //ulBlog.Visible = false;
                    //ulPolls.Visible = false;
                }
            }
        }

        protected void ProfileClicked(object o, EventArgs e)
        {
            Response.Redirect("/People/" + ((Person)SecurityContextManager.Current.CurrentProfile).Email + "/Edit");
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
    }
}