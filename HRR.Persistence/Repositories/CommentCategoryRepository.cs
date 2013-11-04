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
    public class CommentCategoryRepository : BaseRepository<CommentCategory, int>
    {
        public IList<CommentCategory> GetAllByAccount()
        {
            if (SecurityContextManager.Current != null)
            {
                return Session.CreateCriteria<CommentCategory>()
                    .Add(Expression.Eq("AccountID", ((Person)SecurityContextManager.Current.CurrentUser).AccountID))
                    .List<CommentCategory>();
            }
            return null;
        }
    }
}
