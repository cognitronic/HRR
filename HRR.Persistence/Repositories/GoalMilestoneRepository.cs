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
    public class GoalMilestoneRepository : BaseRepository<GoalMilestone, int>
    {
        public IList<GoalMilestone> GetByGoalID(int goalID)
        {
            return Session.CreateCriteria<GoalMilestone>()
                .Add(Expression.Eq("GoalID", goalID))
                .List<GoalMilestone>();
        }

        public IList<GoalMilestone> GetByDueDate(DateTime duedate)
        {
            if (SecurityContextManager.Current != null)
            {
                switch (((Person)SecurityContextManager.Current.CurrentUser).RoleID)
                {
                    case (int)SecurityRole.EMPLOYEE:
                    case (int)SecurityRole.READ_ONLY:
                        return Session.CreateCriteria<GoalMilestone>()
                        .Add(Expression.Eq("EnteredFor", SecurityContextManager.Current.CurrentUser.ID))
                        .Add(Expression.Eq("AccountID", ((Person)SecurityContextManager.Current.CurrentUser).AccountID))
                        .Add(Expression.Between("DueDate", DateTime.Now, duedate))
                        .Add(Expression.Or(
                         Expression.Eq("Status", (int)GoalStatus.ACCEPTED),
                         Expression.Eq("Status", (int)GoalStatus.AWAITING_ACCEPTANCE)))
                        .List<GoalMilestone>();
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
                        return Session.CreateCriteria<GoalMilestone>()
                        .Add(Expression.Between("DueDate", DateTime.Now, duedate))
                        .Add(Expression.Eq("AccountID", ((Person)SecurityContextManager.Current.CurrentUser).AccountID))
                        .Add(Expression.Or(
                            Expression.Eq("Status", (int)GoalStatus.ACCEPTED),
                            Expression.Eq("Status", (int)GoalStatus.AWAITING_ACCEPTANCE)))
                        .List<GoalMilestone>();

                }
            }
            return null;
            //return Session.CreateCriteria<GoalMilestone>()
            //            .Add(Expression.Between("DueDate", DateTime.Now, duedate))
            //            .Add(Expression.Or(
            //                Expression.Eq("Status", (int)GoalStatus.ACCEPTED),
            //                Expression.Eq("Status", (int)GoalStatus.AWAITING_ACCEPTANCE)))
            //            .List<GoalMilestone>();
        }
    }
}
