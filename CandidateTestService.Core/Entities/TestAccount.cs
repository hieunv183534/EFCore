using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CandidateTestService.Core.Entities
{
    public class TestAccount : BaseEntity
    {
        public Guid TestId { get; set; }

        public Guid AccountId { get; set; }

        [ForeignKey("TestId")]
        public Test Test { get; set; }

        [ForeignKey("AccountId")]
        public Account Account { get; set; }
    }
}
