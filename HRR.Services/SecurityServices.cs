using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRR.Core.Domain;
using HRR.Persistence.Repositories;
using IdeaSeed.Core;
using HRR.Core.Security;

namespace HRR.Services
{
    public class SecurityServices
    {
        public HRR.Core.Security.AuthenticationResponse AuthenticateUser(string userName, string password, string url)
        {
            var u = new PersonRepository().GetByEmailPassword(userName, SecurityUtils.GetMd5Hash(password));
            var response = new HRR.Core.Security.AuthenticationResponse();
            if (u != null)
            {
                if (!u.IsActive)
                {
                    response.IsAuthenticated = false;
                    response.CurrentAccessLevel = AccessLevels.NOACCESS;
                    response.Message = "Your account has been marked as inactive.";
                    SecurityContextManager.Current.LogEvent(u.ID, DateTime.Now, (int)ApplicationLogTypes.USER_LOGIN_UNSECCESSFUL, u.AccountID, "Account is inactive", "", "");
                }
                else
                {
                    SecurityContextManager.Current.CreateAuthenticationTicket(u.Email, u.Email + "_" + u.ID.ToString() + "_" + u.Password, DateTime.Now.AddDays(480), url);
                    u.Memberships.Count();
                    //u.AccountRef.ToString();
                    SecurityContextManager.Current.CurrentUser = u;
                    SecurityContextManager.Current.CurrentProfile = u;
                    SecurityContextManager.Current.CurrentAccount = new AccountServices().GetByID(u.AccountID);
                    SecurityContextManager.Current.IsAuthenticated = true;
                    response.IsAuthenticated = true;
                    response.CurrentAccessLevel = AccessLevels.FULLACCESS;
                    SecurityContextManager.Current.LogEvent(u.ID, DateTime.Now, (int)ApplicationLogTypes.USER_LOGIN_SUCCESSFUL, u.AccountID, "", "", "");

                }
            }
            else
            {
                SecurityContextManager.Current.IsAuthenticated = false;
                response.IsAuthenticated = false;
                SecurityContextManager.Current.CurrentUser = null;
                response.Message = "Invalid username or password.  Please try again.";
            }

            return response;
        }

        public HRR.Core.Security.AuthenticationResponse AuthenticateUserCookie(string userName, string password, string url)
        {
            var u = new PersonRepository().GetByEmailPassword(userName, password);
            var response = new HRR.Core.Security.AuthenticationResponse();
            if (u != null)
            {
                if (!u.IsActive)
                {
                    response.IsAuthenticated = false;
                    response.CurrentAccessLevel = AccessLevels.NOACCESS;
                    response.Message = "Your account has been marked as inactive.";
                    SecurityContextManager.Current.LogEvent(u.ID, DateTime.Now, (int)ApplicationLogTypes.USER_LOGIN_UNSECCESSFUL, u.AccountID, "Account is inactive", "", "");
                }
                else
                {
                    SecurityContextManager.Current.CreateAuthenticationTicket(u.Email, u.Email + "_" + u.ID.ToString() + "_" + u.Password, DateTime.Now.AddDays(480), url);
                    u.Memberships.Count();
                    u.AccountRef.ToString();
                    SecurityContextManager.Current.CurrentUser = u;
                    SecurityContextManager.Current.CurrentAccount = u.AccountRef;
                    SecurityContextManager.Current.IsAuthenticated = true;
                    response.IsAuthenticated = true;
                    response.CurrentAccessLevel = AccessLevels.FULLACCESS;
                    SecurityContextManager.Current.LogEvent(u.ID, DateTime.Now, (int)ApplicationLogTypes.USER_LOGIN_SUCCESSFUL, u.AccountID, "", "", "");

                }
            }
            else
            {
                SecurityContextManager.Current.IsAuthenticated = false;
                response.IsAuthenticated = false;
                SecurityContextManager.Current.CurrentUser = null;
                response.Message = "Invalid username or password.  Please try again.";
            }

            return response;
        }

        public static void ClearUserCouchbaseCache(Person person)
        {
            MemcacheCacheAdapter.Instance.Remove(person.ID.ToString() + HRR.Core.ResourceStrings.CouchbaseCache_ActivityFeed);
            MemcacheCacheAdapter.Instance.Remove(person.ID.ToString() + HRR.Core.ResourceStrings.CouchbaseCache_AlertsFeed);
            MemcacheCacheAdapter.Instance.Remove(person.ID.ToString() + HRR.Core.ResourceStrings.CouchbaseCache_CommentsFeed);
            MemcacheCacheAdapter.Instance.Remove(person.ID.ToString() + HRR.Core.ResourceStrings.CouchbaseCache_DepartmentsList);
        }

        public void Signout()
        {
            var response = new HRR.Core.Security.AuthenticationResponse();
            SecurityContextManager.Current.IsAuthenticated = false;
            response.IsAuthenticated = false;
            SecurityContextManager.Current.CurrentUser = null;
        }

        public void CreateAuthenticationTicket()
        {
            throw new NotImplementedException();
        }

        public int GetCurrentPageAccessLevel(HRR.Core.Security.ISecurityContext securityContext)
        {
            //var pageUser = new PageRepository().getb(securityContext.CurrentPage.ID, securityContext.CurrentUser.ID);
            //if there is page level security, return access level
            //if (pageUser != null)
            //{
            //    return pageUser.AccessLevel;
            //}
            ////else, loop through the current user's module access and if user has access to the current page module, return access level
            //foreach (var m in securityContext.CurrentUser.UserModules)
            //{
            //    if (securityContext.CurrentPage.ModuleID == m.ModuleID)
            //    {
            //        return m.AccessLevel;
            //    }
            //}
            //otherwise no access.
            return (int)AccessLevels.NOACCESS;
        }

        public static bool IsUsernameAvailable(string username)
        {
            var u = new PersonRepository().GetByEmail(username);
            if (u == null || u.ID < 1)
                return true;
            return false;
        }
    }
}
