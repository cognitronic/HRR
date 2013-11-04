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
    public class PerformanceEvaluationTemplateQuestion : IPerformanceEvaluationTemplateQuestion
    {
        [DataMember]
        public virtual int PerformanceEvaluationTemplateID { get; set; }

        [DataMember]
        public virtual string Question { get; set; }

        [DataMember]
        public virtual bool IsSlider { get; set; }

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

        [DataMember]
        public virtual PerformanceEvaluationTemplate PerformanceEvaluationTemplateRef { get; set; }

        private IList<PerformanceEvaluationSliderValue> _sliderValues = new List<PerformanceEvaluationSliderValue>();
        [DataMember]
        public virtual IList<PerformanceEvaluationSliderValue> SliderValues { get { return _sliderValues; } set { _sliderValues = value; } }

        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
