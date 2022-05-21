using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTestService.Core.Entities
{
    public class TokenAccount : BaseEntity
    {
        public TokenAccount(string userName, string token)
        {
            UserName = userName;
            Token = token;
        }

        public string Token { get; set; }

        public string UserName { get; set; }
    }
}
