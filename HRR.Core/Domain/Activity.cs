using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRR.Core.Domain.Interfaces;
using IdeaSeed.Core;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace HRR.Core.Domain
{
    public class Activity : IActivity
    {
        [DataMember]
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual ItemType TypeOfItem { get; set; }
        public virtual object ItemReference { get; set; }
        [DataMember]
        public virtual int ActivityType { get; set; }
        [DataMember]
        public virtual int AccountID { get; set; }
        [DataMember]
        public virtual string Title { get; set; }
        [DataMember]
        public virtual string URL { get; set; }
        [DataMember]
        public virtual int PerformedBy { get; set; }
        [DataMember]
        public virtual int PerformedFor { get; set; }
        [DataMember]
        public virtual DateTime DateCreated { get; set; }
        [DataMember]
        public virtual Person PerformedByRef { get; set; }
        [DataMember]
        public virtual Person PerformedForRef { get; set; }

        public Activity()
        {
            this.TypeOfItem = ItemType.ACTIVITY;
            this.Name = this.Title;
        }

        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
