using CandidateTestService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTestService.Service.Interfaces
{
    public interface ITokenAccountService : IBaseService<TokenAccount>
    {
        ServiceResult GetTokenByUsername (string username);

        ServiceResult DeleteTokenByUsername (string username);

        ServiceResult DeleteTokenByToken (string token);
    }
}
