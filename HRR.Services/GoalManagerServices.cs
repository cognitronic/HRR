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
    public class GoalManagerServices
    {
        public GoalManager GetByID(int id)
        {
            return new GoalManagerRepository().GetByID(id, false);
        }

        public IList<GoalManager> GetAll()
        {
            return new GoalManagerRepository()
                .GetAll()
                .OrderByDescending(o => o.PersonRef.LastName)
                .ToList<GoalManager>(); ;
        }

        public GoalManager Save(GoalManager item)
        {
            return new GoalManagerRepository().SaveOrUpdate(item);
        }

        public void Delete(GoalManager item)
        {
            new GoalManagerRepository().Delete(item);
        }

        public IList<GoalManager> GetByGoalID(int goalid)
        {
            return new GoalManagerRepository()
                .GetByGoalID(goalid)
                .OrderByDescending(o => o.PersonID)
                .ToList<GoalManager>(); 
        }
    }
}
