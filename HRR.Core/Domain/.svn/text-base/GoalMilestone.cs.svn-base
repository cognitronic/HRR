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
    public class GoalMilestone : IGoalMilestone, IAlert
    {
        [DataMember]
        public virtual int ID { get; set; }
        [DataMember]
        public virtual string Name { get; set; }
        public virtual ItemType TypeOfItem { get; set; }
        public virtual object ItemReference { get; set; }
        [DataMember]
        public virtual int GoalID { get; set; }
        [DataMember]
        public virtual string Title { get; set; }
        [DataMember]
        public virtual string Description { get; set; }
        [DataMember]
        public virtual bool IsAccepted { get; set; }
        [DataMember]
        public virtual DateTime DateCreated { get; set; }
        [DataMember]
        public virtual DateTime DueDate { get; set; }
        [DataMember]
        public virtual int EnteredBy { get; set; }
        [DataMember]
        public virtual int EnteredFor { get; set; }
        [DataMember]
        public virtual Person EnteredForRef { get; set; }
        [DataMember]
        public virtual Person EnteredByRef { get; set; }
        [DataMember]
        public virtual Goal GoalRef { get; set; }
        [DataMember]
        public virtual AlertType ItemType { get; set; }
        [DataMember]
        public virtual int Status { get; set; }
        [DataMember]
        public virtual int AccountID { get; set; }
        [DataMember]
        public virtual int ChangedBy { get; set; }
        [DataMember]
        public virtual Person ChangedByRef { get; set; }
        [DataMember]
        public virtual DateTime LastUpdated { get; set; }
        [DataMember]
        public virtual string ManagerEvaluation { get; set; }
        [DataMember]
        public virtual string EmployeeEvaluation { get; set; }
        [DataMember]
        public virtual bool IsComplete { get; set; }

        public GoalMilestone()
        {
            this.ItemType = AlertType.MILESTONE;
            this.TypeOfItem = Domain.ItemType.GOAL_MILESTONE;
            this.Name = this.Title;
        }

        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
