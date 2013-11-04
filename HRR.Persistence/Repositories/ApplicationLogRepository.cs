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
    public class ApplicationLogRepository : BaseRepository<HRR.Core.Domain.ApplicationLog, int>
    {
        public IList<HRR.Core.Domain.ApplicationLog> GetAllByAccount()
        {
            if (SecurityContextManager.Current != null)
            {
                return Session.CreateCriteria<HRR.Core.Domain.ApplicationLog>()
                    .Add(Expression.Eq("AccountID", SecurityContextManager.Current.CurrentAccount.ID))
                    .List<HRR.Core.Domain.ApplicationLog>();
            }
            return null;
        }

        public IList<HRR.Core.Domain.ApplicationLog> GetAllByDate(DateTime date)
        {
            if (SecurityContextManager.Current != null)
            {
                return Session.CreateCriteria<HRR.Core.Domain.ApplicationLog>()
                    .Add(Expression.Eq("AccountID", SecurityContextManager.Current.CurrentAccount.ID))
                    .Add(Expression.Eq("ExceptionDate", date))
                    .List<HRR.Core.Domain.ApplicationLog>();
            }
            return null;
        }
    }
}
