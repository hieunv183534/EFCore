using CandidateTestService.Core.Entities;
using CandidateTestService.Repository.Interfaces;
using CandidateTestService.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTestService.Service.Implement
{
    public class TestAccountService : BaseService<TestAccount>, ITestAccountService
    {
        protected ITestAccountRepository _testAccountRepository;

        public TestAccountService(IBaseRepository<TestAccount> baseRepository, ITestAccountRepository testAccountRepository) : base(baseRepository)
        {
            _testAccountRepository = testAccountRepository;
        }

        public ServiceResult UpdateTestAccount(UpdateTestAccountModel updateTestAccountModel)
        {
            try
            {
                int rows = _testAccountRepository.UpdateTestAccount(updateTestAccountModel);
                _serviceResult.Response = new ResponseModel(2001, "OK", rows);
                _serviceResult.StatusCode = 201;
                return _serviceResult;
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
