using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using IdeaSeed.Core;
using HRR.Core.Domain;
using HRR.Core.Domain.Interfaces;
using HRR.Core.Security;
using HRR.Services;
using HRR.Core;
using HRR.Web.Bases;

namespace HRR.Website
{
    public partial class ForgotPassword : NoSecurityBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divMessage.Visible = false;
                divPassword.Visible = false;
                divPasswordAnswer.Visible = false;
                divEmail.Visible = true;
            }
        }

        public Person CurrentUser
        {
            get
            {
                if (Session["FPUser"] != null && ((Person)Session["FPUser"]).ID > 0)
                {
                    return ((Person)Session["FPUser"]);
                }
                return null;
            }
            set
            {
                Session["FPUser"] = value;
            }
        }

        protected void VerifyEmailClicked(object o, EventArgs e)
        {
            var u = new PersonServices().GetByEmail(Email);
            if (u != null)
            {
                EmailCorrect = true;
                CurrentUser = u;
            }
            else
            {
                EmailCorrect = false;
                Message = "Email not found, try again.";
            }
            if (EmailCorrect)
            {
                divEmail.Visible = false;
                divPasswordAnswer.Visible = true;
                lblQuestion.Text = this.CurrentUser.PasswordQuestion;
            }
            else
            {
                divMessage.Visible = true;
            }
        }

        protected void VerifyAnswerClicked(object o, EventArgs e)
        {
            if (CurrentUser != null)
            {
                if (CurrentUser.PasswordAnswer.ToLower().Equals(Answer.ToLower()))
                {
                    AnswerCorrect = true;
                }
                else
                {
                    AnswerCorrect = false;
                    Message = "Incorrect answer, try again.";
                }
            }

            if (AnswerCorrect)
            {
                divPasswordAnswer.Visible = false;
                divMessage.Visible = false;
                divPassword.Visible = true;
            }
            else
            {
                divMessage.Visible = true;
            }
        }

        protected void VerifyPasswordsClicked(object o, EventArgs e)
        {
            var u = new PersonServices().GetByEmail(Email);
            if (Password.Equals(ConfirmPassword))
            {
                u.Password = SecurityUtils.GetMd5Hash(ConfirmPassword);
                new PersonServices().Save(u);
                Message = "Password Changed Successfully!";
                var response = new SecurityServices().AuthenticateUser(CurrentUser.Email, CurrentUser.Password, "");
                if (response.IsAuthenticated)
                {
                    if (Request.QueryString["redirect"] != null)
                    {
                        Response.Redirect(Request.QueryString["redirect"]);
                    }
                    Response.Redirect(ResourceStrings.Page_Default);
                }
            }
            else
            {
                Message = "Passwords do not match.";
            }
            if (PasswordMatch)
            {
                divPassword.Visible = false;
            }
            divMessage.Visible = true;
        }

        public string Password
        {
            get
            {
                return tbPassword.Text;
            }
            set
            {
                tbPassword.Text = value;
            }
        }

        public string ConfirmPassword
        {
            get
            {
                return tbConfirmPassword.Text;
            }
            set
            {
                tbConfirmPassword.Text = value;
            }
        }

        public string Message
        {
            get
            {
                return lblMessage.Text;
            }
            set
            {
                lblMessage.Text = value;
            }
        }

        public string Answer
        {
            get
            {
                return tbAnswer.Text;
            }
            set
            {
                tbAnswer.Text = value;
            }
        }

        public string Email
        {
            get
            {
                return tbEmail.Text;
            }
            set
            {
                tbEmail.Text = value;
            }
        }

        public bool PasswordMatch
        {
            get;
            set;
        }

        public bool AnswerCorrect
        {
            get;
            set;
        }

        public bool EmailCorrect
        {
            get;
            set;
        }
    }
}