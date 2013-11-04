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
    public class Poll : IPoll
    {
        [DataMember]
        public virtual int ID { get; set; }
        [DataMember]
        public virtual DateTime StartDate { get; set; }
        [DataMember]
        public virtual DateTime EndDate { get; set; }
        [DataMember]
        public virtual string Question { get; set; }
        [DataMember]
        public virtual bool IsActive { get; set; }
        [DataMember]
        public virtual int EnteredBy{ get; set; }
        [DataMember]
        public virtual int ChangedBy{ get; set; }
        [DataMember]
        public virtual DateTime DateCreated{ get; set; }
        [DataMember]
        public virtual DateTime LastUpdated{ get; set; }
        [DataMember]
        public virtual int AccountID { get; set; }
        [DataMember]
        public virtual int TotalPolled { get; set; }
        [DataMember]
        public virtual Account AccountRef { get; set; }
        [DataMember]
        public virtual Person EnteredByRef { get; set; }
        private IList<PollOption> _options = new List<PollOption>();
        [DataMember]
        public virtual IList<PollOption> Options { get { return _options; } set { _options = value; } }
        private IList<PollResult> _results = new List<PollResult>();
        [DataMember]
        public virtual IList<PollResult> Results { get { return _results; } set { _results = value; } }

        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
