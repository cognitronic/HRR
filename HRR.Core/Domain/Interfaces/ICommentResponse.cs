using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRR.Core.Domain.Interfaces
{
    public interface ICommentResponse : IItem
    {
        string Message { get; set; }
        int EnteredBy { get; set; }
        DateTime DateCreated { get; set; }
        int CommentID { get; set; }
    }
}
