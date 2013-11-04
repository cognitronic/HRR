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
    public class PerformanceEvaluationQuestionScoreRepository : BaseRepository<PerformanceEvaluationQuestionScore, int>
    {
        public IList<PerformanceEvaluationQuestionScore> GetByPerformanceEvaluationResponse(int responseID)
        {
            return Session.CreateCriteria<PerformanceEvaluationQuestionScore>()
                .Add(Expression.Le("PerformanceEvaluationResponseID", responseID))
                .List<PerformanceEvaluationQuestionScore>();
        }
    }
}
