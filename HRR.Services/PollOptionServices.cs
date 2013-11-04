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
    public class PollOptionServices
    {
        public PollOption GetByID(int id)
        {
            return new PollOptionRepository().GetByID(id, false);
        }

        public PollOption Save(PollOption item)
        {
            return new PollOptionRepository().SaveOrUpdate(item);
        }

        public void Delete(PollOption item)
        {
            new PollOptionRepository().Delete(item);
        }

        public IList<PollOption> GetByPollID(int pollid)
        {
            return new PollOptionRepository()
                .GetByPollID(pollid)
                .OrderByDescending(o => o.Title)
                .ToList<PollOption>();
        }
    }
}
