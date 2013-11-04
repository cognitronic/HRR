using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRR.Core.Domain;
using HRR.Persistence.Repositories;
using HRR.Core.Security;

namespace HRR.Services
{
    public class PersonServices
    {
        public Person GetByID(int id)
        {
            return new PersonRepository().GetByID(id, false);
        }

        public IList<Person> GetAll()
        {
            if (SecurityContextManager.Current != null)
            {
                return new PersonRepository()
                    .GetByAccountID(((Person)SecurityContextManager.Current.CurrentUser).AccountID)
                    .OrderBy(o => o.LastName)
                    .ToList<Person>();
            }
            return null;
        }

        public IList<Person> GetByStatus(bool isactive)
        {
            return new PersonRepository()
                    .GetByStatus(isactive)
                    .OrderBy(o => o.LastName)
                    .ToList<Person>();
        }

        public IList<Person> GetEntirePersonList()
        {
            return new PersonRepository()
                    .GetAll()
                    .OrderBy(o => o.AccountID)
                    .ToList<Person>();
        }

        public IList<Person> GetByManagerID(int managerID)
        {
            return new PersonRepository().GetByManagerID(managerID);
        }

        public Person Save(Person item)
        {
            return new PersonRepository().SaveOrUpdate(item);
        }

        public void Delete(Person item)
        {
            new PersonRepository().Delete(item);
        }

        public Person GetByEmail(string email)
        {
            return new PersonRepository().GetByEmail(email);
        }

        public Person GetByEmailPassword(string email, string password)
        {
            return new PersonRepository().GetByEmailPassword(email, password);
        }

        public IList<Person> GetByDepartmentID(int departmentID)
        {
            return new PersonRepository().GetByDepartmentID(departmentID);
        }

        public IList<Person> GetByAccountID(int accountID)
        {
            return new PersonRepository().GetByAccountID(accountID);
        }

        public IList<Person> GetAllManagers()
        {
            return new PersonRepository().GetAllManagers();
        }

        public IList<Person> GetByUpcomingEvent(DateTime duedate)
        {
            //gets last day of the following month
            var dt = new DateTime(DateTime.Today.Year, DateTime.Today.AddMonths(1).Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.AddMonths(1).Month));
            return new PersonRepository().GetByUpcomingEvent(dt);
        }

        public IList<Person> GetByLikeName(string name)
        {
            return new PersonRepository().GetByLikeName(name);
        }

        public bool IsDuplicate(string email)
        { 
            var p = new PersonRepository().GetByEmail(email);
            if (p != null && p.Email == email)
                return true;
            return false;
        }

        public List<HRR.Core.Domain.Interfaces.IAutoSuggestRecipient> GetAllActiveAutoSuggestRecipientsByAccount()
        {
            var persons = new List<Person>();
            foreach (var p in new PersonServices()
            .GetByStatus(true))
            {
                persons.Add(p);
            }

            List<HRR.Core.Domain.Interfaces.IAutoSuggestRecipient> list =
                persons
                .ToList<HRR.Core.Domain.Interfaces.IAutoSuggestRecipient>();

            return list;
        }
    }
}
