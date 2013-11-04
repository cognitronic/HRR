using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using IdeaSeed.Core.Data.NHibernate;
using IdeaSeed.Core.Data;
using HRR.Core.Domain;
using HRR.Core.Security;
using HRR.Core.Domain.Interfaces;

namespace HRR.Persistence.Repositories
{
    public class ReviewRepository : BaseRepository<Review, int>
    {
        public IList<Review> GetByEnteredBy(int enteredby)
        {
            return Session.CreateCriteria<Review>()
                .Add(Expression.Eq("EnteredBy", enteredby))
                .List<Review>();
        }

        public IList<Review> GetByAllActive()
        {
            return Session.CreateCriteria<Review>()
                .Add(Expression.Eq("IsActive", true))
                .List<Review>();
        }

        public IList<Review> GetByDueDate(DateTime duedate)
        {
            if (SecurityContextManager.Current != null)
            {
                switch (((Person)SecurityContextManager.Current.CurrentUser).RoleID)
                {
                    case (int)SecurityRole.EMPLOYEE:
                    case (int)SecurityRole.READ_ONLY:
                        return Session.CreateCriteria<Review>()
                        .Add(Expression.Eq("EnteredFor", SecurityContextManager.Current.CurrentUser.ID))
                        .Add(Expression.Eq("AccountID", ((Person)SecurityContextManager.Current.CurrentUser).AccountID))
                        .Add(Expression.Between("DueDate", DateTime.Now, duedate))
                        .Add(Expression.Or(
                         Expression.Eq("Status", (int)GoalStatus.ACCEPTED),
                         Expression.Eq("Status", (int)GoalStatus.AWAITING_ACCEPTANCE)))
                        .List<Review>();
                        break;
                    //case (int)SecurityRole.MANAGER:
                    //    return Session.CreateCriteria<GoalMilestone>()
                    //    .Add(Expression.Or(
                    //     Expression.Eq("EnteredFor", SecurityContextManager.Current.CurrentUser.ID),
                    //     Expression.Eq("ManagerID", SecurityContextManager.Current.CurrentUser.ID)))
                    //    .Add(Expression.Between("DueDate", DateTime.Now, duedate))
                    //    .Add(Expression.Or(
                    //     Expression.Eq("StatusID", (int)GoalStatus.ACCEPTED),
                    //     Expression.Eq("StatusID", (int)GoalStatus.AWAITING_ACCEPTANCE)))
                    //    .List<GoalMilestone>();
                    //    break;
                    default:
                        return Session.CreateCriteria<Review>()
                        .Add(Expression.Between("DueDate", DateTime.Now, duedate))
                        .Add(Expression.Eq("AccountID", ((Person)SecurityContextManager.Current.CurrentUser).AccountID))
                        .Add(Expression.Or(
                            Expression.Eq("Status", (int)GoalStatus.ACCEPTED),
                            Expression.Eq("Status", (int)GoalStatus.AWAITING_ACCEPTANCE)))
                        .List<Review>();

                }
            }
            return null;
        }

        public IList<Review> GetByEnteredFor(int enteredfor)
        {
            return Session.CreateCriteria<Review>()
                .Add(Expression.Eq("EnteredFor", enteredfor))
                .List<Review>();
        }

        public Review GetEmployeeActiveReview(int enteredfor)
        {
            return Session.CreateCriteria<Review>()
                .Add(Expression.Eq("EnteredFor", enteredfor))
                .Add(Expression.Eq("IsActive", true))
                .List<Review>().FirstOrDefault();
        }
    }
}
