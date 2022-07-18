using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CandidateTestService.Core.Entities
{
    public class TestResult : BaseEntity
    {
        private Test testAnswer;
        private string testAnswerJson;

        public Guid AccountId { get; set; }

        [NotMapped]
        public Test TestAnswer
        {
            get { return this.testAnswer; }
            set { this.testAnswer = value; }
        }

        [Column(TypeName = "TEXT")]
        public string TestAnswerJSON
        {
            get { return this.testAnswerJson; }
            set
            {
                this.testAnswerJson = value;
                if (this.testAnswer == null)
                    this.testAnswer = Newtonsoft.Json.JsonConvert.DeserializeObject<Test>(value);
            }
        }

        public int SoCauDung { get; set; }

        public int SoCauSai { get; set; }

        public int SoCauTuLuan { get; set; }

        public bool Marked { get; set; }
    }
}
