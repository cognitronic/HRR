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
    public class ApplicationExceptionServices
    {
        public HRR.Core.Domain.ApplicationException GetByID(int id)
        {
            return new ApplicationExceptionRepository().GetByID(id, false);
        }

        public IList<HRR.Core.Domain.ApplicationException> GetAll()
        {
            return new ApplicationExceptionRepository()
                .GetAllByAccount()
                .OrderByDescending(o => o.ExceptionDate)
                .ToList<HRR.Core.Domain.ApplicationException>(); ;
        }

        public HRR.Core.Domain.ApplicationException Save(HRR.Core.Domain.ApplicationException item)
        {
            return new ApplicationExceptionRepository().SaveOrUpdate(item);
        }

        public void Delete(HRR.Core.Domain.ApplicationException item)
        {
            new ApplicationExceptionRepository().Delete(item);
        }
    }
}
