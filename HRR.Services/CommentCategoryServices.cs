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
    public class CommentCategoryServices
    {
        public CommentCategory GetByID(int id)
        {
            return new CommentCategoryRepository().GetByID(id, false);
        }

        public IList<CommentCategory> GetAll()
        {
            return new CommentCategoryRepository()
                .GetAllByAccount()
                .OrderBy(o => o.Name)
                .ToList<CommentCategory>(); ;
        }

        public CommentCategory Save(CommentCategory item)
        {
            return new CommentCategoryRepository().SaveOrUpdate(item);
        }

        public void Delete(CommentCategory item)
        {
            new CommentCategoryRepository().Delete(item);
        }
    }
}
