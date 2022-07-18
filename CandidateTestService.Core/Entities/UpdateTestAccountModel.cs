using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTestService.Core.Entities
{
    public class UpdateTestAccountModel
    {
        public List<Guid> ListAccountUp { get; set; }

        public List<Guid> ListAccountDown { get; set; }

        public Guid TestId { get; set; }
    }
}
