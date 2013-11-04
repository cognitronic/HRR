using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRR.Core.Domain.Interfaces
{
    public interface IPerformanceEvaluationQuestionScore : IItem
    {
        int PerformanceEvaluationResponseID { get; set; }
        int PerformanceEvaluationTemplateQuestionID { get; set; }
        string Question { get; set; }
        string Answer { get; set; }
        
    }
}
