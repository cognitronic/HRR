using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using IdeaSeed.Core.Data.NHibernate;
using IdeaSeed.Core.Data;
using HRR.Core.Security;
using HRR.Core.Domain;


namespace HRR.Persistence.Repositories
{
    public class DepartmentRepository : BaseRepository<Department, int>
    {
        public IList<Department> GetAllByAccount()
        {
            if (SecurityContextManager.Current != null)
            {
                return Session.CreateCriteria<Department>()
                    .Add(Expression.Eq("AccountID", SecurityContextManager.Current.CurrentAccount.ID))
                    .List<Department>();
            }
            return null;
        }
    }
}
