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
    public class AbsenceServices
    {
        public Absence GetByID(int id)
        {
            return new AbsenceRepository().GetByID(id, false);
        }

        public IList<Absence> GetAll()
        {
            return new AbsenceRepository()
                .GetAllByAccount()
                .OrderByDescending(o => o.FromDate)
                .ToList<Absence>(); ;
        }

        public IList<Absence> GetByEnteredFor(int enteredfor)
        {
            return new AbsenceRepository().GetByEnteredFor(enteredfor);
        }

        public Absence Save(Absence item)
        {
            return new AbsenceRepository().SaveOrUpdate(item);
        }

        public void Delete(Absence item)
        {
            new AbsenceRepository().Delete(item);
        }
    }
}
