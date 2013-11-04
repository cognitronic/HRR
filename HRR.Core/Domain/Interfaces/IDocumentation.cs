using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRR.Core.Domain.Interfaces
{
    public interface IDocumentation : IItem
    {
        bool IsActive { get; set; }
        string HelpContent { get; set; }
    }
}
