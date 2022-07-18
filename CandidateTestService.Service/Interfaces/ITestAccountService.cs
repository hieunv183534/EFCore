using CandidateTestService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTestService.Service.Interfaces
{
    public interface ITestAccountService : IBaseService<TestAccount>
    {
        ServiceResult UpdateTestAccount(UpdateTestAccountModel updateTestAccountModel);
    }
}
