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
    public class Message : IMessage
    {
        [DataMember]
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual ItemType TypeOfItem { get; set; }
        public virtual object ItemReference { get; set; }
        [DataMember]
        public virtual int SentBy { get; set; }
        [DataMember]
        public virtual string Subject { get; set; }
        [DataMember]
        public virtual string Body { get; set; }
        [DataMember]
        public virtual DateTime DateCreated { get; set; }
        [DataMember]
        public virtual int MessageTypeID { get; set; }
        [DataMember]
        public virtual Person SentByRef { get; set; }
        private IList<MessageRecipient> _recipients = new List<MessageRecipient>();
        [DataMember]
        public virtual IList<MessageRecipient> Recipients { get { return _recipients; } set { _recipients = value; } }

        public Message()
        {
            this.TypeOfItem = ItemType.MESSAGE;
        }

        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
