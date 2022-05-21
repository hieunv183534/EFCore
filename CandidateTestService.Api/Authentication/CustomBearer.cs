using CandidateTestService.Repository.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Threading.Tasks;

namespace CandidateTestService.Api.Authentication
{
    public class CustomBearer : JwtBearerEvents
    {
        ITokenAccountRepository _tokenAccountRepository;
        public CustomBearer(ITokenAccountRepository tokenAccountRepository)
        {
            _tokenAccountRepository =   tokenAccountRepository;
        }

        public override Task TokenValidated(TokenValidatedContext context)
        {
            string token = context.Request.Headers["Authorization"];

            var mytokenAccount = _tokenAccountRepository.GetTokenByToken(token);
            if (mytokenAccount == null)
            {
                context.Fail("Fail okok");
            }
            return Task.CompletedTask;
        }
    }
}
