using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;

namespace HRR.Core.Domain.Interfaces
{
    public interface IDepartment : IItem
    {
        string Description { get; set; }
        IList<Person> People { get; set; }
        int AccountID { get; set; }
    }
}
