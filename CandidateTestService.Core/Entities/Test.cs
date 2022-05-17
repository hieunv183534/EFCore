using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CandidateTestService.Core.Entities
{
    public class Test : BaseEntity
    {
        [Index(IsUnique = true)]
        [StringLength(30)]
        public string TestCode { get; set; }

        [StringLength(200)]
        public string TestName { get; set; }

        public ICollection<Section> Sections { get; set; }

        public ICollection<TestAccount> TestAccounts { get; set; }
    }
}
