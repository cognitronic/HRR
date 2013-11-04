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
    public class Note : INote
    {
        #region INote Members

        [DataMember]
        public virtual string Body { get; set; }
        [DataMember]
        public virtual string Title { get; set; }
        [DataMember]
        public virtual int NoteType { get; set; }
        [DataMember]
        public virtual Person EnteredByRef { get; set; }
        [DataMember]
        public virtual Person EnteredForRef { get; set; }
        [DataMember]
        public virtual Person ChangedByRef { get; set; }

        #endregion

        #region IItem Members


        [DataMember]
        public virtual ItemType TypeOfItem { get; set; }
        [DataMember]
        public virtual object ItemReference { get; set; }
        #endregion

        #region IBaseItem Members


        [DataMember]
        public virtual int ID { get; set; }
        [DataMember]
        public virtual string Name { get; set; }
        #endregion

        #region IAuditable Members


        [DataMember]
        public virtual int EnteredBy { get; set; }
        [DataMember]
        public virtual int EnteredFor { get; set; }
        [DataMember]
        public virtual int ChangedBy { get; set; }
        [DataMember]
        public virtual DateTime DateCreated { get; set; }
        [DataMember]
        public virtual DateTime LastUpdated { get; set; }

        #endregion
    }
}
