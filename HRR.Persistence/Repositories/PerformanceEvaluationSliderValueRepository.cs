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
    public class PerformanceEvaluationSliderValueRepository : BaseRepository<PerformanceEvaluationSliderValue, int>
    {
        public IList<PerformanceEvaluationSliderValue> GetByPerformanceEvaluationTemplate(int questionID)
        {
            return Session.CreateCriteria<PerformanceEvaluationSliderValue>()
                .Add(Expression.Le("PerformanceEvaluationTemplateQuestionID", questionID))
                .List<PerformanceEvaluationSliderValue>();
        }
    }
}
