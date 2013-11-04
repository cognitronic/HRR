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
using Newtonsoft.Json;

namespace HRR.API.Controllers
{
    public class EvaluationController : ApiController
    {
        private readonly PerformanceEvaluationServices _service = new PerformanceEvaluationServices();

        [HttpPost]
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
            return "1:Template Successfully Created!:/Evaluations/Template/" + template.ID.ToString();
        }

        [HttpPost]
        [ActionName("CreateTemplateWithSliders")]
        public string CreateTemplateWithSliders(PerformanceEvaluationTemplate _template)
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
            return "1:Template Successfully Created!:/Evaluations/Template/" + template.ID.ToString();
        }
    }
}
