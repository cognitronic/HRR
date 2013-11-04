using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRR.Core.Domain.Interfaces;
using IdeaSeed.Core;

namespace HRR.Core.Domain
{
    public class Comment : IComment
    {
        public virtual int ID { get; set; }
        public virtual int EnteredBy { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual int CommentType { get; set; }
        public virtual int CategoryID { get; set; }
        public virtual int SecurityType { get; set; }
        public virtual string Message { get; set; }
        public virtual int EnteredFor { get; set; }
        public virtual Person EnteredByRef { get; set; }
        public virtual Person EnteredForRef { get; set; }
        public virtual bool FlaggedAsInappropriate { get; set; }
    }
}
