using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTestService.Core.Entities
{
    public class CandidateOfTest
    {
        public string Username { get; set; }

        public Guid CandidateId { get; set; }

        public bool IsOfTest { get; set; }
    }
}
