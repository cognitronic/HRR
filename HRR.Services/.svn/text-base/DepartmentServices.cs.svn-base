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
    public class DepartmentServices
    {
        public Department GetByID(int id)
        {
            return new DepartmentRepository().GetByID(id, false);
        }

        public IList<Department> GetAll()
        {
            return new DepartmentRepository()
                .GetAllByAccount()
                .OrderBy(o => o.Name)
                .ToList<Department>(); ;
        }

        public Department Save(Department item)
        {
            return new DepartmentRepository().SaveOrUpdate(item);
        }

        public void Delete(Department item)
        {
            new DepartmentRepository().Delete(item);
        }
    }
}
