using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRR.Core.Domain;

namespace HRR.Core.Domain.Interfaces
{
    public interface IReview : IItem
    {
        string Title { get; set; }
        DateTime StartDate { get; set; }
        bool IsActive { get; set; }
        DateTime DueDate { get; set; }
        int EnteredFor { get; set; }
        int EnteredBy { get; set; }
        DateTime DateCreated { get; set; }
        IList<Goal> Goals { get; set; }
        int Status { get; set; }
        int Score { get; set; }
        int ReviewTemplateID { get; set; }
        int AccountID { get; set; }
        bool IsCurrent { get; set; }
        int ChangedBy { get; set; }
        DateTime LastUpdated { get; set; }
    }
}
