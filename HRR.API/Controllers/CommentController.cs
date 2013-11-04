using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HRR.Core.Domain;
using HRR.Core.Security;
using HRR.Services;
using HRR.Web;

namespace HRR.API.Controllers
{
    public class CommentController : ApiController
    {
        private readonly CommentServices _commentServices = new CommentServices();

        [HttpPost]
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
            return "1:Comment Successfully Created!:/Comments";
        }
    }
}
