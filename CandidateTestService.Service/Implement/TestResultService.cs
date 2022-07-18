using CandidateTestService.Core.Entities;
using CandidateTestService.Repository.Interfaces;
using CandidateTestService.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CandidateTestService.Service.Implement
{
    public class TestResultService : BaseService<TestResult>, ITestResultService
    {
        protected ITestResultRepository _testResultRepository;
        protected ITestRepository _testRepository;

        public TestResultService(ITestResultRepository testResultRepository, ITestRepository testRepository) : base(testResultRepository)
        {
            _testResultRepository = testResultRepository;
            _testRepository = testRepository;
        }

        public ServiceResult GetTestResultsOfCandidate(Guid candidateId)
        {
            try
            {
                var testResults = _testResultRepository.GetTestResultsOfCandidate(candidateId);
                if (testResults.Count > 0)
                {
                    _serviceResult.Response = new ResponseModel(2000, "OK", testResults);
                    _serviceResult.StatusCode = 200;
                    return _serviceResult;
                }
                else
                {
                    _serviceResult.Response = new ResponseModel(2004, "No data or end of list data");
                    _serviceResult.StatusCode = 200;
                    return _serviceResult;
                }
            }
            catch (Exception ex)
            {
                _serviceResult.Response = new ResponseModel(9999, "Exception Error", new { msg = ex.Message });
                _serviceResult.StatusCode = 500;
                return _serviceResult;
            }
        }

        public ServiceResult GetTestResultsOfTest(Guid testId)
        {
            try
            {
                var testResults = _testResultRepository.GetTestResultsOfTest(testId);
                if (testResults.Count > 0)
                {
                    _serviceResult.Response = new ResponseModel(2000, "OK", testResults);
                    _serviceResult.StatusCode = 200;
                    return _serviceResult;
                }
                else
                {
                    _serviceResult.Response = new ResponseModel(2004, "No data or end of list data");
                    _serviceResult.StatusCode = 200;
                    return _serviceResult;
                }
            }
            catch (Exception ex)
            {
                _serviceResult.Response = new ResponseModel(9999, "Exception Error", new { msg = ex.Message });
                _serviceResult.StatusCode = 500;
                return _serviceResult;
            }
        }

        public ServiceResult SubmitTest(TestResult testResult)
        {
            try
            {
                
                Test _test = _testRepository.GetTest(testResult.TestAnswer.Id, false);

                List<Section> sections = testResult.TestAnswer.Sections.ToList();
                List<Section> _sections = _test.Sections.ToList();

                int soCauDung = 0;
                int soCauSai = 0;
                int soCauTuLuan = 0;

                for (int i = 0; i < sections.Count; i++)
                {
                    Section section = sections[i];
                    Section _section = _sections[i];
                    List<QuestionSection> questionSections = section.QuestionSections.ToList();
                    List<QuestionSection> _questionSections = _section.QuestionSections.ToList();
                    for (int j = 0; j < questionSections.Count; j++)
                    {
                        if (questionSections[j].Question.Type == Core.Enums.QuestionTypeEnum.Essay)
                        {
                            soCauTuLuan++;
                            continue;
                        }
                        else
                        {
                            List<QuestionItem> traloi = questionSections[j].Question.ContentListObject;
                            List<QuestionItem> dapan = _questionSections[j].Question.ContentListObject;
                            string _traloi = Newtonsoft.Json.JsonConvert.SerializeObject(traloi);
                            string _dapan = Newtonsoft.Json.JsonConvert.SerializeObject(dapan);
                            if (_traloi.Equals(_dapan))
                            {
                                soCauDung++;
                            }
                            else
                            {
                                soCauSai++;
                            }
                        }

                        questionSections[j].Question.ContentJSON =
                            Newtonsoft.Json.JsonConvert.SerializeObject(questionSections[j].Question.ContentListObject);
                        questionSections[j].Question.ContentListObject = new List<QuestionItem>();
                    }
                }

                testResult.SoCauDung = soCauDung;
                testResult.SoCauSai = soCauSai;
                testResult.SoCauTuLuan = soCauTuLuan;
                testResult.TestAnswerJSON = Newtonsoft.Json.JsonConvert.SerializeObject(testResult.TestAnswer);

                int rows = _testResultRepository.Add(testResult);
                if (rows > 0)
                {
                    _serviceResult.Response = new ResponseModel(2001, "OK", testResult);
                    _serviceResult.StatusCode = 201;
                    return _serviceResult;
                }
                else
                {
                    _serviceResult.Response = new ResponseModel(5005, "Không thành công", rows);
                    _serviceResult.StatusCode = 201;
                    return _serviceResult;
                }
            }
            catch (Exception ex)
            {
                _serviceResult.Response = new ResponseModel(9999, "Exception Error", new { msg = ex.Message });
                _serviceResult.StatusCode = 500;
                return _serviceResult;
            }
        }
    }
}
