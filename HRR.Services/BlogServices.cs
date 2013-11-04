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
    public class BlogServices
    {
        public Blog GetByID(int id)
        {
            return new BlogRepository().GetByID(id, false);
        }

        public Blog Save(Blog item)
        {
            return new BlogRepository().SaveOrUpdate(item);
        }

        public void Delete(Blog item)
        {
            new BlogRepository().Delete(item);
        }

        public IList<Blog> GetAllByAccount()
        {
            return new BlogRepository()
                .GetAllByAccount()
                .OrderByDescending(o => o.StartDate)
                .ToList<Blog>(); ;
        }

        public Blog GetLastestPost()
        {
            return new BlogRepository().GetLastestPost();
        }

        public Blog GetLastestPost(int accountid)
        {
            return new BlogRepository().GetLastestPost(accountid);
        }

        public IList<Blog> GetForFeed()
        {
            return new BlogRepository()
                .GetForFeed()
                .OrderByDescending(o => o.StartDate)
                .ToList<Blog>();
        }

        public IList<Blog> GetByCategory(int categoryid)
        {
            return new BlogRepository()
                .GetByCategory(categoryid)
                .OrderByDescending(o => o.StartDate)
                .ToList<Blog>();
        }
    }
}
