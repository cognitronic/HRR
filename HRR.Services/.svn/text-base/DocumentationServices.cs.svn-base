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
    public class DocumentationServices
    {
        public Documentation GetByID(int id)
        {
            return new DocumentationRepository().GetByID(id, false);
        }

        public IList<Documentation> GetAll()
        {
            return new DocumentationRepository()
                .GetAll()
                .OrderBy(o => o.SortOrder)
                .ToList<Documentation>(); ;
        }

        public Documentation Save(Documentation item)
        {
            return new DocumentationRepository().SaveOrUpdate(item);
        }

        public void Delete(Documentation item)
        {
            new DocumentationRepository().Delete(item);
        }

        public Documentation GetByName(string name)
        {
            return new DocumentationRepository().GetByName(name);
        }
    }
}
