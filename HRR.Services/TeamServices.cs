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
using HRR.Core.Security;

namespace HRR.Services
{
    public class TeamServices
    {
        public Team GetByID(int id)
        {
            return new TeamRepository().GetByID(id, false);
        }

        public IList<Team> GetByLikeName(string name)
        {
            return new TeamRepository().GetByLikeName(name);
        }

        public IList<Team> GetAll()
        {
            return new TeamRepository()
                .GetByAccountID(SecurityContextManager.Current.CurrentAccount.ID)
                .OrderByDescending(o => o.Name)
                .ToList<Team>(); ;
        }

        public Team Save(Team item)
        {
            return new TeamRepository().SaveOrUpdate(item);
        }

        public void Delete(Team item)
        {
            new TeamRepository().Delete(item);
        }

        public IList<Team> GetByAccountID(int accountID)
        {
            return new TeamRepository().GetByAccountID(accountID);
        }

        public Team GetByNameAccountID(string name, int accountID)
        {
            return new TeamRepository().GetByNameAccountID(name, accountID);
        }
    }
}
