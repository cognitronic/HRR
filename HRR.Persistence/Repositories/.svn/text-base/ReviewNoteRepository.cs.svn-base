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
    public class ReviewNoteRepository : BaseRepository<ReviewNote, int>
    {
        public IList<ReviewNote> GetAllByReview(int reviewid)
        {
            return Session.CreateCriteria<ReviewNote>()
                    .Add(Expression.Eq("ReviewID", reviewid))
                    .List<ReviewNote>();
        }
    }
}
