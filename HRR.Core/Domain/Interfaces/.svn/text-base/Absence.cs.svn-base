using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRR.Core.Domain.Interfaces;

namespace HRR.Core.Domain
{
    [Serializable]
    public class Absence : IAbsence
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual ItemType TypeOfItem { get; set; }
        public virtual object ItemReference { get; set; }
        public virtual int EnteredBy { get; set; }
        public virtual int ChangedBy { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime LastUpdated { get; set; }
        public virtual int AccountID { get; set; }
        public virtual int EnteredFor { get; set; }
        public virtual DateTime FromDate { get; set; }
        public virtual DateTime ToDate { get; set; }
        public virtual int AbsentCategoryID { get; set; }
        public virtual string Note { get; set; }
        public virtual Account AccountRef { get; set; }
        public virtual Person EnteredForRef { get; set; }
        public virtual Person EnteredByRef { get; set; }

        public Absence()
        {
            this.TypeOfItem = ItemType.ABSENCE;
        }

    }
}
