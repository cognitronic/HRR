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
    public class TeamMemberRepository : BaseRepository<TeamMember, int>
    {
        public IList<TeamMember> GetByTeamID(int teamID)
        {
            return Session.CreateCriteria<TeamMember>()
                .Add(Expression.Eq("TeamID", teamID))
                .List<TeamMember>();
        }

        public IList<TeamMember> GetByPersonID(int personID)
        {
            return Session.CreateCriteria<TeamMember>()
                .Add(Expression.Eq("PersonID", personID))
                .List<TeamMember>();
        }

        public TeamMember GetByPersonIDTeamID(int personID, int teamID)
        {
            return Session.CreateCriteria<TeamMember>()
                .Add(Expression.Eq("PersonID", personID))
                .Add(Expression.Eq("TeamID", teamID))
                .UniqueResult<TeamMember>();
        }
    }
}
