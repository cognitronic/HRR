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
    public class TeamMember : ITeamMember
    {
        [DataMember]
        public virtual int ID { get; set; }
        [DataMember]
        public virtual string Name { get; set; }
        public virtual ItemType TypeOfItem { get; set; }
        public virtual object ItemReference { get; set; }
        [DataMember]
        public virtual int TeamID { get; set; }
        [DataMember]
        public virtual int PersonID { get; set; }
        [DataMember]
        public virtual bool IsActive { get; set; }
        [DataMember]
        public virtual bool RecievesNotifications { get; set; }
        [DataMember]
        public virtual bool IsManager { get; set; }
        [DataMember]
        public virtual bool HasAccess { get; set; }
        [DataMember]
        public virtual Team TeamRef { get; set; }
        [DataMember]
        public virtual Person PersonRef { get; set; }

        public TeamMember()
        {
            this.TypeOfItem = ItemType.TEAM_MEMBER;
        }

        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
