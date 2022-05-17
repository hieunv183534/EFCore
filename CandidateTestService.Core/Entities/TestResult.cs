using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CandidateTestService.Core.Entities
{
    public class TestResult : BaseEntity
    {
        [ForeignKey("AccountId")]
        public Account Account { get; set; }

        [ForeignKey("TestId")]
        public Test Test { get; set; }

        [NotMapped]
        public List<QuestionAnswer> ListAnswer { get; set; }

        public string Answers { get; set; }
    }

    public class QuestionAnswer
    {
        public Guid QuestionId { get; set; }

        public int AnswerOption { get; set; }

        public string AnswerText { get; set; }
    }
}
