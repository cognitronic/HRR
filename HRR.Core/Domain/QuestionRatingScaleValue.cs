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
    public class QuestionRatingScaleValue : IQuestionRatingScaleValue
    {
        [DataMember]
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual ItemType TypeOfItem { get; set; }
        public virtual object ItemReference { get; set; }
        [DataMember]
        public virtual string Title { get; set; }
        [DataMember]
        public virtual int Value { get; set; }
        [DataMember]
        public virtual int QuestionRatingScaleID { get; set; }
        [DataMember]
        public virtual QuestionRatingScale RatingScaleRef { get; set; }

        public QuestionRatingScaleValue()
        {
            this.TypeOfItem = ItemType.QUESTION_RATING_SCALE_VALUE;
        }

        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
