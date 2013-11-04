using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRR.Core.Domain;

namespace HRR.Core.Domain.Interfaces
{
    public interface IGoalCommunication : IItem
    {
        int GoalID { get; set; }
        string Message { get; set; }
        int EnteredBy { get; set; }
        DateTime DateCreated { get; set; }
    }
}
