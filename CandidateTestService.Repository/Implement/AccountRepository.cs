using CandidateTestService.Core.Entities;
using CandidateTestService.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CandidateTestService.Repository.Implement
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public Account GetAccountByUsername(string username)
        {
            return (from account in _databaseContext.Accounts where account.UserName == username select account).FirstOrDefault();
        }

        public object GetAccounts(int index, int count, string searchTerms, string role)
        {
            var query = from account in _databaseContext.Accounts
                        where (account.FullName.Contains(searchTerms) || account.UserName.Contains(searchTerms) || account.Phone.Contains(searchTerms)) &&
                        (role == null || account.Role == role) select account;
            List<Account> accounts = query.ToList();    
            return new
            {
                total = accounts.Count,
                data = accounts.Skip(index).Take(count).ToList()
            };
        }
    }
}
