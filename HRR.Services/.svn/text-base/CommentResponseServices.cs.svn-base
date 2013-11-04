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
    public class CommentResponseServices
    {
        public CommentResponse GetByID(int id)
        {
            return new CommentResponseRepository().GetByID(id, false);
        }

        public IList<CommentResponse> GetAll()
        {
            return new CommentResponseRepository()
                .GetAll()
                .OrderByDescending(o => o.DateCreated)
                .ToList<CommentResponse>(); ;
        }

        public CommentResponse Save(CommentResponse item)
        {
            return new CommentResponseRepository().SaveOrUpdate(item);
        }

        public void Delete(CommentResponse item)
        {
            new CommentResponseRepository().Delete(item);
        }

        public IList<CommentResponse> GetByCommentID(int commentid)
        {
            return new CommentResponseRepository()
                .GetByCommentID(commentid)
                .OrderByDescending(o => o.DateCreated)
                .ToList<CommentResponse>(); ;
        }
    }
}
