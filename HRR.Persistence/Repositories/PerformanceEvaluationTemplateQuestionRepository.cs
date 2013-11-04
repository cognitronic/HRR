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
    public class PerformanceEvaluationTemplateQuestionRepository : BaseRepository<PerformanceEvaluationTemplateQuestion, int>
    {
        public IList<PerformanceEvaluationTemplateQuestion> GetByPerformanceEvaluationTemplate(int petID)
        {
            return Session.CreateCriteria<PerformanceEvaluationTemplateQuestion>()
                .Add(Expression.Eq("PerformanceEvaluationTemplateID", petID))
                .List<PerformanceEvaluationTemplateQuestion>();
        }
    }
}
