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
    public class MessageRecipient : IMessageRecipient
    {
        [DataMember]
        public virtual int ID { get; set; }
        [DataMember]
        public virtual int MessageID { get; set; }
        [DataMember]
        public virtual int RecipientTypeID { get; set; }
        [DataMember]
        public virtual int RecipientID { get; set; }
        [DataMember]
        public virtual int MessageFolderID { get; set; }
        [DataMember]
        public virtual int MessageStatusTypeID { get; set; }
        [DataMember]
        public virtual Message MessageRef { get; set; }
        [DataMember]
        public virtual Person RecipientRef { get; set; }

        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
