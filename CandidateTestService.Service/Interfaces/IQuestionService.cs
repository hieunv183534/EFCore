using CandidateTestService.Core.Entities;
using CandidateTestService.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTestService.Service.Interfaces
{
    public interface IQuestionService : IBaseService<Question>
    {
        ServiceResult GetQuestions(int index, int count, string searchTerms, QuestionTypeEnum type, QuestionCategoryEnum category);
    }
}
