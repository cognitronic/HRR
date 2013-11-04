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
    public class BlogResponseRepository : BaseRepository<BlogResponse, int>
    {
        public IList<BlogResponse> GetAllByBlog(int blogid)
        {
            if (SecurityContextManager.Current != null)
            {
                return Session.CreateCriteria<BlogResponse>()
                    .Add(Expression.Eq("BlogID", blogid))
                    .List<BlogResponse>();
            }
            return null;
        }
    }
}
