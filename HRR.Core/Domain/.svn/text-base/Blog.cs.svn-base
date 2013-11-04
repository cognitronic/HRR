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
    public class Blog : IBlog
    {
        [DataMember]
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual ItemType TypeOfItem { get; set; }
        public virtual object ItemReference { get; set; }
        [DataMember]
        public virtual string Title { get; set; }
        [DataMember]
        public virtual int EnteredBy { get; set; }
        [DataMember]
        public virtual DateTime StartDate { get; set; }
        [DataMember]
        public virtual DateTime EndDate { get; set; }
        [DataMember]
        public virtual string BlogContent { get; set; }
        [DataMember]
        public virtual int AccountID { get; set; }
        [DataMember]
        public virtual bool IsActive { get; set; }
        [DataMember]
        public virtual Person EnteredByRef { get; set; }
        [DataMember]
        public virtual Account AccountRef { get; set; }
        [DataMember]
        public virtual int BlogCategoryID { get; set; }
        [DataMember]
        public virtual BlogCategory Category { get; set; }
        private IList<BlogResponse> _responses = new List<BlogResponse>();
        [DataMember]
        public virtual IList<BlogResponse> Responses { get { return _responses; } set { _responses = value; } }

        public Blog()
        {
            this.TypeOfItem = ItemType.BLOG;
            this.Name = this.Title;
        }

        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
