using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRR.Core.Domain.Interfaces
{
    public interface IPerformanceEvaluationSliderValue : IItem, IAuditable
    {
        string Title { get; set; }
        int Value { get; set; }
        int PerformanceEvaluationTemplateQuestionID { get; set; }
    }
}
