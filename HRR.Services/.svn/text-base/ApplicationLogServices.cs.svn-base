using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRR.Core.Domain;
using HRR.Core.Domain.Interfaces;
using HRR.Persistence.Repositories;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace HRR.Services
{
    public class ApplicationLogServices
    {
        public HRR.Core.Domain.ApplicationLog GetByID(int id)
        {
            return new ApplicationLogRepository().GetByID(id, false);
        }

        public IList<HRR.Core.Domain.ApplicationLog> GetAll()
        {
            return new ApplicationLogRepository()
                .GetAllByAccount()
                .OrderByDescending(o => o.LogDate)
                .ToList<HRR.Core.Domain.ApplicationLog>(); ;
        }

        public HRR.Core.Domain.ApplicationLog Save(HRR.Core.Domain.ApplicationLog item)
        {
            return new ApplicationLogRepository().SaveOrUpdate(item);
        }

        public void Delete(HRR.Core.Domain.ApplicationLog item)
        {
            new ApplicationLogRepository().Delete(item);
        }
    }
}
