using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRR.Core.Domain;
using HRR.Core.Domain.Interfaces;
using HRR.Persistence.Repositories;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace HRR.Services
{
    public class NotificationServices
    {
        public Notification GetByID(int id)
        {
            return new NotificationRepository().GetByID(id, false);
        }

        public IList<Notification> GetAll()
        {
            return new NotificationRepository()
                .GetAllByAccount()
                .OrderBy(o => o.Name)
                .ToList<Notification>(); ;
        }

        public Notification Save(Notification item)
        {
            return new NotificationRepository().SaveOrUpdate(item);
        }

        public void Delete(Notification item)
        {
            new NotificationRepository().Delete(item);
        }
    }
}
