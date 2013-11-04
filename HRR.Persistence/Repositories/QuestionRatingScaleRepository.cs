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
    public class QuestionRatingScaleRepository : BaseRepository<QuestionRatingScale, int>
    {
        public IList<QuestionRatingScale> GetAllByAccount()
        {
            if (SecurityContextManager.Current != null)
            {
                return Session.CreateCriteria<QuestionRatingScale>()
                    .Add(Expression.Eq("AccountID", ((Person)SecurityContextManager.Current.CurrentUser).AccountID))
                    .List<QuestionRatingScale>();
            }
            return null;
        }
    }
}
