﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using IdeaSeed.Web;
using System.Web;
using IdeaSeed.Core;
using IdeaSeed.Core.Utils;
using HRR.Web.Utils;
using System.Configuration;
using HRR.Web.Security;
using HRR.Core;
using HRR.Core.Security;
using HRR.Core.Domain;
using HRR.Services;
using Telerik.Web.UI;

namespace HRR.Web.Bases
{
    public class HRRBasePage : System.Web.UI.Page, IView
    {
        #region Declarations
        protected const string TITLE_TEXT = "{~ HRRiver ~} ";

        public event EventHandler InitView;
        public event EventHandler LoadView;
        public event EventHandler UnloadView;
        #endregion

        #region Properties
        public string ViewTitle { get; set; }
        public string Message { get; set; }
        #endregion

        #region Events

        #region Overriden Events
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            if (!HttpPageHelper.IsValidRequest)
            {
                HttpContext.Current.Response.Redirect(Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute(ResourceStrings.Page_Default));
            }

            try
            {
                if (SecurityContextManager.Current == null || SecurityContextManager.Current.CurrentUser == null || SecurityContextManager.Current.CurrentUser.ID == 0)
                {
                    HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                    string userData = ticket.UserData;
                    var response = new SecurityServices().AuthenticateUserCookie(userData.Split('_')[0], userData.Split('_')[2], "");
                    if (response.IsAuthenticated)
                    {
                        if (Request.QueryString["redirect"] != null)
                        {
                            Response.Redirect(Request.QueryString["redirect"]);
                        }
                        Response.Redirect(ResourceStrings.Page_Default);
                    }
                    else
                    {
                        if (Session[ResourceStrings.Session_CurrentUser] != null)
                        {
                            SecurityContextManager.Current = new WebSecurityContext();
                            SessionManager.Current = new WebSessionProvider();
                        }
                        else
                        {
                            new WebSecurityContext().SignOutUser();
                        }
                    }

                    
                }

                if (SecurityContextManager.Current.CurrentURL != SecurityContextManager.Current.BaseURL + HttpContext.Current.Request.UrlReferrer.AbsolutePath)
                {
                    SecurityContextManager.Current.PreviousURL = SecurityContextManager.Current.BaseURL + HttpContext.Current.Request.UrlReferrer.AbsolutePath;
                }
            }
            catch (Exception exc)
            {

            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (!Request.IsLocal && !Request.IsSecureConnection)
                Response.Redirect(Request.Url.ToString().Replace("http:", "https:"));

            if (SecurityContextManager.Current != null)
            {
                //SecurityContextManager.Current.CurrentPage = HttpPageHelper.CurrentPage;
                //SecurityContextManager.Current.CurrentAccessLevel = (AccessLevels)new SecurityServices().GetCurrentPageAccessLevel(SecurityContextManager.Current);
                //if (HttpPageHelper.CurrentItem != null)
                //    SessionManager.Current[ResourceStrings.Session_CurrentItem] = HttpPageHelper.CurrentItem;
            }
            InitializeSession();
            InitializeSecurityContextManagerValues();

            //SecurityContextManager.Current.CurrentManagedApplication = new ApplicationServices().GetByID(Convert.ToInt16(ConfigurationManager.AppSettings["APPLICATIONID"]));
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

        }

        protected void AuthorizeAccount(int accountid)
        {
            if (SecurityContextManager.Current != null)
            {
                if (SecurityContextManager.Current.CurrentUser.AccountID != accountid)
                {
                    new WebSecurityContext().LogEvent(SecurityContextManager.Current.CurrentUser.AccountID, DateTime.Now, (int)ApplicationLogTypes.SECURITY_ILLEGALACCESSATEMPT, ((Account)Session[HRR.Core.ResourceStrings.Session_Account]).ID, "Illegally tried to access another account. <br /><br /> Name:<br /><br />" + SecurityContextManager.Current.CurrentUser.Name, "", "");
                    SecurityContextManager.Current.SignOutUser();
                }
            }
        }

        protected override void OnSaveStateComplete(EventArgs e)
        {
            base.OnSaveStateComplete(e);

        }

        protected override void OnError(EventArgs e)
        {
            base.OnError(e);
            if (SecurityContextManager.Current == null || SecurityContextManager.Current.CurrentUser == null)
            {
                try
                {
                    IdeaSeed.Core.Mail.EmailUtils.SendEmail(ConfigurationManager.AppSettings["EMAILSUPPORT_TO"], ConfigurationManager.AppSettings["EMAILSUPPORT_FROM"], "", "", " Error occured and session gone: " + Server.GetLastError().Message + ".", Server.GetLastError().Message + "<br /><br /><br />Stack Trace:<br /><br />" + Server.GetLastError().StackTrace, false, "");
                    new WebSecurityContext().LogEvent(-1, DateTime.Now, (int)ApplicationLogTypes.EXCEPTION_UNHANDLED, ((Account)Session[HRR.Core.ResourceStrings.Session_Account]).ID, "Error occured and SecurityContext is null.  Error Message:<br /><br />" + Server.GetLastError().Message, "", "");
                    new WebSecurityContext().SignOutUser();
                }
                catch (Exception emailexc)
                {
                    new WebSecurityContext().SignOutUser();
                }
            }
            //if in development environment then I want to see the exception.
            if (!ConfigurationManager.AppSettings["ENVIRONMENT"].Equals("DEVELOPMENT"))
            {
                var aes = new ApplicationExceptionServices();
                var ae = new HRR.Core.Domain.ApplicationException();
                Exception ex = Server.GetLastError();
                if (ex != null && !string.IsNullOrEmpty(ex.ToString()))
                {
                    ae.AccountID = ((Person)SecurityContextManager.Current.CurrentUser).AccountID;
                    ae.ExceptionDate = DateTime.Now;
                    if (!string.IsNullOrEmpty(ex.GetType().Name.ToString()))
                    {
                        ae.ExceptionType = ex.GetType().Name.ToString();
                    }
                    else
                    {
                        ae.ExceptionType = "Type Not Found";
                    }
                    if (!string.IsNullOrEmpty(ex.Message))
                    {
                        ae.Message = ex.Message;
                    }
                    else
                    {
                        ae.Message = "Message Not Found";
                    }
                    if (!string.IsNullOrEmpty(ex.StackTrace))
                    {
                        ae.StackTrace = ex.StackTrace;
                    }
                    else
                    {
                        ae.StackTrace = "Stack Trace Not Found";
                    }
                    if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
                    {
                        ae.InnerMessage = ex.InnerException.Message;
                    }
                    else
                    {
                        ae.InnerMessage = "Inner Message Not Found";
                    }
                    ae.CurrentURL = HttpContext.Current.Request.Url.ToString();
                    ae.UserID = SecurityContextManager.Current.CurrentUser.ID;
                    //string session = "";
                    //int sessioncount = SessionManager.Current.;
                    //for (int i = 0; sessioncount > i; i++)
                    //{
                    //    session += HttpContext.Current.Session[i] + ", ";
                    //}
                    ae.SessionData = SessionManager.Current.ToString();
                    aes.Save(ae);
                    //Send exception to support
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<!DOCTYPE HTML PUBLIC '-//W3C//DTD HTML 4.0 Transitional//EN' >");
                    sb.Append("<html><body><table width='600px'><tr><td colspan='3'>");
                    sb.Append("<h4>Unexpected Error: ");
                    sb.Append(ae.ExceptionType);
                    sb.Append("</h4></td></tr>");
                    sb.Append("<tr><td>");
                    sb.Append("<b>When:</b> </td><td>");
                    sb.Append(ae.ExceptionDate);
                    sb.Append("</td></tr><tr><td>");
                    sb.Append("<b>URL:</b> </td><td>");
                    sb.Append(ae.CurrentURL);
                    sb.Append("</td></tr><tr><td>");
                    sb.Append("<b>Message:</b> </td><td>");
                    sb.Append(ae.Message);
                    sb.Append("</td></tr><tr><td>");
                    sb.Append("<b>Inner Message:</b> </td><td>");
                    sb.Append(ae.InnerMessage);
                    sb.Append("</td></tr><tr><td>");
                    sb.Append("<b>Stack Trace:</b> </td><td>");
                    sb.Append(ae.StackTrace);
                    sb.Append("</td></tr><tr><td>");
                    sb.Append("<b>Logged On User:</b> </td><td>");
                    sb.Append(((Person)SecurityContextManager.Current.CurrentUser).Name);
                    sb.Append("</td></tr><tr><td>");
                    sb.Append("<b>Session:</b> </td><td>");
                    sb.Append(ae.SessionData);
                    sb.Append("</td></tr><tr><td>");
                    sb.Append("</td></tr></table></body></html>");
                    try
                    {
                        IdeaSeed.Core.Mail.EmailUtils.SendEmail(ConfigurationManager.AppSettings["EMAILSUPPORT_TO"], ConfigurationManager.AppSettings["EMAILSUPPORT_FROM"], "", "", SecurityContextManager.Current.CurrentAccount.Company + " Support.  Unexpected Exception: " + ae.ExceptionType + ".", sb.ToString(), false, "");
                    }
                    catch (Exception emailexc)
                    {

                    }
                    Response.Redirect(ConfigurationManager.AppSettings["CUSTOMERRORSURL"] + "?exceptionid=" + ae.ID.ToString());
                }
            }
        }

        #endregion


        #endregion

        #region Methods
        public void InitializeSession()
        {
            if (SessionManager.Current == null)
            {
                SessionManager.Current = new WebSessionProvider();
            }
            if (SecurityContextManager.Current == null)
            {
                SecurityContextManager.Current = new WebSecurityContext();
            }
        }

        public void InitializeSecurityContextManagerValues()
        {
            if (HttpPageHelper.CurrentProfile != null)
            {
                if (SecurityContextManager.Current != null)
                {
                    SecurityContextManager.Current.CurrentProfile = HttpPageHelper.CurrentProfile;
                }
            }
            //if (HttpPageHelper.CurrentPage != null)
            //{
            //    if (SecurityContextManager.Current != null)
            //    {
            //        SecurityContextManager
            //            .Current
            //            .CurrentPage = HttpPageHelper.CurrentPage;
            //        if (HttpPageHelper.CurrentItem != null)
            //            SessionManager.Current[ResourceStrings.Session_CurrentItem] = HttpPageHelper.CurrentItem;
            //    }
            //}
        }

        protected void ShowErrorModal(Control page, string message)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "key", "ShowErrorModal('" + message.Replace("\"", "").Replace("\r", "").Replace("\n", "").Replace("'", "") + "');", true);
        }

        protected void SetImagesPath(RadEditor re)
        {
            string[] viewImages;
            string[] uploadImages;
            string[] deleteImages;
            viewImages = new string[] { ConfigurationManager.AppSettings["IMAGEURL"] };
            uploadImages = new string[] { ConfigurationManager.AppSettings["IMAGEURL"] };
            deleteImages = new string[] { ConfigurationManager.AppSettings["IMAGEURL"] };
            re.ImageManager.ViewPaths = viewImages;
            re.ImageManager.UploadPaths = uploadImages;
            re.ImageManager.DeletePaths = deleteImages;
        }

        //public string GetUserFullNameByUserID(int userid)
        //{
        //    var u = new UserServices().GetByID(userid);
        //    if (u != null && u.ID > 0)
        //    {
        //        return u.FirstName + " " + u.LastName;
        //    }
        //    return "";
        //}

        
        #endregion

        #region MVP Hookup Code
        protected T RegisterView<T>() where T : Presenter
        {
            return PresentationManager.RegisterView<T>(typeof(T), this, new WebSessionProvider());
        }

        protected void SelfRegister(System.Web.UI.Page page)
        {
            if (page != null && page is IView)
            {
                object[] attributes = page.GetType().GetCustomAttributes(typeof(PresenterTypeAttribute), true);

                if (attributes != null && attributes.Length > 0)
                {
                    foreach (Attribute viewAttribute in attributes)
                    {
                        if (viewAttribute is PresenterTypeAttribute)
                        {
                            PresentationManager.RegisterView((viewAttribute as PresenterTypeAttribute).PresenterType, page as IView, new WebSessionProvider());
                            if (SecurityContextManager.Current == null)
                            {
                                SecurityContextManager.Current = new WebSecurityContext();
                            }
                            break;
                        }
                    }
                }
            }
        }
        #endregion
    }
}
