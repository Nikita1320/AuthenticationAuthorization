namespace AuthenticationAuthorization.Services.Interfaces
{
    public interface IJWTProvider
    {
        public string GenerateToken(Dictionary<string, string> claimsDic);
    }
}
