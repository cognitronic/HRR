using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRR.Core.Domain.Interfaces
{
    public interface IAbsence : IItem, IAuditable
    {
        int AccountID { get; set; }
        int EnteredFor { get; set; }
        DateTime FromDate { get; set; }
        DateTime ToDate { get; set; }
        int AbsentCategoryID { get; set; }
        string Note { get; set; }
    }
}
