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
    public class PerformanceEvaluationResponseRepository : BaseRepository<PerformanceEvaluationResponse, int>
    {
        public IList<PerformanceEvaluationResponse> GetByPerformanceEvaluation(int peID)
        {
            return Session.CreateCriteria<PerformanceEvaluationResponse>()
                .Add(Expression.Le("PerformanceEvaluationID", peID))
                .List<PerformanceEvaluationResponse>();
        }

        public IList<PerformanceEvaluationResponse> GetByEvaluatee(int personID)
        {
            return Session.CreateCriteria<PerformanceEvaluationResponse>()
                .Add(Expression.Le("Evaluatee", personID))
                .List<PerformanceEvaluationResponse>()
                .OrderByDescending(o => o.DateCompleted)
                .ToList<PerformanceEvaluationResponse>();
        }
    }
}
