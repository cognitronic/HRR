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
    public class QuestionRatingScaleServices
    {
        public QuestionRatingScale GetByID(int id)
        {
            return new QuestionRatingScaleRepository().GetByID(id, false);
        }

        public IList<QuestionRatingScale> GetAll()
        {
            return new QuestionRatingScaleRepository()
                .GetAllByAccount()
                .OrderByDescending(o => o.Title)
                .ToList<QuestionRatingScale>(); ;
        }

        public QuestionRatingScale Save(QuestionRatingScale item)
        {
            return new QuestionRatingScaleRepository().SaveOrUpdate(item);
        }

        public void Delete(QuestionRatingScale item)
        {
            new QuestionRatingScaleRepository().Delete(item);
        }
    }
}
