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
    public class PollResult : IPollResult
    {
        [DataMember]
        public virtual int ID { get; set; }
        [DataMember]
        public virtual int PollID { get; set; }
        [DataMember]
        public virtual int PollOptionID { get; set; }
        [DataMember]
        public virtual int EnteredBy { get; set; }
        [DataMember]
        public virtual DateTime DateCreated { get; set; }
        [DataMember]
        public virtual Poll PollRef { get; set; }
        [DataMember]
        public virtual Person EnteredByRef { get; set; }
        [DataMember]
        public virtual PollOption PollOptionRef { get; set; }

        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
