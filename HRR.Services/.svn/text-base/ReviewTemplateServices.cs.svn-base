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
    public class ReviewTemplateServices
    {
        public ReviewTemplate GetByID(int id)
        {
            return new ReviewTemplateRepository().GetByID(id, false);
        }

        public IList<ReviewTemplate> GetAll()
        {
            return new ReviewTemplateRepository()
                .GetAllByAccount()
                .OrderByDescending(o => o.Title)
                .ToList<ReviewTemplate>(); ;
        }

        public ReviewTemplate Save(ReviewTemplate item)
        {
            return new ReviewTemplateRepository().SaveOrUpdate(item);
        }

        public void Delete(ReviewTemplate item)
        {
            new ReviewTemplateRepository().Delete(item);
        }
    }
}
