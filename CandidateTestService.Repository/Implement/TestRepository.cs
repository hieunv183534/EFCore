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


        public Test GetTest(Guid id, bool isHidenAnswer)
        {
            Test test = (from t in _entities where t.Id.Equals(id) select t).FirstOrDefault();
            LoadMoreTestInfo(test, isHidenAnswer);
            return test;
        }

        public object GetTests(int index, int count, string searchTerms, bool isHidenAnswer)
        {
            var query = from test in _databaseContext.Tests 
                        where test.TestName == searchTerms || test.TestCode == searchTerms select test;
            List<Test> allTest = query.ToList();
            List<Test> data = allTest.Skip(index).Take(count).ToList();
            data.ForEach(test => {
                LoadMoreTestInfo(test, isHidenAnswer);
            });
            return new
            {
                total = allTest.Count,
                data = data
            };
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
                            questionSection.Question.ListOptions.Add(questionItem.Key);
                        });
                        questionSection.Question.ContentListObject = null;
                    }
                }
            }
        }
    }
}
