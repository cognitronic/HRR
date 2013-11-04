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
    public class GoalMilestoneServices
    {
        public GoalMilestone GetByID(int id)
        {
            return new GoalMilestoneRepository().GetByID(id, false);
        }

        public IList<GoalMilestone> GetAll()
        {
            return new GoalMilestoneRepository()
                .GetAll()
                .OrderByDescending(o => o.DateCreated)
                .ToList<GoalMilestone>(); ;
        }

        public GoalMilestone Save(GoalMilestone item)
        {
            return new GoalMilestoneRepository().SaveOrUpdate(item);
        }

        public void Delete(GoalMilestone item)
        {
            new GoalMilestoneRepository().Delete(item);
        }

        public IList<GoalMilestone> GetByDueDate(DateTime duedate)
        {
            return new GoalMilestoneRepository().GetByDueDate(duedate);
        }

        public IList<GoalMilestone> GetByGoalID(int goalid)
        {
            return new GoalMilestoneRepository()
                .GetByGoalID(goalid)
                .OrderByDescending(o => o.DateCreated)
                .ToList<GoalMilestone>(); ;
        }
    }
}
