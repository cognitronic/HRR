using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HRR.Core.Domain;
using HRR.Services;
using HRR.Core.Security;

namespace HRR.WebAPI.Controllers
{
    public class CommentsController : ApiController
    {
        public Comment GetByID(int id)
        {
            return new CommentServices().GetByID(id);
        }

        public IList<Comment> GetAll()
        {
            return new CommentServices()
                .GetAllAppropriate();
        }

        public Comment Save(Comment item)
        {
            return new CommentServices().Save(item);
        }

        public void Delete(Comment item)
        {
            new CommentServices().Delete(item);
        }

        //public IList<Comment> GetAllAppropriate()
        //{
        //    return new CommentServices().GetAllAppropriate();
        //}

        //public IList<Comment> GetAllAppropriateForFeed()
        //{
        //    return new CommentServices().GetAllAppropriateForFeed();
        //}

        public IList<Comment> GetByEnteredBy(int enteredby)
        {
            return new CommentServices().GetByEnteredBy(enteredby);
        }

        public IList<Comment> GetByEnteredFor(int enteredfor)
        {
            return new CommentServices().GetByEnteredFor(enteredfor);
        }

        public IList<Comment> GetMyComments(int userID)
        {
            return new CommentServices().GetMyComments(userID);
        }

        public IList<Comment> GetByTeamID(int teamid)
        {
            return new CommentServices().GetByTeamID(teamid);
        }
    }
}
