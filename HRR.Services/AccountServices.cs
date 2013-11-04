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
    public class AccountServices
    {
        public Account GetByID(int id)
        {
            return new AccountRepository().GetByID(id, false);
        }

        public IList<Account> GetAll()
        {
            return new AccountRepository()
                .GetAll()
                .OrderByDescending(o => o.Company)
                .ToList<Account>(); ;
        }

        public Account Save(Account item)
        {
            return new AccountRepository().SaveOrUpdate(item);
        }

        public void Delete(Account item)
        {
            new AccountRepository().Delete(item);
        }
    }
}
