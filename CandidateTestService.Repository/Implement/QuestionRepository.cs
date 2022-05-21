using CandidateTestService.Core.Entities;
using CandidateTestService.Core.Enums;
using CandidateTestService.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CandidateTestService.Repository.Implement
{
    public class QuestionRepository : BaseRepository<Question>,  IQuestionRepository
    {
        public QuestionRepository(DatabaseContext databaseConext) : base(databaseConext)
        {
        }

        public object GetQuestions(int index, int count, string searchTerms, QuestionTypeEnum type, QuestionCategoryEnum category)
        {
            var query = from question in _databaseContext.Questions where
                        question.ContentText.Contains(searchTerms) && (type == 0 || type == question.Type)
                        && (category == 0 || category == question.Category) select question;
            var questions = query.ToList();
            return new
            {
                total = questions.Count,
                data = questions.Skip(index).Take(count).ToList()
            };
        }
    }
}
