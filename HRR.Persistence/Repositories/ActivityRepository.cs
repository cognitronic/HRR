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
    public class ActivityRepository : BaseRepository<Activity, int>
    {
        public IList<Activity> GetAllByAccount()
        {
            if (SecurityContextManager.Current != null)
            {
                return Session.CreateCriteria<Activity>()
                    .Add(Expression.Eq("AccountID", SecurityContextManager.Current.CurrentAccount.ID))
                    .Add(Expression.Ge("DateCreated", DateTime.Now.AddDays(-30)))
                    .List<Activity>();
            }
            return null;
        }

        public IList<Activity> GetByDateRangeByAccount(Person person, DateTime startdate, DateTime enddate)
        {
            return Session.CreateCriteria<Activity>()
                    .Add(Expression.Eq("AccountID", person.AccountID))
                    .Add(Expression.Between("DateCreated", startdate, enddate))
                    .List<Activity>();
        }

        public IList<Activity> GetByMaxRows(int maxRows)
        {
            if (SecurityContextManager.Current != null)
            {
                return Session.CreateCriteria<Activity>()
                    .Add(Expression.Eq("AccountID", SecurityContextManager.Current.CurrentAccount.ID))
                    .Add(Expression.Ge("DateCreated", DateTime.Now.AddDays(-30)))
                    .SetMaxResults(maxRows)
                    .AddOrder(Order.Desc("ID"))
                    .List<Activity>();
            }
            return null;
        }
    }
}
