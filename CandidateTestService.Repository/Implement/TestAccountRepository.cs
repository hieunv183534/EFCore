using CandidateTestService.Core.Entities;
using CandidateTestService.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CandidateTestService.Repository.Implement
{
    public class TestAccountRepository : BaseRepository<TestAccount>, ITestAccountRepository
    {
        public TestAccountRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public int UpdateTestAccount(UpdateTestAccountModel updateTestAccountModel)
        {
            var query = from ta in _databaseContext.TestAccounts where ta.TestId.Equals(updateTestAccountModel.TestId) select ta;
            List<TestAccount> testAccountDowns = query.ToList()
                .Where(ta => updateTestAccountModel.ListAccountDown.Contains(ta.AccountId)).ToList();
            _databaseContext.TestAccounts.RemoveRange(testAccountDowns);
            List<TestAccount> testAccountUps = new List<TestAccount>();
            foreach (Guid accountId in updateTestAccountModel.ListAccountUp)
            {
                testAccountUps.Add(new TestAccount() { AccountId = accountId, TestId = updateTestAccountModel.TestId });
            }
            _databaseContext.TestAccounts.AddRange(testAccountUps);
            int rows = _databaseContext.SaveChanges();
            return rows;
        }
    }
}
