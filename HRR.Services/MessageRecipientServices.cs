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
    public class MessageRecipientServices
    {
        public MessageRecipient GetByID(int id)
        {
            return new MessageRecipientRepository().GetByID(id, false);
        }

        //public IList<Message> GetAll()
        //{
        //    return new MessageRepository()
        //        .GetAll()
        //        .OrderByDescending(o => o.DateCreated)
        //        .ToList<Message>();
        //}

        public IList<MessageRecipient> GetByRecipient(int recipientid)
        {
            return new MessageRecipientRepository()
                .GetByRecipient(recipientid)
                .OrderByDescending(o => o.MessageRef.DateCreated)
                .ToList<MessageRecipient>();
        }

        public MessageRecipient Save(MessageRecipient item)
        {
            return new MessageRecipientRepository().SaveOrUpdate(item);
        }

        public void Delete(MessageRecipient item)
        {
            new MessageRecipientRepository().Delete(item);
        }

        public IList<MessageRecipient> GetByRecipientFolderID(int recipient, int folderid)
        {
            return new MessageRecipientRepository().GetByRecipientFolderID(recipient, folderid);
        }

        public MessageRecipient GetByRecipientMessageID(int recipient, int messageid)
        {
            return new MessageRecipientRepository().GetByRecipientMessageID(recipient, messageid);
        }
    }
}
