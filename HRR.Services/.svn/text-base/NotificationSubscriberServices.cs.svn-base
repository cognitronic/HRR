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
    public class NotificationSubscriberServices
    {
        public NotificationSubscriber GetByID(int id)
        {
            return new NotificationSubscriberRepository().GetByID(id, false);
        }

        public IList<NotificationSubscriber> GetByNotificationID(int notificationID)
        {
            return new NotificationSubscriberRepository()
                .GetByNotificationID(notificationID)
                .OrderBy(o => o.Subscriber.LastName)
                .ToList<NotificationSubscriber>(); ;
        }

        public NotificationSubscriber Save(NotificationSubscriber item)
        {
            return new NotificationSubscriberRepository().SaveOrUpdate(item);
        }

        public void Delete(NotificationSubscriber item)
        {
            new NotificationSubscriberRepository().Delete(item);
        }

        public IList<NotificationSubscriber> GetByNotificationIDAccountID(int notificationID, int accountID)
        {
            return new NotificationSubscriberRepository().GetByNotificationIDAccountID(notificationID, accountID);
        }

        public IList<NotificationSubscriber> GetAllByAccountID(int accountID)
        {
            return new NotificationSubscriberRepository().GetAllByAccountID(accountID);
        }
    }
}
