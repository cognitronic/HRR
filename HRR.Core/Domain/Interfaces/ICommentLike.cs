using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRR.Core.Domain.Interfaces
{
    public interface ICommentLike 
    {
        int ID { get; set; }
        int CommentID { get; set; }
        int PersonID { get; set; }
        DateTime DateCreated { get; set; }
    }
}
