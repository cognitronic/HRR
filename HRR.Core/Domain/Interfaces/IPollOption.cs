using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRR.Core.Domain.Interfaces
{
    public interface IPollOption
    {
        int ID { get; set; }
        int PollID { get; set; }
        string Title { get; set; }
        int TotalSelected { get; set; }
    }
}
