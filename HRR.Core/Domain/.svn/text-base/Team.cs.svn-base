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
    public class Team : ITeam
    {
        [DataMember]
        public virtual int ID { get; set; }
        [DataMember]
        public virtual string Name { get; set; }
        public virtual ItemType TypeOfItem { get; set; }
        public virtual object ItemReference { get; set; }
        [DataMember]
        public virtual string Description { get; set; }
        [DataMember]
        public virtual int AccountID { get; set; }
        private IList<TeamMember> _members = new List<TeamMember>();
        [DataMember]
        public virtual IList<TeamMember> Members { get { return _members; } set { _members = value; } }

        public Team()
        {
            this.TypeOfItem = ItemType.TEAM;
        }

        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
