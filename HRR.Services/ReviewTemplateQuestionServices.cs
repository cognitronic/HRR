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
    public class ReviewTemplateQuestionServices
    {
        public ReviewTemplateQuestion GetByID(int id)
        {
            return new ReviewTemplateQuestionRepository().GetByID(id, false);
        }

        public IList<ReviewTemplateQuestion> GetAll()
        {
            return new ReviewTemplateQuestionRepository()
                .GetAll()
                .OrderByDescending(o => o.ID)
                .ToList<ReviewTemplateQuestion>(); ;
        }

        public ReviewTemplateQuestion Save(ReviewTemplateQuestion item)
        {
            return new ReviewTemplateQuestionRepository().SaveOrUpdate(item);
        }

        public void Delete(ReviewTemplateQuestion item)
        {
            new ReviewTemplateQuestionRepository().Delete(item);
        }
    }
}
