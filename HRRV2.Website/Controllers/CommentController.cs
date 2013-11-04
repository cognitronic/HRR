using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HRR.Core.Domain;
using HRR.Core;
using HRR.Core.Security;
using HRR.Services;
using HRR.Web;

namespace HRRV2.Website.Controllers
{
    public class CommentController : ApiController
    {
        private readonly CommentServices _commentServices = new CommentServices();
        ICacheStorage _cache = new MemcacheCacheAdapter();  

        [AcceptVerbs("GET", "POST")]
        [ActionName("CreateComment")]
        public string CreateComment(Comment comment)
        {
            comment.AccountID = SecurityContextManager.Current.CurrentAccount.ID;
            comment.ChangedBy = ((Person)SecurityContextManager.Current.CurrentUser).ID;
            comment.DateCreated = DateTime.Now;
            comment.EnteredBy = ((Person)SecurityContextManager.Current.CurrentUser).ID;
            comment.LastUpdated = DateTime.Now;
            comment.FollowUpDate = null;
            _commentServices.Save(comment);

            var c = comment;
            var a = new Activity();
            a.AccountID = c.AccountID;
            a.ActivityType = (int)ActivityType.COMMENT;
            a.DateCreated = DateTime.Now;
            a.PerformedBy = c.EnteredBy;
            a.PerformedFor = c.EnteredFor;
            a.URL = "/Comments/" + c.ID.ToString();
            new ActivityServices().Save(a);


            IdeaSeed.Core.Data.NHibernate.NHibernateSessionManager.Instance.CloseSession();

            if (c.CommentType == -1 || c.CommentType == 1)
            {
                var nc = new CommentServices().GetByID(c.ID);
                if (new TeamMemberServices().GetByPersonIDTeamID(c.EnteredFor, c.TeamID).RecievesNotifications)
                {
                    EmailHelper.SendNewCommentNotification(nc);
                }
            }
            _cache.Remove(SecurityContextManager
                    .Current
                    .CurrentUser.ID.ToString() + "_CommentsFeed");
            return "1:Comment Successfully Created!:/Comments";
        }
    }
}