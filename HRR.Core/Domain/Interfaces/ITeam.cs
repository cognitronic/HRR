using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;

namespace HRR.Core.Domain.Interfaces
{
    public interface ITeam : IItem
    {
        string Description { get; set; }
        int AccountID { get; set; }
        IList<TeamMember> Members { get; set; }
    }
}
