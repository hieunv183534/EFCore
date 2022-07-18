using CandidateTestService.Core.Entities;
using CandidateTestService.Repository.Interfaces;
using CandidateTestService.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTestService.Service.Implement
{
    public class TestService : BaseService<Test> , ITestService
    {
        ITestRepository _testRepository;
        public TestService(IBaseRepository<Test> baseRepository, ITestRepository testRepository) : base(baseRepository) 
        {
            _testRepository = testRepository;
        }

        public ServiceResult GetCandidatesOfTest(Guid testId)
        {
            try
            {
                var data = _testRepository.GetCandidatesOfTest(testId);
                if (data.Count > 0)
                {
                    _serviceResult.Response = new ResponseModel(2000, "Ok", data);
                    _serviceResult.StatusCode = 200;
                    return _serviceResult;
                }
                else
                {
                    _serviceResult.Response = new ResponseModel(2004, "Không có bản ghi nào!", data);
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

        public ServiceResult GetTest(Guid id, bool isHidenAnswer)
        {
            try
            {
                var test = _testRepository.GetTest(id, isHidenAnswer);
                if (test != null)
                {
                    _serviceResult.Response = new ResponseModel(2000, "OK", test);
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

        public ServiceResult GetTests(int index, int count, string searchTerms, bool isHidenAnswer)
        {
            try
            {
                //var result = _accountRepository.GetAccounts(index, count, String.IsNullOrEmpty(searchTerms) ? String.Empty : searchTerms, role);
                var result = _testRepository.GetTests(index, count, String.IsNullOrEmpty(searchTerms) ? String.Empty : searchTerms, isHidenAnswer);
                List<Test> data = (List<Test>)result.GetType().GetProperty("data").GetValue(result, null);
                if (data.Count > 0)
                {
                    _serviceResult.Response = new ResponseModel(2000, "Ok", result);
                    _serviceResult.StatusCode = 200;
                    return _serviceResult;
                }
                else
                {
                    _serviceResult.Response = new ResponseModel(2004, "Không có bản ghi nào!", result);
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

        public ServiceResult GetTestsAssignToMe(Guid candidateId)
        {
            try
            {
                var testsOfMe = _testRepository.GetTestsAssignToMe(candidateId);
                if (testsOfMe.Count > 0)
                {
                    _serviceResult.Response = new ResponseModel(2000, "Ok", testsOfMe);
                    _serviceResult.StatusCode = 200;
                    return _serviceResult;
                }
                else
                {
                    _serviceResult.Response = new ResponseModel(2004, "Không có bản ghi nào!", testsOfMe);
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
    }
}
