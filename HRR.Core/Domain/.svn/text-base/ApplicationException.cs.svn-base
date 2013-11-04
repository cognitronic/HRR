using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace HRR.Core.Domain
{
    [Serializable]
    [DataContract]
    public class ApplicationException
    {
        [DataMember]
        public virtual int ID { get; set; }
        [DataMember]
        public virtual int AccountID { get; set; }
        [DataMember]
        public virtual string CurrentURL { get; set; }
        [DataMember]
        public virtual string StackTrace { get; set; }
        [DataMember]
        public virtual string Message { get; set; }
        [DataMember]
        public virtual string InnerMessage { get; set; }
        [DataMember]
        public virtual DateTime ExceptionDate { get; set; }
        [DataMember]
        public virtual int UserID { get; set; }
        [DataMember]
        public virtual string SessionData { get; set; }
        [DataMember]
        public virtual string ExceptionType { get; set; }
        [DataMember]
        public virtual Person UserRef { get; set; }
        [DataMember]
        public virtual Account AccountRef { get; set; }

        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
