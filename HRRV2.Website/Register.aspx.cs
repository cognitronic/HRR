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
using System.Web.Script.Serialization;
using Telerik.Web.UI;

namespace HRRV2.Website
{
    public partial class Register : NoSecurityBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SaveClicked(object o, EventArgs e)
        {
            var account = new Account();
            account.ChangedBy = -1;
            account.CommentsWeight = 40;
            account.Company = tbCompany.Text;
            account.DateCreated = DateTime.Now;
            account.Domain = tbSiteAddress.Text.ToLower()
                .Replace(" ", "")
                .Replace("_", "")
                .Replace("'", "")
                .Replace("@", "")
                .Replace("-", "")
                .Replace("?", "")
                .Replace("&", "")
                .Replace("%", "")
                .Replace("^", "") + ".hrriver.com";
            account.EnteredBy = -1;
            account.GoalsWeight = 30;
            account.LastUpdated = DateTime.Now;
            account.QuestionsWeight = 30;
            new AccountServices().Save(account);

            var dept = new Department();
            dept.AccountID = account.ID;
            dept.Description = "Human Resources";
            dept.Name = "HR";
            new DepartmentServices().Save(dept);



            var admin = new Person();
            admin.AccountID = account.ID;
            admin.AvatarPath = "http://www.gravatar.com/avatar/" + DateTime.Now.Ticks.ToString() + "?d=identicon&s=";
            admin.ChangedBy = admin.ID;
            admin.EnteredBy = admin.ID;
            admin.IsActive = true;
            admin.DateCreated = DateTime.Now;
            admin.IsManager = true;
            admin.FirstName = tbFirstName.Text;
            admin.LastName = tbLastName.Text;
            admin.Email = tbEmail.Text;
            admin.DepartmentID = dept.ID;
            admin.LastUpdated = DateTime.Now;
            admin.MarkedForDeletion = false;
            admin.Password = SecurityUtils.GetMd5Hash(tbPassword.Text);
            admin.PasswordQuestion = "What is your work email address?";
            admin.PasswordAnswer = tbEmail.Text;
            admin.ReceiveCommentNotifications = true;
            admin.RoleID = (int)SecurityRole.ADMIN;
            admin.Title = "Admin";
            admin.ManagerID = admin.ID;
            admin.UserName = admin.Email;
            new PersonServices().Save(admin);

            var commentcat = new CommentCategory();
            commentcat.AccountID = account.ID;
            commentcat.Name = "Discipline";
            new CommentCategoryServices().Save(commentcat); 
            commentcat = new CommentCategory();
            commentcat.AccountID = account.ID;
            commentcat.Name = "Teamwork";
            new CommentCategoryServices().Save(commentcat); 
            

            var ratingscale = new QuestionRatingScale();
            ratingscale.AccountID = account.ID;
            ratingscale.Name = "Three Point Scale";
            ratingscale.Title = "Three Point Scale";
            new QuestionRatingScaleServices().Save(ratingscale);

            var scalevals = new QuestionRatingScaleValue();
            scalevals.Name = "Below Expectations";
            scalevals.QuestionRatingScaleID = ratingscale.ID;
            scalevals.Title = "Below Expectations";
            scalevals.Value = 0;
            new QuestionRatingScaleValueServices().Save(scalevals);
            scalevals = new QuestionRatingScaleValue();
            scalevals.Name = "Meets Expectations";
            scalevals.QuestionRatingScaleID = ratingscale.ID;
            scalevals.Title = "Meets Expectations";
            scalevals.Value = 50;
            new QuestionRatingScaleValueServices().Save(scalevals);
            scalevals = new QuestionRatingScaleValue();
            scalevals.Name = "Exceeds Expectations";
            scalevals.QuestionRatingScaleID = ratingscale.ID;
            scalevals.Title = "Exceeds Expectations";
            scalevals.Value = 100;
            new QuestionRatingScaleValueServices().Save(scalevals);

            var reviewtemplate = new ReviewTemplate();
            reviewtemplate.AccountID = account.ID;
            reviewtemplate.IsActive = true;
            reviewtemplate.Name = "Basic Review";
            reviewtemplate.Title = "Basic Review";
            new ReviewTemplateServices().Save(reviewtemplate);

            var reviewtemplatequestion = new ReviewTemplateQuestion();
            reviewtemplatequestion.CategoryID = commentcat.ID;
            reviewtemplatequestion.Name = "Works well with others";
            reviewtemplatequestion.Question = "Works well with others";
            reviewtemplatequestion.QuestionRatingScaleID = ratingscale.ID;
            reviewtemplatequestion.ReviewTemplateID = reviewtemplate.ID;
            new ReviewTemplateQuestionServices().Save(reviewtemplatequestion);

            var review = new Review();
            review.AccountID = account.ID;
            review.ChangedBy = admin.ID;
            review.CommentsWeight = 40;
            review.IsActive = true;
            review.IsCurrent = true;
            review.LastUpdated = DateTime.Now;
            review.Name = "Review for " + admin.Name;
            review.QuestionsWeight = 30;
            review.ReviewTemplateID = reviewtemplate.ID;
            review.Score = 0;
            review.StartDate = DateTime.Now;
            review.EnteredBy = admin.ID;
            review.EnteredFor = admin.ID;
            review.DueDate = DateTime.Now.AddMonths(3);
            review.Status = (int)GoalStatus.ACCEPTED;
            review.Title = "Review for " + admin.Name;
            review.DateCreated = DateTime.Now;
            new ReviewServices().Save(review);

            var team = new Team();
            team.AccountID = account.ID;
            team.Description = "Company Wide";
            team.Name = "Company Wide";
            new TeamServices().Save(team);

            var member = new TeamMember();
            member.HasAccess = true;
            member.IsActive = true;
            member.IsManager = true;
            member.PersonID = admin.ID;
            member.RecievesNotifications = true;
            member.TeamID = team.ID;
            new TeamMemberServices().Save(member);


            var response = new SecurityServices().AuthenticateUser(admin.Email, tbPassword.Text, "");
            if (response.IsAuthenticated)
            {
                if (Request.QueryString["redirect"] != null)
                {
                    Response.Redirect(Request.QueryString["redirect"]);
                }
                Response.Redirect(ResourceStrings.Page_Default);
            }
        }
    }
}