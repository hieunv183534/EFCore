using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CandidateTestService.Core.Entities
{
    public class QuestionSection : BaseEntity
    {
        [ForeignKey("QuestionId")]
        public Question Question { get; set; }

        [ForeignKey("SectionId")]
        public Section Section { get; set; }
    }
}
