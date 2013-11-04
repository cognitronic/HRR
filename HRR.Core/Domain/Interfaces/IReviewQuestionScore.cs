using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRR.Core.Domain.Interfaces
{
    public interface IReviewQuestionScore : IItem
    {
        int ReviewID { get; set; }
        int ReviewQuestionID { get; set; }
        int Score { get; set; }
        string Comment { get; set; }
        DateTime DateCreated { get; set; }
        int EnteredBy { get; set; }
    }
}
