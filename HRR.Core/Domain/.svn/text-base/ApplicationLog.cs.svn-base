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
    public class ApplicationLog : IApplicationLog
    {
        [DataMember]
        public virtual int ID { get; set; }
        [DataMember]
        public virtual int UserID { get; set; }
        [DataMember]
        public virtual string Description { get; set; }
        [DataMember]
        public virtual DateTime LogDate { get; set; }
        [DataMember]
        public virtual int LogTypeID { get; set; }
        [DataMember]
        public virtual string MachineName { get; set; }
        [DataMember]
        public virtual string IPAddress { get; set; }
        [DataMember]
        public virtual int AccountID { get; set; }
        [DataMember]
        public virtual Account AccountRef { get; set; }

        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
