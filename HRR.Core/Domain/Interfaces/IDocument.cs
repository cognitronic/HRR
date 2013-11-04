using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRR.Core.Domain.Interfaces
{
    public interface IDocument : IItem
    {
        string Title { get; set; }
        string Description { get; set; }
        string Path { get; set; }
        int EnteredBy { get; set; }
        int ChangedBy { get; set; }
        DateTime DateCreated { get; set; }
        DateTime LastUpdated { get; set; }
        int PersonID { get; set; }
        bool IsPrivate { get; set; }
    }
}
