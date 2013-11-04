using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRR.Core.Domain.Interfaces
{
    public interface IPerformanceEvaluationTemplate : IItem, IAuditable
    {
        int AccountID { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        string Instructions { get; set; }
    }
}
