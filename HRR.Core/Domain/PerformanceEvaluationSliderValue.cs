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
    public class PerformanceEvaluationSliderValue : IPerformanceEvaluationSliderValue
    {
        [DataMember]
        public virtual string Title { get; set; }

        [DataMember]
        public virtual int Value { get; set; }

        [DataMember]
        public virtual int PerformanceEvaluationTemplateQuestionID { get; set; }

        public virtual ItemType TypeOfItem { get; set; }

        [DataMember]
        public virtual object ItemReference { get; set; }

        [DataMember]
        public virtual int ID { get; set; }

        [DataMember]
        public virtual string Name { get; set; }

        [DataMember]
        public virtual int EnteredBy { get; set; }

        [DataMember]
        public virtual int ChangedBy { get; set; }

        [DataMember]
        public virtual DateTime DateCreated { get; set; }

        [DataMember]
        public virtual DateTime LastUpdated { get; set; }

        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
