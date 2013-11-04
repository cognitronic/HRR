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
    public class PollServices
    {
        public Poll GetByID(int id)
        {
            return new PollRepository().GetByID(id, false);
        }

        public Poll Save(Poll item)
        {
            return new PollRepository().SaveOrUpdate(item);
        }

        public void Delete(Poll item)
        {
            new PollRepository().Delete(item);
        }

        public IList<Poll> GetAllByAccount()
        {
            return new PollRepository()
                .GetAllByAccount()
                .OrderByDescending(o => o.StartDate)
                .ToList<Poll>();
        }

        public IList<Poll> GetAllActiveByAccount()
        {
            return new PollRepository()
                .GetAllActiveByAccount()
                .OrderByDescending(o => o.StartDate)
                .ToList<Poll>();
        }
    }
}
