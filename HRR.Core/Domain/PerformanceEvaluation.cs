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
    public class PerformanceEvaluation : IPerformanceEvaluation
    {
        [DataMember]
        public virtual int PerformanceEvalutaionTemplateID { get; set; }

        [DataMember]
        public virtual bool IsGoal { get; set; }

        [DataMember]
        public virtual int? GoalID { get; set; }

        [DataMember]
        public virtual int AccountID { get; set; }

        [DataMember]
        public virtual int Evaluatee { get; set; }

        [DataMember]
        public virtual string Title { get; set; }

        [DataMember]
        public virtual string Description { get; set; }

        [DataMember]
        public virtual string Instructions { get; set; }

        [DataMember]
        public virtual DateTime DueDate { get; set; }

        [DataMember]
        public virtual int Score { get; set; }

        [DataMember]
        public virtual bool Completed { get; set; }

        [DataMember]
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

        private IList<PerformanceEvaluationResponse> _responses = new List<PerformanceEvaluationResponse>();
        [DataMember]
        public virtual IList<PerformanceEvaluationResponse> Responses { get { return _responses; } set { _responses = value; } }

        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
