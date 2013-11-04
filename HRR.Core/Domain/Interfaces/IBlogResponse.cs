using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRR.Core.Domain.Interfaces
{
    public interface IBlogResponse : IItem
    {
        int BlogID {get; set; }
        string Comment { get; set; }
        DateTime DateCreated { get; set; }
        int EnteredBy { get; set; }
        bool FlaggedAsInappropriate { get; set; }
    }
}
