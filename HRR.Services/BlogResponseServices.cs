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
    public class BlogResponseServices
    {
        public BlogResponse GetByID(int id)
        {
            return new BlogResponseRepository().GetByID(id, false);
        }

        public BlogResponse Save(BlogResponse item)
        {
            return new BlogResponseRepository().SaveOrUpdate(item);
        }

        public void Delete(BlogResponse item)
        {
            new BlogResponseRepository().Delete(item);
        }

        public IList<BlogResponse> GetByBlog(int blogid)
        {
            return new BlogResponseRepository().GetAllByBlog(blogid);
        }
    }
}
