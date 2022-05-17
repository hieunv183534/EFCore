using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CandidateTestService.Core.Entities
{
    public class TestAccount : BaseEntity
    {
        [ForeignKey("TestId")]
        public Test Test { get; set; }

        [ForeignKey("AccountId")]
        public Account Account { get; set; }
    }
}
