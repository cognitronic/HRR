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
    public class PollOption : IPollOption
    {
        [DataMember]
        public virtual int ID { get; set; }
        [DataMember]
        public virtual int PollID { get; set; }
        [DataMember]
        public virtual string Title { get; set; }
        [DataMember]
        public virtual Poll PollRef { get; set; }
        [DataMember]
        public virtual int TotalSelected { get; set; }

        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
