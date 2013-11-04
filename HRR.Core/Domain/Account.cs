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
    [Serializable]
    [DataContract]
    public class Account : IAccount
    {
        [DataMember]
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual ItemType TypeOfItem { get; set; }
        public virtual object ItemReference { get; set; }
        [DataMember]
        public virtual int EnteredBy { get; set; }
        [DataMember]
        public virtual int ChangedBy { get; set; }
        [DataMember]
        public virtual DateTime DateCreated { get; set; }
        [DataMember]
        public virtual DateTime LastUpdated { get; set; }
        [DataMember]
        public virtual string Company { get; set; }
        [DataMember]
        public virtual string Domain { get; set; }
        [DataMember]
        public virtual string LogoPath { get; set; }
        [DataMember]
        public virtual int GoalsWeight { get; set; }
        [DataMember]
        public virtual int CommentsWeight { get; set; }
        [DataMember]
        public virtual int QuestionsWeight { get; set; }

        public Account()
        {
            this.TypeOfItem = ItemType.ACCOUNT;
            this.Name = this.Company;
        }

        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
