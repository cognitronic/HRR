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
    public class DocumentRepository : BaseRepository<Document, int>
    {
        public IList<Document> GetByPersonID(int personID)
        {
            return Session.CreateCriteria<Document>()
                .Add(Expression.Eq("PersonID", personID))
                .List<Document>();
        }

        public IList<Document> GetByPublicPersonID(int personID)
        {
            return Session.CreateCriteria<Document>()
                .Add(Expression.Eq("PersonID", personID))
                .Add(Expression.Eq("IsPrivate", false))
                .List<Document>();
        }
    }
}
