using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using IdeaSeed.Core.Data.NHibernate;
using IdeaSeed.Core.Data;
using HRR.Core.Security;
using HRR.Core.Domain;

namespace HRR.Persistence.Repositories
{
    public class NotificationSubscriberRepository : BaseRepository<NotificationSubscriber, int>
    {
        public IList<NotificationSubscriber> GetByNotificationID(int notificationID)
        {
            return Session.CreateCriteria<NotificationSubscriber>()
                .Add(Expression.Eq("NotificationID", notificationID))
                .Add(Expression.Eq("AccountID", SecurityContextManager.Current.CurrentAccount.ID))
                .Add(Expression.Eq("IsActive", true))
                .List<NotificationSubscriber>();
        }

        public IList<NotificationSubscriber> GetByNotificationIDAccountID(int notificationID, int accountID)
        {
            return Session.CreateCriteria<NotificationSubscriber>()
                .Add(Expression.Eq("NotificationID", notificationID))
                .Add(Expression.Eq("AccountID", accountID))
                .Add(Expression.Eq("IsActive", true))
                .List<NotificationSubscriber>();
        }

        public IList<NotificationSubscriber> GetAllByAccountID(int accountID)
        {
            return Session.CreateCriteria<NotificationSubscriber>()
                .Add(Expression.Eq("AccountID", accountID))
                .Add(Expression.Eq("IsActive", true))
                .List<NotificationSubscriber>();
        }
    }
}
