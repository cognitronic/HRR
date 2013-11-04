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
    public class PollResultServices
    {
        public PollResult GetByID(int id)
        {
            return new PollResultRepository().GetByID(id, false);
        }

        public PollResult Save(PollResult item)
        {
            return new PollResultRepository().SaveOrUpdate(item);
        }

        public void Delete(PollResult item)
        {
            new PollResultRepository().Delete(item);
        }

        public IList<PollResult> GetByPollID(int pollid)
        {
            return new PollResultRepository()
                .GetByPollID(pollid)
                .OrderByDescending(o => o.ID)
                .ToList<PollResult>();
        }

        public PollResult GetByPollIDPersonID(int pollid, int personid)
        {
            return new PollResultRepository()
            .GetByPollIDPersonID(pollid, personid);
        }
    }
}
