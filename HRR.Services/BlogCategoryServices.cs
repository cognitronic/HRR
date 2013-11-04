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
    public class BlogCategoryServices
    {
        public BlogCategory GetByID(int id)
        {
            return new BlogCategoryRepository().GetByID(id, false);
        }

        public IList<BlogCategory> GetAllByAccount()
        {
            return new BlogCategoryRepository()
                .GetAllByAccount()
                .OrderByDescending(o => o.Name)
                .ToList<BlogCategory>(); ;
        }

        public BlogCategory Save(BlogCategory item)
        {
            return new BlogCategoryRepository().SaveOrUpdate(item);
        }

        public void Delete(BlogCategory item)
        {
            new BlogCategoryRepository().Delete(item);
        }
    }
}
