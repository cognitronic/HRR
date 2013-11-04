using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRR.Core.Domain.Interfaces
{
    public interface IBlogCategory 
    {
        int ID { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        int AccountID { get; set; }
    }
}
