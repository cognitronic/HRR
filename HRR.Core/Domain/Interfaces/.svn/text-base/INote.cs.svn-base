using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRR.Core.Domain.Interfaces
{
    public interface INote : IItem, IAuditable
    {
        string Body { get; set; }
        string Title { get; set; }
        int NoteType { get; set; }
        Person EnteredByRef { get; set; }
        Person EnteredForRef { get; set; }
    }
}
