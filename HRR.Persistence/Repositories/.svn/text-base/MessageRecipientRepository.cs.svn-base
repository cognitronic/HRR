using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using IdeaSeed.Core.Data.NHibernate;
using IdeaSeed.Core.Data;
using HRR.Core.Domain;
using HRR.Core.Security;
using HRR.Core.Domain.Interfaces;

namespace HRR.Persistence.Repositories
{
    public class MessageRecipientRepository : BaseRepository<MessageRecipient, int>
    {
        public IList<MessageRecipient> GetByRecipient(int recipient)
        {
            return Session.CreateCriteria<MessageRecipient>()
                    .Add(Expression.Eq("RecipientID", recipient))
                    .List<MessageRecipient>();
        }

        public MessageRecipient GetByRecipientMessageID(int recipient, int messageid)
        {
            return Session.CreateCriteria<MessageRecipient>()
                    .Add(Expression.Eq("RecipientID", recipient))
                    .Add(Expression.Eq("MessageID", messageid))
                    .UniqueResult<MessageRecipient>();
        }

        public IList<MessageRecipient> GetByRecipientFolderID(int recipient, int folderid)
        {
            return Session.CreateCriteria<MessageRecipient>()
                    .Add(Expression.Eq("RecipientID", recipient))
                    .Add(Expression.Eq("MessageFolderID", folderid))
                    .List<MessageRecipient>();
        }
    }
}
