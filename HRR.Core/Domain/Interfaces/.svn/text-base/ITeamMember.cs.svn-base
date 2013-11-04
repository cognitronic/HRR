using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;

namespace HRR.Core.Domain.Interfaces
{
    public interface ITeamMember : IItem
    {
        int TeamID { get; set; }
        int PersonID { get; set; }
        bool IsActive { get; set; }
        bool RecievesNotifications { get; set; }
        bool IsManager { get; set; }
        bool HasAccess { get; set; }
        Team TeamRef { get; set; }
        Person PersonRef { get; set; }


    }
}
