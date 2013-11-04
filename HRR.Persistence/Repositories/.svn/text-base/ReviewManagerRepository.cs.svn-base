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
    public class ReviewManagerRepository : BaseRepository<ReviewManager, int>
    {
        public IList<ReviewManager> GetByReviewID(int reviewID)
        {
            return Session.CreateCriteria<ReviewManager>()
                .Add(Expression.Eq("ReviewID", reviewID))
                .List<ReviewManager>();
        }
    }
}
