using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRR.Core.Domain.Interfaces
{
    public interface IPerformanceEvaluation : IItem, IAuditable
    {
        int PerformanceEvalutaionTemplateID { get; set; }
        bool IsGoal { get; set; }
        int? GoalID { get; set; }
        int AccountID { get; set; }
        int Evaluatee { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        string Instructions { get; set; }
        DateTime DueDate { get; set; }
        int Score { get; set; }
        bool Completed { get; set; }


        

    }
}
