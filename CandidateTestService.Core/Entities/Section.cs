using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CandidateTestService.Core.Entities
{
    [Table("Section")]
    public class Section : BaseEntity
    {
        public string SectionName { get; set; }

        public ICollection<QuestionSection> QuestionSections { get; set; }

        [ForeignKey("TestId")]
        public Test Test { get; set; }
    }
}
