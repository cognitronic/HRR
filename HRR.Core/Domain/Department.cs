using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRR.Core.Domain.Interfaces;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using IdeaSeed.Core;

namespace HRR.Core.Domain
{
    [Serializable]
    [DataContract]
    public class Department : IDepartment
    {
        [DataMember]
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual ItemType TypeOfItem { get; set; }
        public virtual object ItemReference { get; set; }
        [DataMember]
        public virtual string Description { get; set; }
        [DataMember]
        public virtual int AccountID { get; set; }
        private IList<Person> _people = new List<Person>();
        [DataMember]
        public virtual IList<Person> People { get { return _people; } set { _people = value; } }

        public Department()
        {
            this.TypeOfItem = ItemType.DEPARTMENT;
        }

        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
