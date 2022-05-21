using CandidateTestService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTestService.Repository.Interfaces
{
    public interface ITestRepository : IBaseRepository<Test>
    { 
        Test GetTest(Guid id, bool isHidenAnswer);

        object GetTests(int index, int count, string searchTerms, bool isHidenAnswer);
    }
}
