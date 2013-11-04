using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRR.Core.Domain;
using HRR.Core;
using HRR.Core.Security;
using HRR.Persistence.Repositories;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace HRR.Services
{
    public class MessageServices
    {
        public Message GetByID(int id)
        {
            return new MessageRepository().GetByID(id, false);
        }

        //public IList<Message> GetAll()
        //{
        //    return new MessageRepository()
        //        .GetAll()
        //        .OrderByDescending(o => o.DateCreated)
        //        .ToList<Message>();
        //}

        public IList<Message> GetSentBy(int sentby)
        {
            return new MessageRepository()
                .GetSentBy(sentby)
                .OrderByDescending(o => o.DateCreated)
                .ToList<Message>();
        }

        public Message Save(Message item)
        {
            return new MessageRepository().SaveOrUpdate(item);
        }

        public void Delete(Message item)
        {
            new MessageRepository().Delete(item);
        }

        public List<HRR.Core.Domain.Interfaces.IAutoSuggestRecipient> GetAutoSuggestRecipients()
        {
            List<HRR.Core.Domain.Interfaces.IAutoSuggestRecipient> list = 
                new PersonServices()
                .GetByAccountID(SecurityContextManager.Current.CurrentAccount.ID)
                .ToList<HRR.Core.Domain.Interfaces.IAutoSuggestRecipient>();
            foreach (var t in new TeamServices().GetByAccountID(SecurityContextManager.Current.CurrentAccount.ID))
            {
                var r = new HRR.Core.Domain.AutoSuggestRecipient();
                r.AvatarPath = ResourceStrings.DefaultTeamThumbImage;
                r.DepartmentName = "";
                r.Email = "team:" + t.ID.ToString();
                r.ID = t.ID;
                r.Name = t.Name;
                r.Title = "";
                list.Add(r);
            }
            return list;
        }
    }
}
