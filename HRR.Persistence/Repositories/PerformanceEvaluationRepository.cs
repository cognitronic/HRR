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
    public class PerformanceEvaluationRepository : BaseRepository<PerformanceEvaluation, int>
    {
        public IList<PerformanceEvaluation> GetEvaluations()
        {
            return Session.CreateCriteria<PerformanceEvaluation>()
                .Add(Expression.Le("AccountID", ((Person)SecurityContextManager.Current.CurrentUser).AccountID))
                .List<PerformanceEvaluation>();
        }

        public IList<PerformanceEvaluation> GetEvaluationsByIsGoal(bool isGoal)
        {
            return Session.CreateCriteria<PerformanceEvaluation>()
                .Add(Expression.Le("AccountID", ((Person)SecurityContextManager.Current.CurrentUser).AccountID))
                .Add(Expression.Le("IsGoal", isGoal))
                .List<PerformanceEvaluation>();
        }

        public IList<PerformanceEvaluation> GetEvaluationsByEvaluatee(int personID)
        {
            return Session.CreateCriteria<PerformanceEvaluation>()
                .Add(Expression.Le("Evaluatee", personID))
                .List<PerformanceEvaluation>();
        }
    }
}
