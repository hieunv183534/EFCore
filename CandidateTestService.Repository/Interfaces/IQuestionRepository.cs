using CandidateTestService.Core.Entities;
using CandidateTestService.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTestService.Repository.Interfaces
{
    public interface IQuestionRepository : IBaseRepository<Question>
    {
        object GetQuestions(int index, int count, string searchTerms, QuestionTypeEnum type, QuestionCategoryEnum category);
    }
}
