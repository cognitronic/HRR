using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRR.Core.Domain;

namespace HRR.Core.Domain.Interfaces
{
    public interface IGoal : IItem, IAuditable
    {
        string Title { get; set; }
        string Description { get; set; }
        int EnteredFor { get; set; }
        bool IsApproved { get; set; }
        bool IsAccepted { get; set; }
        bool IsTemplate { get; set; }
        DateTime DueDate { get; set; }
        int Score { get; set; }
        int GoalType { get; set; }
        int StatusID { get; set; }
        int Progress { get; set; }
        int ReviewID { get; set; }
        int AccountID { get; set; }
        int Weight { get; set; }
        string ManagerEvaluation { get; set; }
        string EmployeeEvaluation { get; set; }
    }
}
