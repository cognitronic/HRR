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
    public class TeamRepository : BaseRepository<Team, int>
    {
        public IList<Team> GetByAccountID(int accountID)
        {
            return Session.CreateCriteria<Team>()
                .Add(Expression.Eq("AccountID", accountID))
                .List<Team>();
        }

        public Team GetByNameAccountID(string name, int accountID)
        {
            return Session.CreateCriteria<Team>()
                .Add(Expression.Eq("AccountID", accountID))
                .Add(Expression.Eq("Name", name))
                .UniqueResult<Team>();
        }

        public IList<Team> GetByLikeName(string name)
        {
            if (SecurityContextManager.Current != null)
            {
                return Session.CreateCriteria<Person>()
                    .Add(Expression.Like("Name", "%" + name + "%"))
                    .Add(Expression.Eq("AccountID", ((Person)SecurityContextManager.Current.CurrentUser).AccountID))
                    .List<Team>();
            }
            return null;
        }
    }
}
