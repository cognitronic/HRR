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
    public class Review : IReview, IAlert
    {
        [DataMember]
        public virtual int ID { get; set; }
        [DataMember]
        public virtual string Name { get; set; }
        public virtual ItemType TypeOfItem { get; set; }
        public virtual object ItemReference { get; set; }
        [DataMember]
        public virtual string Title { get; set; }
        [DataMember]
        public virtual DateTime StartDate { get; set; }
        [DataMember]
        public virtual DateTime DueDate { get; set; }
        [DataMember]
        public virtual int EnteredFor { get; set; }
        [DataMember]
        public virtual bool IsActive { get; set; }
        [DataMember]
        public virtual int EnteredBy { get; set; }
        [DataMember]
        public virtual DateTime DateCreated { get; set; }
        private IList<Goal> _goals = new List<Goal>();
        [DataMember]
        public virtual IList<Goal> Goals { get { return _goals; } set { _goals = value; } }
        private IList<ReviewNote> _notes = new List<ReviewNote>();
        [DataMember]
        public virtual IList<ReviewNote> Notes { get { return _notes; } set { _notes = value; } }
        private IList<ReviewManager> _managers = new List<ReviewManager>();
        [DataMember]
        public virtual IList<ReviewManager> Managers { get { return _managers; } set { _managers = value; } }
        [DataMember]
        public virtual Person EnteredByRef { get; set; }
        [DataMember]
        public virtual Person EnteredForRef { get; set; }
        [DataMember]
        public virtual int Status { get; set; }
        [DataMember]
        public virtual int Score { get; set; }
        [DataMember]
        public virtual int GoalsWeight { get; set; }
        [DataMember]
        public virtual int CommentsWeight { get; set; }
        [DataMember]
        public virtual int QuestionsWeight { get; set; }
        [DataMember]
        public virtual int ReviewTemplateID { get; set; }
        private IList<ReviewQuestionScore> _questionScore = new List<ReviewQuestionScore>();
        [DataMember]
        public virtual IList<ReviewQuestionScore> ReviewQuestionScores { get { return _questionScore; } set { _questionScore = value; } }
        public virtual AlertType ItemType { get; set; }
        [DataMember]
        public virtual int AccountID { get; set; }
        [DataMember]
        public virtual bool IsCurrent { get; set; }
        [DataMember]
        public virtual Review CurrentReview { get; set; }
        [DataMember]
        public virtual int ChangedBy { get; set; }
        [DataMember]
        public virtual DateTime LastUpdated { get; set; }
        [DataMember]
        public virtual Person ChangedByRef { get; set; }

        public Review()
        {
            this.ItemType = AlertType.REVIEW;
            this.TypeOfItem = Domain.ItemType.REVIEW;
        }

        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
        
    }
}
