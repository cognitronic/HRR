using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRR.Core.Domain.Interfaces
{
    public interface IPollResult
    {
        int ID { get; set; }
        int PollID { get; set; }
        int PollOptionID { get; set; }
        int EnteredBy { get; set; }
        DateTime DateCreated { get; set; }
    }
}
