using CandidateTestService.Core.Entities;
using CandidateTestService.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CandidateTestService.Repository.Implement
{
    public class TestRepository : BaseRepository<Test>, ITestRepository
    {
        public TestRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public List<CandidateOfTest> GetCandidatesOfTest(Guid testId)
        {
            var query = from ta in _databaseContext.TestAccounts where ta.TestId.Equals(testId)
                        select ta.Account.Id;
            List<Guid> listGuid = query.ToList();
            List<Account> listCandidate = _databaseContext.Accounts.Where(a=> a.Role == "candidate").ToList();
            var listCandidateOfTest =  new List<CandidateOfTest>();
            foreach(var candidate in listCandidate)
            {
                if (listGuid.Contains(candidate.Id))
                {
                    listCandidateOfTest.Add(new CandidateOfTest() { Username = candidate.UserName, CandidateId = candidate.Id, IsOfTest = true });
                }
                else
                {
                    listCandidateOfTest.Add(new CandidateOfTest() { Username = candidate.UserName, CandidateId = candidate.Id, IsOfTest = false });
                }
            }
            return listCandidateOfTest;
        }

        public Test GetTest(Guid id, bool isHidenAnswer)
        {
            Test test = (from t in _entities where t.Id.Equals(id) select t).FirstOrDefault();
            LoadMoreTestInfo(test, isHidenAnswer);
            return test;
        }

        public object GetTests(int index, int count, string searchTerms, bool isHidenAnswer)
        {
            var query = from test in _databaseContext.Tests 
                        where test.TestName.Contains(searchTerms) || test.TestCode.Contains(searchTerms)
                        select test;
            List<Test> allTest = query.ToList();
            List<Test> data = allTest.Skip(index).Take(count).ToList();
            return new
            {
                total = allTest.Count,
                data = data
            };
        }

        public List<Test> GetTestsAssignToMe(Guid candidateId)
        {
            var query = from t in _databaseContext.Tests join ta in _databaseContext.TestAccounts
                        on t.Id equals ta.TestId where ta.AccountId.Equals(candidateId) select t;
            List<Test> testsOfMe = query.ToList();
            return testsOfMe;
        }

        private void LoadMoreTestInfo(Test test, bool isHidenAnswer)
        {
            var e = _databaseContext.Entry(test);
            e.Collection(t => t.Sections).Load();
            foreach (Section section in test.Sections)
            {
                var e1 = _databaseContext.Entry(section);
                e1.Collection(e1 => e1.QuestionSections).Load();
                foreach (var questionSection in section.QuestionSections)
                {
                    var e2 = _databaseContext.Entry(questionSection);
                    e2.Reference(qs => qs.Question).Load();

                    if (isHidenAnswer)
                    {
                        questionSection.Question.ContentJSON = null;
                        questionSection.Question.ContentListObject.ForEach(questionItem =>
                        {
                            questionItem.Value = false;
                        });
                    }
                }
            }
        }


    }
}
