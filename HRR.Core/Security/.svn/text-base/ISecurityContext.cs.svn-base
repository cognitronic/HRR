using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;
using HRR.Core.Domain.Interfaces;

namespace HRR.Core.Security
{
    public interface ISecurityContext
    {
        bool IsAuthenticated { get; set; }
        IPerson CurrentUser { get; set; }
        IBaseApplicationPage CurrentPage { get; set; }
        IBaseEntity CurrentItem { get; set; }
        string BaseURL { get; set; }
        string CurrentURL { get; }
        string PreviousURL { get; set; }
        AccessLevels CurrentAccessLevel { get; set; }
        event EventHandler SignOut;
        void SignOutUser();
        void LogEvent(int userid, DateTime logdate, int typeid, int accountid, string description, string ipaddress, string machinename);
        void CreateAuthenticationTicket(string username, string userData, DateTime expiration, string url);
    }
}
