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
    public class Documentation : IDocumentation
    {
        [DataMember]
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual ItemType TypeOfItem { get; set; }
        public virtual object ItemReference { get; set; }
        [DataMember]
        public virtual string HelpContent { get; set; }
        [DataMember]
        public virtual bool IsActive { get; set; }
        [DataMember]
        public virtual int SortOrder { get; set; }

        public Documentation()
        {
            this.TypeOfItem = ItemType.DOCUMENTATION;
        }

        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
