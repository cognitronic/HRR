using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HRR.Core.Domain;
using HRR.Core;
using HRR.Core.Security;
using HRR.Services;
using HRR.Web;

namespace HRRV2.Website.Controllers
{
    public class StaffController : ApiController
    {
        private readonly PersonServices _personServices = new PersonServices();

        [HttpPost]
        [ActionName("SavePerson")]
        public string SavePerson([FromBody]NewPerson newperson)
        {
            string result = "";
            var person = newperson.Person;
            var reviewsetup = newperson.ReviewSetup;

            person.AccountID = SecurityContextManager.Current.CurrentAccount.ID;
            person.TerminationDate = null;
            person.DateAcceptedTerms = null;
            person.Password = IdeaSeed.Core.SecurityUtils.GetMd5Hash(person.Password);
            var p = new PersonServices().Save(person);
            if (person.ManagerID == -1)
            {
                person.ManagerID = p.ID;
                new PersonServices().Save(p);
            }

            foreach (var m in person.Memberships)
            {
                m.PersonID = person.ID;
                new TeamMemberServices().Save(m);
            }
            var review = new Review();
            review.AccountID = SecurityContextManager.Current.CurrentAccount.ID;
            review.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
            review.DateCreated = DateTime.Now;
            review.DueDate = reviewsetup.DueDate;
            review.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
            review.EnteredFor = person.ID;
            review.IsActive = true;
            review.IsCurrent = true;
            review.LastUpdated = DateTime.Now;
            review.ReviewTemplateID = reviewsetup.TemplateID;
            review.StartDate = reviewsetup.StartDate;
            review.Status = (int)GoalStatus.ACCEPTED;
            review.Title = person.Name + " - Due: " + review.DueDate.ToShortDateString();
            new ReviewServices().Save(review);

            var t = new ReviewTemplateServices().GetByID(review.ReviewTemplateID);
            foreach (var i in t.Questions)
            {
                var q = new ReviewQuestionScore();
                q.Comment = "";
                q.DateCreated = DateTime.Now;
                q.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
                q.Score = 0;
                q.ReviewID = review.ID;
                q.ReviewQuestionID = i.ID;
                new ReviewQuestionScoreServices().Save(q);
            }

            if (person.ReceiveCommentNotifications)
                EmailHelper.SendNewEmployeeNotification(person, "");
            IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();
            result = "1:Employee Added Succesfully!:People/" + person.Email;

            var _cache = new MemcacheCacheAdapter();
            _cache.Remove(SecurityContextManager
                 .Current
                 .CurrentUser.AccountID.ToString() + "_DepartmentsList");
            var list = new PersonServices().GetByAccountID(SecurityContextManager.Current.CurrentAccount.ID).OrderBy(o => o.LastName).ToList<Person>();
            _cache.Store(SecurityContextManager
                 .Current
                 .CurrentUser.AccountID.ToString() + "_DepartmentsList", list);

            return result;

        }

        [HttpPost]
        [ActionName("SaveGoal")]
        public string SaveGoal(Goal goalJson)
        {
            string result = "";

            var review = new ReviewServices().GetEmployeeActiveReview(goalJson.EnteredFor);
            if (review != null)
            {
                goalJson.ReviewID = review.ID;
            }
            new GoalServices().Save(goalJson);
            foreach (var m in goalJson.Milestones)
            {
                m.GoalID = goalJson.ID;
                new GoalMilestoneServices().Save(m);
            }
            foreach (var s in goalJson.Managers)
            {
                s.GoalID = goalJson.ID;
                new GoalManagerServices().Save(s);
            }
            var a = new Activity();
            a.AccountID = goalJson.AccountID;
            a.URL = "/Goals/" + goalJson.ID.ToString();
            a.ActivityType = (int)ActivityType.NEW_GOAL;
            a.DateCreated = DateTime.Now;
            a.PerformedBy = SecurityContextManager.Current.CurrentUser.ID;
            a.PerformedFor = goalJson.EnteredFor;
            new ActivityServices().Save(a);
            string emails = "";
            if (goalJson.Managers.Count > 0)
            {
                foreach (var m in goalJson.Managers)
                {
                    var p = new PersonServices().GetByID(m.PersonID);
                    emails += p.Email + ",";
                }
            }
            EmailHelper.SendNewGoalNotification(goalJson, emails);

            result = "1:Goal Added Succesfully!:Goals/" + goalJson.ID.ToString();
            return result;

        }

        [HttpPost]
        [ActionName("GetGoalsForWeightingByPersonID")]
        public string GetGoalsForWeightingByPersonID(UserID userID)
        {
            var list = new ReviewServices().GetEmployeeActiveReview(Convert.ToInt16(userID.ID)).Goals;
            string s = "[";
            foreach (var item in list)
            {
                s += "{\"title\":\"" + item.Title + "\",\"id\":\"" + item.ID.ToString() + "\",\"weight\":\"" + item.Weight + "\"},";
            }
            return s.Remove(s.Length - 1, 1) + "]";
        }

        [AcceptVerbs("GET", "POST")]
        [ActionName("UpdateGoalWeight")]
        public void UpdateGoalWeight(IList<GoalWeight> weights)
        {
            if (weights != null)
            {
                foreach (var w in weights)
                {
                    var goal = new GoalServices().GetByID(w.ID);
                    goal.Weight = w.Weight;
                    new GoalServices().Save(goal);
                }
            }
        }

        [AcceptVerbs("GET", "POST")]
        [ActionName("CloseReview")]
        public string CloseReview(int oldreview, ReviewSetup reviewsetup)
        {
            string result = "";

            if (oldreview > 0)
            {
                var review = new ReviewServices().GetByID(oldreview);
                review.IsCurrent = false;
                review.IsActive = false;
                review.Status = (int)GoalStatus.COMPLETED;
                review.Score = ReviewServices.CalculateCommentsScore(review)["Weighted"] + ReviewServices.CalculateGoalsScore(review)["Weighted"] + ReviewServices.CalculateQuestionsScore(review)["Weighted"];
                new ReviewServices().Save(review);

                var newreview = new Review();
                newreview.AccountID = SecurityContextManager.Current.CurrentAccount.ID;
                newreview.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
                newreview.DateCreated = DateTime.Now;
                newreview.DueDate = reviewsetup.DueDate;
                newreview.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
                newreview.EnteredFor = review.EnteredForRef.ID;
                newreview.IsActive = true;
                newreview.IsCurrent = true;
                newreview.LastUpdated = DateTime.Now;
                newreview.ReviewTemplateID = reviewsetup.TemplateID;
                newreview.StartDate = reviewsetup.StartDate;
                newreview.Status = (int)GoalStatus.ACCEPTED;
                newreview.Title = review.EnteredForRef.Name + " - Due: " + review.DueDate.ToShortDateString();
                newreview.CommentsWeight = SecurityContextManager.Current.CurrentAccount.CommentsWeight;
                newreview.GoalsWeight = SecurityContextManager.Current.CurrentAccount.GoalsWeight;
                newreview.QuestionsWeight = SecurityContextManager.Current.CurrentAccount.QuestionsWeight;
                new ReviewServices().Save(newreview);
                var t = new ReviewTemplateServices().GetByID(newreview.ReviewTemplateID);
                foreach (var i in t.Questions)
                {
                    var q = new ReviewQuestionScore();
                    q.Comment = "";
                    q.DateCreated = DateTime.Now;
                    q.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
                    q.Score = 0;
                    q.ReviewID = newreview.ID;
                    q.ReviewQuestionID = i.ID;
                    new ReviewQuestionScoreServices().Save(q);
                }
                EmailHelper.SendReviewNotification(newreview, review.EnteredForRef.Email);
                if (review.EnteredForRef.ReceiveCommentNotifications)
                    result = "1:New Review Successfully Created!:Reviews/" + newreview.ID.ToString();
                return result;
            }
            return result;
        }

        

    }

    public class GoalWeight
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Weight { get; set; }
    }

    public class ReviewSetup
    {
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public int TemplateID { get; set; }
    }

    public class NewPerson
    {
        public Person Person { get; set; }
        public ReviewSetup ReviewSetup { get; set; }
    }

    public class UserID
    {
        public int ID { get; set; }
    }
}