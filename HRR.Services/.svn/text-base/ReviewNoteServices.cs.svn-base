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
    public class ReviewNoteServices
    {
        public ReviewNote GetByID(int id)
        {
            return new ReviewNoteRepository().GetByID(id, false);
        }

        public IList<ReviewNote> GetAll()
        {
            return new ReviewNoteRepository()
                .GetAll()
                .OrderByDescending(o => o.DateCreated)
                .ToList<ReviewNote>(); ;
        }

        public IList<ReviewNote> GetAllByReview(int reviewid)
        {
            return new ReviewNoteRepository()
                .GetAllByReview(reviewid)
                .ToList<ReviewNote>();
        }

        public ReviewNote Save(ReviewNote item)
        {
            return new ReviewNoteRepository().SaveOrUpdate(item);
        }

        public void Delete(ReviewNote item)
        {
            new ReviewNoteRepository().Delete(item);
        }
    }
}
