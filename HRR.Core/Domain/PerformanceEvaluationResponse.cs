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
    public class PerformanceEvaluationResponse : IPerformanceEvaluationResponse
    {
        [DataMember]
        public virtual int PerformanceEvaluationID { get; set; }

        [DataMember]
        public virtual string EvaluatorEmail { get; set; }

        [DataMember]
        public virtual int Evaluatee { get; set; }

        [DataMember]
        public virtual bool IsNonEmployee { get; set; }

        [DataMember]
        public virtual string Password { get; set; }

        [DataMember]
        public virtual int Score { get; set; }

        [DataMember]
        public virtual bool Completed { get; set; }

        [DataMember]
        public virtual DateTime DateCompleted { get; set; }

        [DataMember]
        public virtual ItemType TypeOfItem { get; set; }

        [DataMember]
        public virtual object ItemReference { get; set; }

        [DataMember]
        public virtual int ID { get; set; }

        [DataMember]
        public virtual string Name { get; set; }

        [DataMember]
        public virtual PerformanceEvaluation PerformanceEvaluationRef { get; set; }

        private IList<PerformanceEvaluationQuestionScore> _questions = new List<PerformanceEvaluationQuestionScore>();
        [DataMember]
        public virtual IList<PerformanceEvaluationQuestionScore> Questions { get { return _questions; } set { _questions = value; } }

        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
