using CandidateTestService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTestService.Repository.Interfaces
{
    public interface ITestAccountRepository : IBaseRepository<TestAccount>
    {
        int UpdateTestAccount(UpdateTestAccountModel updateTestAccountModel);
    }
}
