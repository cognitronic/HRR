using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;

namespace HRR.Core.Domain.Interfaces
{
    public interface INotificationSubscriber : IItem
    {
        int NotificationID { get; set; }
        int PersonID { get; set; }
        bool IsActive { get; set; }
        Person Subscriber { get; set; }
        int AccountID { get; set; }
    }
}
