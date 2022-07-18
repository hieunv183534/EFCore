using CandidateTestService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTestService.Repository.Interfaces
{
    public interface ITestResultRepository : IBaseRepository<TestResult>
    { 
        int SubmitTest(TestResult testResult);

        List<TestResult> GetTestResultsOfCandidate(Guid candidateId);

        List<TestResult> GetTestResultsOfTest(Guid testId);
    }
}
