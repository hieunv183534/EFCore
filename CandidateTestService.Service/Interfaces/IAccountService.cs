using CandidateTestService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTestService.Service.Interfaces
{
    public interface IAccountService : IBaseService<Account>
    {
        ServiceResult GetAccountByUsername (string username);

        ServiceResult GetAccounts(int index, int count, string searchTerms, string role);
    }
}
