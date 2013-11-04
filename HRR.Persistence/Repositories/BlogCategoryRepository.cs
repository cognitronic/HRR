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
    public class BlogCategoryRepository : BaseRepository<BlogCategory, int>
    {
        public IList<BlogCategory> GetAllByAccount()
        {
            if (SecurityContextManager.Current != null)
            {
                return Session.CreateCriteria<BlogCategory>()
                    .Add(Expression.Eq("AccountID", SecurityContextManager.Current.CurrentAccount.ID))
                    .List<BlogCategory>();
            }
            return null;
        }
    }
}
