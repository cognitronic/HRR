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
    public class ActivityServices
    {
        public Activity GetByID(int id)
        {
            return new ActivityRepository().GetByID(id, false);
        }

        public IList<Activity> GetAll()
        {
            return new ActivityRepository()
                .GetAllByAccount()
                .OrderByDescending(o => o.DateCreated)
                .ToList<Activity>(); ;
        }

        public IList<Activity> GetByMaxRows(int maxRows)
        {
            return new ActivityRepository()
                .GetByMaxRows(maxRows)
                .ToList<Activity>();
        }

        public IList<Activity> GetByDateRangeByAccount(Person person, DateTime startdate, DateTime enddate)
        {
            return new ActivityRepository().GetByDateRangeByAccount(person, startdate, enddate);
        }

        public IList<Activity> GetTeamsActivityByPerson(DateTime startdate, DateTime enddate, Person person)
        {
            var results = new List<Activity>();
            var list = new ActivityServices().GetByDateRangeByAccount(person, startdate, enddate);
            if (person.RoleID < (int)SecurityRole.EXECUTIVE_MANAGEMENT)
            {
                if (person.Memberships != null && person.Memberships.Count > 0)
                {
                    foreach (var t in person.Memberships)
                    {
                        foreach (var m in list)
                        {
                            foreach (var p in m.PerformedForRef.Memberships)
                            {
                                if (p.TeamID == t.TeamID && p.HasAccess)
                                    results.Add(m);
                                break;
                            }
                            foreach (var p in m.PerformedByRef.Memberships)
                            {
                                if (p.PersonID == person.ID && p.TeamID == t.TeamID && p.HasAccess)
                                    results.Add(m);
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                if(list != null)
                    results = list.ToList<Activity>();
            }

            return results;
        }

        public Activity Save(Activity item)
        {
            return new ActivityRepository().SaveOrUpdate(item);
        }

        public void Delete(Activity item)
        {
            new ActivityRepository().Delete(item);
        }
    }
}
