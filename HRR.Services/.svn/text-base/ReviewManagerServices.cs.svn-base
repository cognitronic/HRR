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
    public class ReviewManagerServices
    {
        public ReviewManager GetByID(int id)
        {
            return new ReviewManagerRepository().GetByID(id, false);
        }

        public IList<ReviewManager> GetAll()
        {
            return new ReviewManagerRepository()
                .GetAll()
                .OrderByDescending(o => o.PersonRef.LastName)
                .ToList<ReviewManager>(); ;
        }

        public ReviewManager Save(ReviewManager item)
        {
            return new ReviewManagerRepository().SaveOrUpdate(item);
        }

        public void Delete(ReviewManager item)
        {
            new ReviewManagerRepository().Delete(item);
        }

        public IList<ReviewManager> GetByReviewID(int goalid)
        {
            return new ReviewManagerRepository()
                .GetByReviewID(goalid)
                .OrderByDescending(o => o.PersonRef.LastName)
                .ToList<ReviewManager>(); ;
        }
    }
}
