﻿namespace AuthenticationAuthorization.Domain.Core.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Guid UserClaimsId { get; set; }
        public UserClaims? UserClaims { get; set; }
    }
}
