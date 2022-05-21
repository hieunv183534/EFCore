using CandidateTestService.Core.Entities;
using CandidateTestService.Core.Enums;
using CandidateTestService.Repository.Interfaces;
using CandidateTestService.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTestService.Service.Implement
{
    public class QuestionService : BaseService<Question> , IQuestionService
    {
        protected IQuestionRepository _questionRepository;

        public QuestionService(IBaseRepository<Question> baseRepository, IQuestionRepository questionRepository) : base(baseRepository) 
        {
            _questionRepository = questionRepository;
        }

        public ServiceResult GetQuestions(int index, int count, string searchTerms, QuestionTypeEnum type, QuestionCategoryEnum category)
        {
            try
            {
                var result = _questionRepository.GetQuestions(index, count, String.IsNullOrEmpty(searchTerms) ? String.Empty : searchTerms, type, category);
                List<Question> data = (List<Question>)result.GetType().GetProperty("data").GetValue(result, null);
                if (data.Count > 0)
                {
                    _serviceResult.Response = new ResponseModel(2000, "Ok", result);
                    _serviceResult.StatusCode = 200;
                    return _serviceResult;
                }
                else
                {
                    _serviceResult.Response = new ResponseModel(2004, "Không có bản ghi nào!", result);
                    _serviceResult.StatusCode = 200;
                    return _serviceResult;
                }
            }
            catch (Exception ex)
            {
                _serviceResult.Response = new ResponseModel(9999, "Exception Error", new { msg = ex.Message });
                _serviceResult.StatusCode = 500;
                return _serviceResult;
            }
        }

        public override ServiceResult Add(Question question)
        {
            question.ContentJSON =  Newtonsoft.Json.JsonConvert.SerializeObject(question.ContentListObject);
            return base.Add(question);
        }

        public override ServiceResult Update(Question question, Guid id)
        {
            question.ContentJSON = Newtonsoft.Json.JsonConvert.SerializeObject(question.ContentListObject);
            return base.Update(question, id);
        }
    }
}
