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
    public class ReviewQuestionScoreServices
    {
        public ReviewQuestionScore GetByID(int id)
        {
            return new ReviewQuestionScoreRepository().GetByID(id, false);
        }

        public IList<ReviewQuestionScore> GetAll()
        {
            return new ReviewQuestionScoreRepository()
                .GetAll()
                .OrderByDescending(o => o.DateCreated)
                .ToList<ReviewQuestionScore>(); ;
        }

        public ReviewQuestionScore Save(ReviewQuestionScore item)
        {
            return new ReviewQuestionScoreRepository().SaveOrUpdate(item);
        }

        public void Delete(ReviewQuestionScore item)
        {
            new ReviewQuestionScoreRepository().Delete(item);
        }

        public IList<ReviewQuestionScore> GetByReviewID(int reviewid)
        {
            return new ReviewQuestionScoreRepository().GetByReviewID(reviewid);
        }
    }
}
