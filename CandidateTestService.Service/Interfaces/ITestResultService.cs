using CandidateTestService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTestService.Service.Interfaces
{
    public interface ITestResultService : IBaseService<TestResult>
    {
        ServiceResult SubmitTest(TestResult testResult);

        ServiceResult GetTestResultsOfCandidate(Guid candidateId);

        ServiceResult GetTestResultsOfTest(Guid testId);
    }
}
