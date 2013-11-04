using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRR.Core.Domain
{
    public enum ActivityType
    {
        COMMENT = 1,
        NEW_EMPLOYEE = 2,
        NEW_GOAL = 3,
        NEW_MILESTONE = 4,
        GOAL_UPDATED = 5,
        REVIEW_UPDATED = 6,
        NEW_REVIEW = 7,
        MILESTONE_UPDATED = 8,
        NEW_GOAL_COMMENT = 9,
        NEW_COMMENT_RESPONSE = 10
    }
}
