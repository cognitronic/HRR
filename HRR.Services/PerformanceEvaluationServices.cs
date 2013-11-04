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
    public class PerformanceEvaluationServices
    {
        #region Evaluation Template Services

        public PerformanceEvaluationTemplate GetTemplateByID(int id)
        {
            return new PerformanceEvaluationTemplateRepository().GetByID(id, false);
        }

        public PerformanceEvaluationTemplate SaveTemplate(PerformanceEvaluationTemplate item)
        {
            return new PerformanceEvaluationTemplateRepository().SaveOrUpdate(item);
        }

        public void DeleteTemplate(PerformanceEvaluationTemplate item)
        {
            new PerformanceEvaluationTemplateRepository().Delete(item);
        }

        public IList<PerformanceEvaluationTemplate> GetTemplates(int accountID)
        {
            return new PerformanceEvaluationTemplateRepository().GetTemplates(accountID);
        }

        #endregion

        #region Template Questions Services

        public IList<PerformanceEvaluationTemplateQuestion> GetQuestionsByTemplateID(int id)
        {
            return new PerformanceEvaluationTemplateQuestionRepository().GetByPerformanceEvaluationTemplate(id);
        }

        public PerformanceEvaluationTemplateQuestion SaveQuestion(PerformanceEvaluationTemplateQuestion item)
        {
            return new PerformanceEvaluationTemplateQuestionRepository().SaveOrUpdate(item);
        }

        public void DeleteQuestion(PerformanceEvaluationTemplateQuestion item)
        {
            new PerformanceEvaluationTemplateQuestionRepository().Delete(item);
        }

        #endregion

        #region Evalutaion Slider Value

        public PerformanceEvaluationSliderValue SaveSliderValue(PerformanceEvaluationSliderValue item)
        {
            return new PerformanceEvaluationSliderValueRepository().SaveOrUpdate(item);
        }

        public void DeleteQuestion(PerformanceEvaluationSliderValue item)
        {
            new PerformanceEvaluationSliderValueRepository().Delete(item);
        }

        #endregion
    }
}