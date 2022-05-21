namespace CandidateTestService.Api.Authentication
{
    public interface IJwtAuthenticationManager
    {
        object Authenticate(string username, string password);
    }
}
