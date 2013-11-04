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
    public class ReviewTemplate : IReviewTemplate
    {
        [DataMember]
        public virtual int ID { get; set; }
        [DataMember]
        public virtual string Name { get; set; }
        public virtual ItemType TypeOfItem { get; set; }
        public virtual object ItemReference { get; set; }
        [DataMember]
        public virtual string Title { get; set; }
        [DataMember]
        public virtual bool IsActive { get; set; }
        [DataMember]
        public virtual int AccountID { get; set; }
        [DataMember]
        public virtual Account AccountRef { get; set; }
        private IList<ReviewTemplateQuestion> _questions = new List<ReviewTemplateQuestion>();
        [DataMember]
        public virtual IList<ReviewTemplateQuestion> Questions { get { return _questions; } set { _questions = value; } }

        public ReviewTemplate()
        {
            this.TypeOfItem = ItemType.REVIEW_TEMPLATE;
        }

        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
