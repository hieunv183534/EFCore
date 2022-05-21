using CandidateTestService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTestService.Repository.Interfaces
{
    public interface IAccountRepository : IBaseRepository<Account>
    {
        Account GetAccountByUsername (string username);

        object GetAccounts(int index, int count, string searchTerms, string role);
    }
}
