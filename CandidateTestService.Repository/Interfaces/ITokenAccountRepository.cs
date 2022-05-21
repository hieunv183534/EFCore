using CandidateTestService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTestService.Repository.Interfaces
{
    public interface ITokenAccountRepository : IBaseRepository<TokenAccount>
    {
        TokenAccount GetTokenByUsername(string username);

        TokenAccount GetTokenByToken(string token);

        int DeleteTokenByUsername (string username);

        int DeleteTokenByToken (string token);
    }
}
