using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRR.Core.Domain.Interfaces
{
    public interface IQuestionRatingScale : IItem
    {
        string Title { get; set; }
        int AccountID { get; set; }
    }
}
