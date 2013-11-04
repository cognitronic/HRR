using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRR.Core.Domain;
using HRR.Core.Domain.Interfaces;
using HRR.Core.Security;
using HRR.Persistence.Repositories;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using HRR.Core;

namespace HRR.Services
{
    public class AlertServices
    {
        public IList<IAlert> GetAlertsByDueDate(DateTime duedate)
        {
            var list = new List<IAlert>();
            foreach(var g in new GoalServices().GetByDueDate(duedate.AddDays(9)))
            {
                list.Add(g);
            }

            foreach (var m in new GoalMilestoneServices().GetByDueDate(duedate))
            {
                list.Add(m);
            }

            foreach (var r in new ReviewServices().GetByDueDate(duedate.AddDays(30)))
            {
                list.Add(r);
            }

            return list.OrderBy(o => o.DueDate).ToList();
        }

        public IList<IAlert> LoadAlerts(ICacheStorage cache, IHRRSecurityContext security)
        {
            var list = new List<HRR.Core.Domain.Interfaces.IAlert>();
            if (cache.Retrieve<List<HRR.Core.Domain.Interfaces.IAlert>>(security.CurrentAccount.ID.ToString() + "_AlertsFeed") == null)
            {
                list = new AlertServices().GetAlertsByDueDate(DateTime.Now.AddDays(21)).ToList<HRR.Core.Domain.Interfaces.IAlert>();
                cache.Store(security.CurrentAccount.ID.ToString() + "_AlertsFeed", list);
            }
            else
            {
                list = cache.Retrieve<List<HRR.Core.Domain.Interfaces.IAlert>>(security.CurrentAccount.ID.ToString() + "_AlertsFeed");
            }
            return list;
        }
    }
}
