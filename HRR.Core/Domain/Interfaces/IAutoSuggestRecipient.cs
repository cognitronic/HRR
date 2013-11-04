using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRR.Core.Domain.Interfaces
{
    public interface IAutoSuggestRecipient
    {
        int ID { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        string AvatarPath { get; set; }
        string DepartmentName { get; set; }
        string Title { get; set; }
    }
}
