using AuthenticationAuthorization.Services.Interfaces;

namespace AuthenticationAuthorization.Services.Business
{
    public class PasswordHasher: IPasswordHasher
    {
        public string Generate(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password, BCrypt.Net.HashType.SHA256);
        }

        public bool Verify(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword,hashType:BCrypt.Net.HashType.SHA256);
        }
    }
}
