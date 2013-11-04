using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRR.Core.Domain.Interfaces
{
    public interface IPerformanceEvaluationResponse : IItem
    {
        int PerformanceEvaluationID { get; set; }
        string EvaluatorEmail { get; set; }
        int Evaluatee { get; set; }
        bool IsNonEmployee { get; set; }
        string Password { get; set; }
        int Score { get; set; }
        bool Completed { get; set; }
        DateTime DateCompleted { get; set; }

    }
}
