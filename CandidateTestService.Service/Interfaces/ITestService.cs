using CandidateTestService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTestService.Service.Interfaces
{
    public interface ITestService : IBaseService<Test>
    {
        ServiceResult GetTests(int index, int count, string searchTerms, bool isHidenAnswer);

        ServiceResult GetTest(Guid id, bool isHidenAnswer);
    }
}
