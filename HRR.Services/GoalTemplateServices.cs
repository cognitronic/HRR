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
    public class GoalTemplateServices
    {
        public GoalTemplate GetByID(int id)
        {
            return new GoalTemplateRepository().GetByID(id, false);
        }

        public IList<GoalTemplate> GetAll()
        {
            return new GoalTemplateRepository()
                .GetAll()
                .OrderByDescending(o => o.GoalType)
                .ToList<GoalTemplate>(); ;
        }

        public GoalTemplate Save(GoalTemplate item)
        {
            return new GoalTemplateRepository().SaveOrUpdate(item);
        }

        public void Delete(GoalTemplate item)
        {
            new GoalTemplateRepository().Delete(item);
        }
    }
}
