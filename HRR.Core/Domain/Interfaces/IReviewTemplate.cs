using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRR.Core.Domain.Interfaces
{
    public interface IReviewTemplate : IItem
    {
        string Title { get; set; }
        bool IsActive { get; set; }
        int AccountID { get; set; }
    }
}
