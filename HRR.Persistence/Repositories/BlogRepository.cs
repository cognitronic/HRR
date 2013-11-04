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
    public class BlogRepository : BaseRepository<Blog, int>
    {
        public IList<Blog> GetAllByAccount()
        {
            if (SecurityContextManager.Current != null)
            {
                return Session.CreateCriteria<Blog>()
                    .Add(Expression.Eq("AccountID", SecurityContextManager.Current.CurrentAccount.ID))
                    .List<Blog>();
            }
            return null;
        }

        public Blog GetLastestPost()
        {
            if (SecurityContextManager.Current != null)
            {
                return Session.CreateCriteria<Blog>()
                    .Add(Expression.Eq("AccountID", SecurityContextManager.Current.CurrentAccount.ID))
                    .List<Blog>().OrderByDescending(o => o.StartDate).First();
            }
            return null;
        }

        public Blog GetLastestPost(int accountid)
        {
            return Session.CreateCriteria<Blog>()
                    .Add(Expression.Eq("AccountID", accountid))
                    .List<Blog>().OrderByDescending(o => o.StartDate).First();
        }

        public IList<Blog> GetForFeed()
        {
            if (SecurityContextManager.Current != null)
            {
                return Session.CreateCriteria<Blog>()
                    .Add(Expression.Eq("AccountID", SecurityContextManager.Current.CurrentAccount.ID))
                    .Add(Expression.Eq("IsActive", true))
                    .Add(Expression.Le("StartDate", DateTime.Now))
                    .Add(Expression.Ge("EndDate", DateTime.Now))
                    .List<Blog>();
            }
            return null;
        }

        public IList<Blog> GetByCategory(int categoryid)
        {
            if (SecurityContextManager.Current != null)
            {
                return Session.CreateCriteria<Blog>()
                    .Add(Expression.Eq("AccountID", SecurityContextManager.Current.CurrentAccount.ID))
                    .Add(Expression.Eq("IsActive", true))
                    .Add(Expression.Eq("BlogCategoryID", categoryid))
                    .List<Blog>();
            }
            return null;
        }
    }

}
