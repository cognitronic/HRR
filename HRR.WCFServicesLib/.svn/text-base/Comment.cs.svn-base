using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRR.Core.Domain.Interfaces;
using HRR.Core.Domain;
using IdeaSeed.Core;
using System.Runtime.Serialization;

namespace HRR.WCFServicesLib
{
    [DataContract]
    public class Comment : IComment
    {
        [DataMember]
        public virtual int ID { get; set; }
        [DataMember]
        public virtual int EnteredBy { get; set; }
        [DataMember]
        public virtual DateTime DateCreated { get; set; }
        [DataMember]
        public virtual int CommentType { get; set; }
        [DataMember]
        public virtual int CategoryID { get; set; }
        [DataMember]
        public virtual int AccountID { get; set; }
        [DataMember]
        public virtual int SecurityType { get; set; }
        [DataMember]
        public virtual string Message { get; set; }
        [DataMember]
        public virtual int EnteredFor { get; set; }
        [DataMember]
        public virtual Person EnteredByRef { get; set; }
        [DataMember]
        public virtual Person EnteredForRef { get; set; }
        [DataMember]
        public virtual bool FlaggedAsInappropriate { get; set; }
        [DataMember]
        public virtual CommentCategory Category { get; set; }
        [DataMember]
        public virtual Team TeamRef { get; set; }
        [DataMember]
        public virtual int TeamID { get; set; }
        [DataMember]
        public virtual DateTime? FollowUpDate { get; set; }
        [DataMember]
        public virtual string FollowUpResolution { get; set; }
        [DataMember]
        public virtual bool IncludedInReview { get; set; }
        [DataMember]
        public virtual string ReasonNotIncludedInReview { get; set; }
        [DataMember]
        public virtual int ChangedBy { get; set; }
        [DataMember]
        public virtual DateTime LastUpdated { get; set; }
        [DataMember]
        public virtual Person ChangedByRef { get; set; }

        public virtual ItemType TypeOfItem { get; private set; }
        public virtual object ItemReference { get; set; }
        public virtual string Name { get; set; }

        public Comment()
        {
            this.TypeOfItem = ItemType.COMMENT;
        }
    }
}
