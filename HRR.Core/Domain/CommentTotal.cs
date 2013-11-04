using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRR.Core.Domain
{
    public class CommentTotal
    {
        public virtual int LeftForPositive { get; set; }
        public virtual int LeftForConstructive { get; set; }
        public virtual int LeftByPositive { get; set; }
        public virtual int LeftByConstructive { get; set; }
    }
}
