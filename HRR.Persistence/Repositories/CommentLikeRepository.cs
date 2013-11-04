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
    public class CommentLikeRepository : BaseRepository<CommentLike, int>
    {
        public IList<CommentLike> GetByCommentID(int commentID)
        {
            return Session.CreateCriteria<CommentLike>()
                .Add(Expression.Eq("CommentID", commentID))
                .List<CommentLike>();
        }

        public CommentLike GetByCommentIDPersonID(int commentID, int personID)
        {
            return Session.CreateCriteria<CommentLike>()
                .Add(Expression.Eq("CommentID", commentID))
                .Add(Expression.Eq("PersonID", personID))
                .UniqueResult<CommentLike>();
        }
    }
}
