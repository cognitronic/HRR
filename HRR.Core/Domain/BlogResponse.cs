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
    public class BlogResponse : IBlogResponse
    {
        [DataMember]
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual ItemType TypeOfItem { get; set; }
        public virtual object ItemReference { get; set; }
        [DataMember]
        public virtual int BlogID { get; set; }
        [DataMember]
        public virtual string Comment { get; set; }
        [DataMember]
        public virtual DateTime DateCreated { get; set; }
        [DataMember]
        public virtual int EnteredBy { get; set; }
        [DataMember]
        public virtual bool FlaggedAsInappropriate { get; set; }
        [DataMember]
        public virtual Blog BlogRef { get; set; }
        [DataMember]
        public virtual Person EnteredByRef { get; set; }

        public BlogResponse()
        {
            this.TypeOfItem = ItemType.BLOG_RESPONSE;
        }

        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
