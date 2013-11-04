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
    public class GoalCommunicationServices
    {
        public GoalCommunication GetByID(int id)
        {
            return new GoalCommunicationRepository().GetByID(id, false);
        }

        public IList<GoalCommunication> GetAll()
        {
            return new GoalCommunicationRepository()
                .GetAll()
                .OrderByDescending(o => o.DateCreated)
                .ToList<GoalCommunication>(); ;
        }

        public GoalCommunication Save(GoalCommunication item)
        {
            return new GoalCommunicationRepository().SaveOrUpdate(item);
        }

        public void Delete(GoalCommunication item)
        {
            new GoalCommunicationRepository().Delete(item);
        }

        public IList<GoalCommunication> GetByGoalID(int goalid)
        {
            return new GoalCommunicationRepository()
                .GetByGoalID(goalid)
                .OrderByDescending(o => o.DateCreated)
                .ToList<GoalCommunication>(); ;
        }
    }
}
