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
    public class PollResultRepository : BaseRepository<PollResult, int>
    {
        public IList<PollResult> GetByPollID(int pollid)
        {
            return Session.CreateCriteria<PollResult>()
                    .Add(Expression.Eq("PollID", pollid))
                    .List<PollResult>();
        }

        public PollResult GetByPollIDPersonID(int pollid, int personid)
        {
            return Session.CreateCriteria<PollResult>()
                        .Add(Expression.Eq("PollID", pollid))
                        .Add(Expression.Eq("EnteredBy", personid))
                        .UniqueResult<PollResult>();
        }
    }
}
