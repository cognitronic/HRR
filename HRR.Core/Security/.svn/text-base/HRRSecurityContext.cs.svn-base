using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRR.Core.Domain.Interfaces;
using HRR.Core.Domain;

namespace HRR.Core.Security
{
    public interface IHRRSecurityContext : HRR.Core.Security.ISecurityContext
    {
        Person CurrentProfile { get; set; }
        Account CurrentAccount { get; set; }
        int? CurrentTeamID { get; set; }
        Review CurrentReview { get; set; }
    }
}
