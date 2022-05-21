using CandidateTestService.Core.Entities;
using CandidateTestService.Repository;
using CandidateTestService.Repository.Implement;
using System.Linq;

namespace CandidateTestService.Api.Authentication
{
    public class ValidateTokenClass
    {
        DatabaseContext _databaseContext;

        public ValidateTokenClass(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public bool ValidateToken(string token)
        {
            if (token.StartsWith("Bearer"))
            {
                token = token.Replace("Bearer", "bearer");
            }

            var tokenAccount = (from tokenAcc in _databaseContext.TokenAccounts where tokenAcc.Token == token select tokenAcc).FirstOrDefault();

            if (tokenAccount != null)
            {
                return true;
            }
            return false;
        }
    }
}
