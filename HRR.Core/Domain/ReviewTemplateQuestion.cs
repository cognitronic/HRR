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
    public class ReviewTemplateQuestion : IReviewTemplateQuestion
    {
        [DataMember]
        public virtual int ID { get; set; }
        [DataMember]
        public virtual string Name { get; set; }
        public virtual ItemType TypeOfItem { get; set; }
        public virtual object ItemReference { get; set; }
        [DataMember]
        public virtual int ReviewTemplateID { get; set; }
        [DataMember]
        public virtual string Question { get; set; }
        [DataMember]
        public virtual int CategoryID { get; set; }
        [DataMember]
        public virtual int QuestionRatingScaleID { get; set; }
        [DataMember]
        public virtual CommentCategory Category { get; set; }
        [DataMember]
        public virtual QuestionRatingScale RatingScale { get; set; }

        public ReviewTemplateQuestion()
        {
            this.TypeOfItem = ItemType.REVIEW_TEMPLATE_QUESTION;
        }

        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
