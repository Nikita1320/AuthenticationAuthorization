namespace AuthenticationAuthorization.Domain.Core.Models
{
    public class UserClaims
    {
        public Guid Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string HashPassword { get; set; } = string.Empty;
        public User User { get; set; } = new();
    }
}
