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
    public class ReviewQuestionScore : IReviewQuestionScore
    {
        [DataMember]
        public virtual int ID { get; set; }
        [DataMember]
        public virtual string Name { get; set; }
        public virtual ItemType TypeOfItem { get; set; }
        public virtual object ItemReference { get; set; }
        [DataMember]
        public virtual int ReviewID { get; set; }
        [DataMember]
        public virtual int ReviewQuestionID { get; set; }
        [DataMember]
        public virtual int Score { get; set; }
        [DataMember]
        public virtual string Comment { get; set; }
        [DataMember]
        public virtual DateTime DateCreated { get; set; }
        [DataMember]
        public virtual int EnteredBy { get; set; }
        [DataMember]
        public virtual ReviewTemplateQuestion Question { get; set; }

        public ReviewQuestionScore()
        {
            this.TypeOfItem = ItemType.REVIEW_QUESTION_SCORE;
        }

        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
