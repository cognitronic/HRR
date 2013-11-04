using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRR.Core.Domain;
using HRR.Persistence.Repositories;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace HRR.Services
{
    public class NoteServices
    {
        public Note GetByID(int id)
        {
            return new NoteRepository().GetByID(id, false);
        }

        public IList<Note> GetByEnteredFor(int enteredfor)
        {
            return new NoteRepository().GetByEnteredFor(enteredfor);
        }

        public Note Save(Note item)
        {
            return new NoteRepository().SaveOrUpdate(item);
        }

        public void Delete(Note item)
        {
            new NoteRepository().Delete(item);
        }
    }
}
