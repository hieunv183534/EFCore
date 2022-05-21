using CandidateTestService.Core.Entities;
using CandidateTestService.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CandidateTestService.Repository.Implement
{
    public class TokenAccountRepository : BaseRepository<TokenAccount> , ITokenAccountRepository
    {
        public TokenAccountRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public int DeleteTokenByToken(string token)
        {
            var entity = GetTokenByToken(token);
            if (entity != null)
            {
                _entities.Remove(entity);
            }
            int rows = _databaseContext.SaveChanges();
            return rows;
        }

        public int DeleteTokenByUsername(string username)
        {
            var entity = GetTokenByUsername(username);
            if(entity != null)
            {
                _entities.Remove(entity);
            }
            int rows =_databaseContext.SaveChanges();
            return rows;
        }

        public TokenAccount GetTokenByToken(string token)
        {
            return (from tokenAccount in _databaseContext.TokenAccounts where tokenAccount.Token == token select tokenAccount).FirstOrDefault();
        }

        public TokenAccount GetTokenByUsername(string username)
        {
            return (from tokenAccount in _databaseContext.TokenAccounts where tokenAccount.UserName == username select tokenAccount).FirstOrDefault();
        }
    }
}
