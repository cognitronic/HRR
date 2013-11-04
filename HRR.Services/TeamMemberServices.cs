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
using HRR.Core.Security;
using HRR.Core;

namespace HRR.Services
{
    public class TeamMemberServices
    {
        public TeamMember GetByID(int id)
        {
            return new TeamMemberRepository().GetByID(id, false);
        }

        public IList<TeamMember> GetAll()
        {
            return new TeamMemberRepository()
                .GetAll()
                .OrderByDescending(o => o.TeamID)
                .ToList<TeamMember>(); ;
        }

        public TeamMember Save(TeamMember item)
        {
            return new TeamMemberRepository().SaveOrUpdate(item);
        }

        public void Delete(TeamMember item)
        {
            new TeamMemberRepository().Delete(item);
        }

        public IList<TeamMember> GetByTeamID(int teamID)
        {
            return new TeamMemberRepository().GetByTeamID(teamID);
        }

        public IList<TeamMember> GetByPersonID(int personID)
        {
            return new TeamMemberRepository().GetByPersonID(personID);
        }

        public TeamMember GetByPersonIDTeamID(int personID, int teamID)
        {
            return new TeamMemberRepository().GetByPersonIDTeamID(personID, teamID);
        }

        public List<HRR.Core.Domain.Interfaces.IAutoSuggestRecipient> GetAutoSuggestRecipientsByTeam()
        {
            var persons = new List<Person>();
            foreach(var p in new TeamMemberServices()
            .GetByTeamID((int)SecurityContextManager.Current.CurrentTeamID) )
            {
                persons.Add(p.PersonRef);
            }

            List<HRR.Core.Domain.Interfaces.IAutoSuggestRecipient> list =
                persons
                .ToList<HRR.Core.Domain.Interfaces.IAutoSuggestRecipient>();
            
            //foreach (var t in new TeamServices().GetByAccountID(SecurityContextManager.Current.CurrentAccount.ID))
            //{
            //    var r = new HRR.Core.Domain.AutoSuggestRecipient();
            //    r.AvatarPath = ResourceStrings.DefaultTeamThumbImage;
            //    r.DepartmentName = "";
            //    r.Email = "team:" + t.ID.ToString();
            //    r.ID = t.ID;
            //    r.Name = t.Name;
            //    r.Title = "";
            //    list.Add(r);
            //}
            return list;
        }
    }
}
