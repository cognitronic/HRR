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
    public class PollRepository : BaseRepository<Poll, int>
    {
        public IList<Poll> GetAllByAccount()
        {
            if (SecurityContextManager.Current != null)
            {
                return Session.CreateCriteria<Poll>()
                    .Add(Expression.Eq("AccountID", SecurityContextManager.Current.CurrentAccount.ID))
                    .List<Poll>();
            }
            return null;
        }

        public IList<Poll> GetAllActiveByAccount()
        {
            if (SecurityContextManager.Current != null)
            {
                return Session.CreateCriteria<Poll>()
                    .Add(Expression.Eq("AccountID", SecurityContextManager.Current.CurrentAccount.ID))
                    .Add(Expression.Eq("IsActive", true))
                    .List<Poll>();
            }
            return null;
        }
    }
}
