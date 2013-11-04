using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;

namespace HRR.Core.Domain.Interfaces
{
    public interface IComment : IItem, IAuditable
    {
        int CommentType { get; set; }
        int CategoryID { get; set; }
        int SecurityType { get; set; }
        string Message { get; set; }
        int EnteredFor { get; set; }
        Person EnteredByRef { get; set; }
        Person EnteredForRef { get; set; }
        bool FlaggedAsInappropriate { get; set; }
        int AccountID { get; set; }
        int TeamID { get; set; }
        Team TeamRef { get; set; }
        CommentCategory Category { get; set; }
        DateTime? FollowUpDate { get; set; }
        string FollowUpResolution { get; set; }
        bool IncludedInReview { get; set; }
        string ReasonNotIncludedInReview { get; set; }
        Person ChangedByRef { get; set; }
        string Title { get; set; }
        bool IsPrivate { get; set; }
        bool IsAnonymous { get; set; }
    }
}
