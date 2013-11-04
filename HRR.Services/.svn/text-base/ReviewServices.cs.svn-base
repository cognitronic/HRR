using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRR.Core.Domain;
using HRR.Persistence.Repositories;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace HRR.Services
{
    public class ReviewServices
    {
        public Review GetByID(int id)
        {
            return new ReviewRepository().GetByID(id, false);
        }

        public IList<Review> GetAll()
        {
            return new ReviewRepository()
                .GetAll()
                .OrderByDescending(o => o.DateCreated)
                .ToList<Review>(); ;
        }

        public Review Save(Review item)
        {
            return new ReviewRepository().SaveOrUpdate(item);
        }

        public void Delete(Review item)
        {
            new ReviewRepository().Delete(item);
        }

        public IList<Review> GetByEnteredBy(int enteredby)
        {
            return new ReviewRepository().GetByEnteredBy(enteredby);
        }

        public IList<Review> GetByEnteredFor(int enteredfor)
        {
            return new ReviewRepository().GetByEnteredFor(enteredfor);
        }

        public IList<Review> GetByDueDate(DateTime duedate)
        {
            return new ReviewRepository().GetByDueDate(duedate);
        }

        public IList<Review> GetByAllActive()
        {
            return new ReviewRepository().GetByAllActive();
        }

        public Review GetEmployeeActiveReview(int enteredfor)
        {
            return new ReviewRepository().GetEmployeeActiveReview(enteredfor);
        }

        public static Dictionary<string, int> CalculateGoalsScore(Review review)
        {
            var result = new Dictionary<string, int>();
            decimal score = 0;
            if (review.Goals != null && review.Goals.Count > 0)
            {
                foreach (var g in review.Goals)
                {
                    score += (Convert.ToDecimal(g.Progress + g.Score) / 200) * g.Weight;
                }
                int weighted = Convert.ToInt16(score * (review.GoalsWeight * (decimal)0.01));
                result.Add("Natural", (int)score);
                result.Add("Weighted", weighted);
            }
            else
            {
                result.Add("Natural", 0);
                result.Add("Weighted", 0);
            }

            return result;
        }

        public static Dictionary<string, int> CalculateQuestionsScore(Review review)
        {
            var result = new Dictionary<string, int>();
            decimal score = 0;
            if (review.ReviewQuestionScores != null && review.ReviewQuestionScores.Count > 0)
            {
                foreach (var q in review.ReviewQuestionScores)
                {
                    score += (Convert.ToDecimal(q.Score));
                }
                score = (score / review.ReviewQuestionScores.Count);

                int weighted = Convert.ToInt16(score * (review.QuestionsWeight * (decimal)0.01));
                result.Add("Natural", (int)score);
                result.Add("Weighted", weighted);
            }
            else
            {
                result.Add("Natural", 0);
                result.Add("Weighted", 0);
            }
            return result;
        }

        public static Dictionary<string, int> CalculateCommentsScore(Review review)
        {
            var ct = new CommentServices().GetCommentTotalsByEmployeeID(review.EnteredFor, review.StartDate.ToShortDateString(), review.DueDate.ToShortDateString());
            var result = new Dictionary<string, int>();
            if (ct != null)
            {
                decimal score = 0;
                if ((ct.LeftForPositive + ct.LeftForConstructive) > 0)
                {
                    score = (Convert.ToDecimal(ct.LeftForPositive) / Convert.ToDecimal(ct.LeftForPositive + ct.LeftForConstructive)) * 100;
                }
                if (score < 1)
                    score = 0;
                int weighted = Convert.ToInt16(score * (review.CommentsWeight * (decimal)0.01));
                result.Add("Natural", (int)score);
                result.Add("Weighted", weighted);
            }
            else
            {
                result.Add("Natural", 0);
                result.Add("Weighted", 0);
            }
            return result;
        }
    }
}
