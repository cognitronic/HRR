using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;

namespace HRR.Core.Domain.Interfaces
{
    public interface IActivity : IItem
    {
        int ActivityType { get; set; }
        string Title { get; set; }
        string URL { get; set; }
        int PerformedBy { get; set; }
        int PerformedFor { get; set; }
        int AccountID { get; set; }
        DateTime DateCreated { get; set; }
    }
}
