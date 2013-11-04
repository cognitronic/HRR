using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRR.Core.Domain.Interfaces
{
    public interface IPoll
    {
        int ID { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string Question { get; set; }
        bool IsActive { get; set; }
        int AccountID { get; set; }
        int TotalPolled { get; set; }
    }
}
