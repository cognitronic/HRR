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
    public class DocumentServices
    {
        public Document GetByID(int id)
        {
            return new DocumentRepository().GetByID(id, false);
        }

        public IList<Document> GetAll()
        {
            return new DocumentRepository()
                .GetAll()
                .OrderByDescending(o => o.DateCreated)
                .ToList<Document>(); ;
        }

        public Document Save(Document item)
        {
            return new DocumentRepository().SaveOrUpdate(item);
        }

        public void Delete(Document item)
        {
            new DocumentRepository().Delete(item);
        }

        public IList<Document> GetByPersonID(int personID)
        {
            return new DocumentRepository().GetByPersonID(personID);
        }

        public IList<Document> GetByPublicPersonID(int personID)
        {
            return new DocumentRepository().GetByPublicPersonID(personID);
        }
    }
}
