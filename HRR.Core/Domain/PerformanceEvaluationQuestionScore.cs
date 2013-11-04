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
    public class PerformanceEvaluationQuestionScore : IPerformanceEvaluationQuestionScore
    {
        [DataMember]
        public virtual int PerformanceEvaluationResponseID { get; set; }

        [DataMember]
        public virtual int PerformanceEvaluationTemplateQuestionID { get; set; }

        [DataMember]
        public virtual string Question { get; set; }

        [DataMember]
        public virtual string Answer { get; set; }

        [DataMember]
        public virtual ItemType TypeOfItem { get; set; }

        [DataMember]
        public virtual object ItemReference { get; set; }

        [DataMember]
        public virtual int ID { get; set; }

        [DataMember]
        public virtual string Name { get; set; }

        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
