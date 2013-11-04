using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRR.Core.Domain;
using HRR.Persistence.Repositories;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace HRR.Services
{
    public class CommentLikeServices
    {
        public CommentLike GetByID(int id)
        {
            return new CommentLikeRepository().GetByID(id, false);
        }

        public IList<CommentLike> GetAll()
        {
            return new CommentLikeRepository()
                .GetAll()
                .OrderByDescending(o => o.DateCreated)
                .ToList<CommentLike>(); ;
        }

        public CommentLike Save(CommentLike item)
        {
            return new CommentLikeRepository().SaveOrUpdate(item);
        }

        public void Delete(CommentLike item)
        {
            new CommentLikeRepository().Delete(item);
        }

        public IList<CommentLike> GetByCommentID(int commentid)
        {
            return new CommentLikeRepository()
                .GetByCommentID(commentid)
                .OrderByDescending(o => o.DateCreated)
                .ToList<CommentLike>(); ;
        }

        public CommentLike GetByCommentIDPersonID(int commentid, int personid)
        {
            return new CommentLikeRepository()
                .GetByCommentIDPersonID(commentid, personid);
        }
    }
}
