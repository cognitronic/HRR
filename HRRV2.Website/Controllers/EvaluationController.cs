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
using Newtonsoft.Json;

namespace HRRV2.Website.Controllers
{
    public class EvaluationController : ApiController
    {
        private readonly PerformanceEvaluationServices _service = new PerformanceEvaluationServices();

        [AcceptVerbs("GET", "POST")]
        [ActionName("GetEvaluationTemplates")]
        public string GetEvaluationTemplates(int accountID)
        {
            return JsonConvert.SerializeObject(_service.GetTemplates(accountID));
        }

        [HttpPost]
        [ActionName("CreateTemplate")]
        public string CreateTemplate(PerformanceEvaluationTemplate _template)
        {
            var template = new PerformanceEvaluationTemplate();
            template.Title = _template.Title;
            template.Description = _template.Description;
            template.Instructions = _template.Instructions;
            template.AccountID = SecurityContextManager.Current.CurrentAccount.ID;
            template.ChangedBy = ((Person)SecurityContextManager.Current.CurrentUser).ID;
            template.DateCreated = DateTime.Now;
            template.EnteredBy = ((Person)SecurityContextManager.Current.CurrentUser).ID;
            template.LastUpdated = DateTime.Now;
            _service.SaveTemplate(template);
            ICacheStorage _cache = new MemcacheCacheAdapter();
            _cache.Remove(SecurityContextManager
                    .Current
                    .CurrentUser.AccountID.ToString() + "_EvaluationTemplateList");

            return "1:Template Successfully Created!:/Evaluations/Templates/" + template.ID.ToString();
        }

        [HttpPost]
        [ActionName("CreateTemplateQuestion")]
        public string CreateTemplateQuestion(PerformanceEvaluationTemplateQuestion _question)
        {
            var template = new PerformanceEvaluationTemplateQuestion();
            template.Question = _question.Question;
            template.PerformanceEvaluationTemplateID = _question.PerformanceEvaluationTemplateID;
            template.IsSlider = false;
            template.ChangedBy = ((Person)SecurityContextManager.Current.CurrentUser).ID;
            template.DateCreated = DateTime.Now;
            template.EnteredBy = ((Person)SecurityContextManager.Current.CurrentUser).ID;
            template.LastUpdated = DateTime.Now;
            _service.SaveQuestion(template);
            //ICacheStorage _cache = new MemcacheCacheAdapter();
            //_cache.Remove(SecurityContextManager
            //        .Current
            //        .CurrentUser.AccountID.ToString() + "_EvaluationTemplateList");

            return "1:Template Successfully Created!:/Evaluations/Templates/" + template.ID.ToString();
        }

        [HttpPost]
        [ActionName("CreateTemplateSliderQuestion")]
        public string CreateTemplateSliderQuestion(PerformanceEvaluationTemplateQuestion _question)
        {
            var template = new PerformanceEvaluationTemplateQuestion();
            template.Question = _question.Question;
            template.PerformanceEvaluationTemplateID = _question.PerformanceEvaluationTemplateID;
            template.IsSlider = true;
            template.ChangedBy = ((Person)SecurityContextManager.Current.CurrentUser).ID;
            template.DateCreated = DateTime.Now;
            template.EnteredBy = ((Person)SecurityContextManager.Current.CurrentUser).ID;
            template.LastUpdated = DateTime.Now;
            _service.SaveQuestion(template);
            foreach (var t in _question.SliderValues)
            {
                t.EnteredBy = ((Person)SecurityContextManager.Current.CurrentUser).ID;
                t.DateCreated = DateTime.Now;
                t.ChangedBy = ((Person)SecurityContextManager.Current.CurrentUser).ID;
                t.LastUpdated = DateTime.Now;
                t.PerformanceEvaluationTemplateQuestionID = template.ID;
                t.Value = Convert.ToInt16(100 / _question.SliderValues.Count);
                _service.SaveSliderValue(t);
            }
            //ICacheStorage _cache = new MemcacheCacheAdapter();
            //_cache.Remove(SecurityContextManager
            //        .Current
            //        .CurrentUser.AccountID.ToString() + "_EvaluationTemplateList");

            return "1:Template Successfully Created!:/Evaluations/Templates/" + template.ID.ToString();
        }

        #region Template Questions

        [HttpPost]
        [HttpGet]
        [ActionName("GetEvaluationTemplateQuestions")]
        public string GetEvaluationTemplateQuestions(int templateID)
        {
            var list = _service.GetQuestionsByTemplateID(templateID);
            var questions = new List<TemplateQuestion>();
            foreach (var l in list)
            {
                questions.Add(new TemplateQuestion(l.Question, l.IsSlider, l.PerformanceEvaluationTemplateID));
            }
            return JsonConvert.SerializeObject(questions);
        }

        #endregion

        public class TemplateQuestion
        {
            public string Question { get; set; }
            public bool IsSlider { get; set; }
            public int PerformanceEvaluationTemplateID { get; set; }

            public TemplateQuestion(string question, bool isslider, int petid)
            {
                Question = question;
                IsSlider = isslider;
                PerformanceEvaluationTemplateID = petid;
            }
        }
    }
}