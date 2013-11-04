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
    public class AbsenceRepository : BaseRepository<Absence, int>
    {
        public IList<Absence> GetAllByAccount()
        {
            if (SecurityContextManager.Current != null)
            {
                return Session.CreateCriteria<Absence>()
                    .Add(Expression.Eq("AccountID", SecurityContextManager.Current.CurrentAccount.ID))
                    .List<Absence>();
            }
            return null;
        }

        public IList<Absence> GetByEnteredFor(int enteredfor)
        {
            return Session.CreateCriteria<Absence>()
                .Add(Expression.Eq("EnteredFor", enteredfor))
                .List<Absence>();
        }
    }
}
