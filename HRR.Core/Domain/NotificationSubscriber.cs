using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRR.Core.Domain.Interfaces;
using IdeaSeed.Core;


namespace HRR.Core.Domain
{
    public class NotificationSubscriber : INotificationSubscriber
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual ItemType TypeOfItem { get; set; }
        public virtual object ItemReference { get; set; }
        public virtual int NotificationID { get; set; }
        public virtual int PersonID { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual Person Subscriber { get; set; }
        public virtual int AccountID { get; set; }
        //public virtual Notification NotificationRef { get; set; }

        public NotificationSubscriber()
        {
            this.TypeOfItem = ItemType.NOTIFICATION_SUBSCRIBER;
        }
    }
}
