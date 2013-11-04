using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRR.Core.Domain
{
    public enum MessageStatusType
    {
        READ = 2,
        UNREAD = 1,
        REPLIED = 3,
        DELETED = 4,
        ARCHIVED = 5,
        REPORT_TO_HR = 6
    }
}
