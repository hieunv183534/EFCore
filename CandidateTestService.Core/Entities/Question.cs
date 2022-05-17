using CandidateTestService.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CandidateTestService.Core.Entities
{
    [Table("Question")]
    public class Question : BaseEntity
    {
        [Required]
        public QuestionTypeEnum Type { get; set; }

        [StringLength(300)]
        public string ContentText { get; set; }

        [Column(TypeName = "TEXT")]
        public string ContentJSON { get; set; }

        [NotMapped]
        public List<QuestionItem> ContentJson { get; set; }

        [Required]
        public QuestionCategoryEnum Category { get; set; }

        public ICollection<QuestionSection> QuestionSections { get; set; }
    }


    public class QuestionItem
    {
        public string Key { get; set; }

        public bool Value { get; set; }
    }
}

