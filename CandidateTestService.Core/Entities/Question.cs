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
        private string jsonQuestion;
        private List<QuestionItem> listQuestion;

        [Required]
        public QuestionTypeEnum Type { get; set; }

        [StringLength(300)]
        public string ContentText { get; set; }

        [Column(TypeName = "TEXT")]
        public string ContentJSON {
            get { return this.jsonQuestion; }
            set
            {
                this.jsonQuestion = value;
                if (this.listQuestion == null)
                    this.listQuestion = Newtonsoft.Json.JsonConvert.DeserializeObject<List<QuestionItem>>(value);
            }
        }

        [Column(TypeName = "TEXT")]
        public string AnswerText { get; set; }

        public float EssayScore { get; set; }

        [NotMapped]
        public List<QuestionItem> ContentListObject {
            get { return this.listQuestion; }
            set { this.listQuestion = value; }
        }

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

