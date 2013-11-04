using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using IdeaSeed.Core.Data.NHibernate;
using IdeaSeed.Core.Data;
using HRR.Core.Domain;
using HRR.Core.Security;
using HRR.Core.Domain.Interfaces;

namespace HRR.Persistence.Repositories
{
    public class CommentRepository : BaseRepository<Comment, int>
    {
        public IList<Comment> GetByEnteredBy(int enteredby)
        {
            return Session.CreateCriteria<Comment>()
                .Add(Expression.Eq("EnteredBy", enteredby))
                .Add(Expression.Eq("FlaggedAsInappropriate", false))
                .List<Comment>();
        }

        public IList<Comment> GetByTeamID(int teamid)
        {
            var session = Session.CreateCriteria<Comment>()
                .Add(Expression.Eq("FlaggedAsInappropriate", false))
                .Add(Expression.Or(
                 Expression.Eq("TeamID", 999999),
                 Expression.Eq("TeamID", teamid)))
                 .Add(Expression.Eq("AccountID", SecurityContextManager.Current.CurrentAccount.ID))
                .List<Comment>();
            return session;
        }

        public IList<Comment> GetByEnteredFor(int enteredfor)
        {
            return Session.CreateCriteria<Comment>()
                .Add(Expression.Eq("EnteredFor", enteredfor))
                .Add(Expression.Eq("FlaggedAsInappropriate", false))
                .List<Comment>();
        }

        public IList<Comment> GetAllAppropriateForFeed()
        {
            return Session.CreateCriteria<Comment>()
                .Add(Expression.Eq("FlaggedAsInappropriate", false))
                .Add(Expression.Eq("AccountID", SecurityContextManager.Current.CurrentAccount.ID))
                .SetMaxResults(50)
                .AddOrder(Order.Desc("ID"))
                .List<Comment>();
        }

        public IList<Comment> GetAllAppropriate()
        {
            return Session.CreateCriteria<Comment>()
                .Add(Expression.Eq("FlaggedAsInappropriate", false))
                .Add(Expression.Eq("AccountID", SecurityContextManager.Current.CurrentAccount.ID))
                .List<Comment>();
        }

        public IList<Comment> GetAllFlagged()
        {
            return Session.CreateCriteria<Comment>()
                .Add(Expression.Eq("FlaggedAsInappropriate", true))
                .Add(Expression.Eq("AccountID", SecurityContextManager.Current.CurrentAccount.ID))
                .List<Comment>();
        }

        public IList<Comment> GetFlaggedByTeamID(int teamID)
        {
            return Session.CreateCriteria<Comment>()
                .Add(Expression.Eq("FlaggedAsInappropriate", true))
                .Add(Expression.Eq("TeamID", teamID))
                .List<Comment>();
        }

        public IList<Comment> GetMyComments(int userID)
        {
            return Session.CreateCriteria<Comment>()
             .Add(Expression.Eq("FlaggedAsInappropriate", false))
             .Add(Expression.Or(
                 Expression.Eq("EnteredFor", userID),
                 Expression.Eq("EnteredBy", userID))
        ).List<Comment>();
        }

        public IList<Comment> GetCommentsForReview(int userID, DateTime startdate, DateTime enddate)
        {
            return Session.CreateCriteria<Comment>()
             .Add(Expression.Between("DateCreated", startdate, enddate))
             .Add(Expression.Or(
                 Expression.Eq("EnteredFor", userID),
                 Expression.Eq("EnteredBy", userID))
        ).List<Comment>();
        }

        public IList<Comment> GetByFilters(int? userID)
        {
            var list = new List<SearchCriterion>();
            if (userID != null)
                list.Add(new SearchCriterion("EnteredFor", Operators.EQUALS, userID));
            if (userID != null)
                list.Add(new SearchCriterion("EnteredBy", Operators.EQUALS, userID));
            ICriteria query = Session.CreateCriteria<Comment>();
            foreach (var l in list)
            {
                switch (l.Operator)
                {
                    case Operators.EQUALS:
                        query.Add(Restrictions.Eq(l.SearchColumn, l.SearchCriteria));
                        
                        break;
                    case Operators.GREATER_THAN:
                        query.Add(Restrictions.Ge(l.SearchColumn, l.SearchCriteria));
                        break;
                    case Operators.LESS_THAN:
                        query.Add(Restrictions.Le(l.SearchColumn, l.SearchCriteria));
                        break;
                    case Operators.BETWEEN:
                        query.Add(Restrictions.In(l.SearchColumn, l.SearchCriteria));
                        break;
                }
            }
            return query.List<Comment>();
        }

        public CommentTotal GetCommentTotalsByEmployeeID(int empid, string start, string end)
        {
//            var result = Session.CreateSQLQuery(
//            @"SELECT Distinct (select count(*) from comment where enteredfor=" + empid.ToString() + @" and commenttype=1 and DateCreated between '" + start + @"' and '" + end + @"') as LeftForPositive, (select count(*) from comment where enteredfor=" + empid.ToString() + @" and commenttype=-1 and DateCreated between '" + start + @"' and '" + end + @"') as LeftForConstructive, (select count(*) from comment where enteredby=" + empid.ToString() + @" and commenttype=1 and DateCreated between '" + start + @"' and '" + end + @"') as LeftByPositive, (select count(*) from comment where enteredby=" + empid.ToString() + @" and commenttype=-1 and DateCreated between '" + start + @"' and '" + end + @"') as LeftByConstructive
//            FROM Comment 
//            WHERE EnteredBy = " + empid.ToString())
//            .SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean(typeof(CommentTotal)));
            var result = Session.CreateSQLQuery(
            @"SELECT Distinct (select count(*) from comment where enteredfor=" + empid.ToString() + @" and commenttype=1 and DateCreated between '" + start + @"' and '" + end + @"') as LeftForPositive, (select count(*) from comment where enteredfor=" + empid.ToString() + @" and commenttype=-1 and DateCreated between '" + start + @"' and '" + end + @"') as LeftForConstructive, (select count(*) from comment where enteredby=" + empid.ToString() + @" and commenttype=1 and DateCreated between '" + start + @"' and '" + end + @"') as LeftByPositive, (select count(*) from comment where enteredby=" + empid.ToString() + @" and commenttype=-1 and DateCreated between '" + start + @"' and '" + end + @"') as LeftByConstructive
            FROM Comment")
            .SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean(typeof(CommentTotal)));
            return result.UniqueResult<CommentTotal>();
        }

        public CommentTotal GetCommentTotalsForReviewResults(int empid, string start, string end)
        {
            //            var result = Session.CreateSQLQuery(
            //            @"SELECT Distinct (select count(*) from comment where enteredfor=" + empid.ToString() + @" and commenttype=1 and DateCreated between '" + start + @"' and '" + end + @"') as LeftForPositive, (select count(*) from comment where enteredfor=" + empid.ToString() + @" and commenttype=-1 and DateCreated between '" + start + @"' and '" + end + @"') as LeftForConstructive, (select count(*) from comment where enteredby=" + empid.ToString() + @" and commenttype=1 and DateCreated between '" + start + @"' and '" + end + @"') as LeftByPositive, (select count(*) from comment where enteredby=" + empid.ToString() + @" and commenttype=-1 and DateCreated between '" + start + @"' and '" + end + @"') as LeftByConstructive
            //            FROM Comment 
            //            WHERE EnteredBy = " + empid.ToString())
            //            .SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean(typeof(CommentTotal)));
            var result = Session.CreateSQLQuery(
            @"SELECT Distinct (select count(*) from comment where enteredfor=" + empid.ToString() + @" and commenttype=1 and IncludedInReview=1 and DateCreated between '" + start + @"' and '" + end + @"') as LeftForPositive, (select count(*) from comment where enteredfor=" + empid.ToString() + @" and commenttype=-1 and IncludedInReview=1 and DateCreated between '" + start + @"' and '" + end + @"') as LeftForConstructive, (select count(*) from comment where enteredby=" + empid.ToString() + @" and commenttype=1 and IncludedInReview=1 and DateCreated between '" + start + @"' and '" + end + @"') as LeftByPositive, (select count(*) from comment where enteredby=" + empid.ToString() + @" and commenttype=-1 and IncludedInReview=1 and DateCreated between '" + start + @"' and '" + end + @"') as LeftByConstructive
            FROM Comment")
            .SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean(typeof(CommentTotal)));
            return result.UniqueResult<CommentTotal>();
        }
    }
}
