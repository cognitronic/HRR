using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRR.Core.Security
{
    public class SecurityContextManager
    {
        private static IHRRSecurityContext _securityContext;

        private SecurityContextManager()
        {

        }

        public static IHRRSecurityContext Current
        {
            get
            {
                return _securityContext;
            }
            set
            {
                _securityContext = value;
            }
        }

    }
}
