namespace AuthenticationAuthorization.API.Contracts
{
    public record RegisterUserRequest(string name, string login, string email, string password);
}
