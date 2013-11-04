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
    public class QuestionRatingScale : IQuestionRatingScale
    {
        [DataMember]
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual ItemType TypeOfItem { get; set; }
        public virtual object ItemReference { get; set; }
        [DataMember]
        public virtual string Title { get; set; }
        [DataMember]
        public virtual int AccountID { get; set; }
        private IList<QuestionRatingScaleValue> _values = new List<QuestionRatingScaleValue>();
        [DataMember]
        public virtual IList<QuestionRatingScaleValue> Values { get { return _values; } set { _values = value; } }

        public QuestionRatingScale()
        {
            this.TypeOfItem = ItemType.QUESTION_RATING_SCALE;
        }

        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
