using CandidateTestService.Core.Entities;
using CandidateTestService.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CandidateTestService.Repository.Implement
{
    public class TestResultRepository : BaseRepository<TestResult>, ITestResultRepository
    {
        public TestResultRepository(DatabaseContext databaseContext): base(databaseContext)
        {
        }

        public List<TestResult> GetTestResultsOfCandidate(Guid candidateId)
        {
            var query = from ts in _databaseContext.TestResults where ts.AccountId.Equals(candidateId) select ts;
            return query.ToList();
        }

        public List<TestResult> GetTestResultsOfTest(Guid testId)
        {
            var query =  from ts in _databaseContext.TestResults where ts.TestAnswerJSON.Contains(testId.ToString()) select ts;
            return query.ToList();
        }

        public int SubmitTest(TestResult testResult)
        {
            throw new NotImplementedException();
        }
    }
}
