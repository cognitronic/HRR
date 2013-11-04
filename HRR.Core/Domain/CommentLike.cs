using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRR.Core.Domain.Interfaces;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace HRR.Core.Domain
{
    [Serializable]
    [DataContract]
    public class CommentLike : ICommentLike
    {
        [DataMember]
        public virtual int ID { get; set; }
        [DataMember]
        public virtual int CommentID { get; set; }
        [DataMember]
        public virtual int PersonID { get; set; }
        [DataMember]
        public virtual DateTime DateCreated { get; set; }
    }
}
