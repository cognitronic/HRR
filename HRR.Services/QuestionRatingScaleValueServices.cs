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
    public class QuestionRatingScaleValueServices
    {
        public QuestionRatingScaleValue GetByID(int id)
        {
            return new QuestionRatingScaleValueRepository().GetByID(id, false);
        }

        public IList<QuestionRatingScaleValue> GetAll()
        {
            return new QuestionRatingScaleValueRepository()
                .GetAll()
                .OrderByDescending(o => o.Title)
                .ToList<QuestionRatingScaleValue>(); ;
        }

        public QuestionRatingScaleValue Save(QuestionRatingScaleValue item)
        {
            return new QuestionRatingScaleValueRepository().SaveOrUpdate(item);
        }

        public void Delete(QuestionRatingScaleValue item)
        {
            new QuestionRatingScaleValueRepository().Delete(item);
        }

        public IList<QuestionRatingScaleValue> GetByRatingScaleID(int scaleid)
        {
            return new QuestionRatingScaleValueRepository().GetByRatingScaleID(scaleid);
        }
    }
}
