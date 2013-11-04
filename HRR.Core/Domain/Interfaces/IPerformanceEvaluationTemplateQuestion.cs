using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRR.Core.Domain.Interfaces
{
    public interface IPerformanceEvaluationTemplateQuestion : IItem, IAuditable
    {
        int PerformanceEvaluationTemplateID { get; set; }
        string Question { get; set; }
        bool IsSlider { get; set; }

    }
}
