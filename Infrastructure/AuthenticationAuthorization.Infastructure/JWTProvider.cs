using AuthenticationAuthorization.Domain.Core.Models;
using AuthenticationAuthorization.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticationAuthorization.Infastructure
{
    internal class JWTProvider: IJWTProvider
    {
        private readonly JwtOptions options;
        private JWTProvider(IOptions<JwtOptions> options)
        {
            this.options = options.Value;
        }
        public string GenerateToken(Dictionary<string, string> claimsDic)
        {
            List<Claim> claims = claimsDic.Select(p => new Claim(p.Key, p.Value)).ToList();

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SecretKey)),
                SecurityAlgorithms.Sha256);

            var token = new JwtSecurityToken(
                claims: d,
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddHours(options.ExpiteHours)
                );

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue;
        }
    }
}
