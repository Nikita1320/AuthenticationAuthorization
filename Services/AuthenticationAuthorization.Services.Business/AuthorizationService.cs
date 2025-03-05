using AuthenticationAuthorization.Domain.Core.Models;
using AuthenticationAuthorization.Domain.Interfaces.RepositoryInterfaces;
using AuthenticationAuthorization.Services.Interfaces;

namespace AuthenticationAuthorization.Services.Business
{
    public class AuthorizationService
    {
        private IUserRepository userRepository;
        private IPasswordHasher passwordHasher;
        private IJWTProvider jWTProvider;
        public AuthorizationService(IUserRepository userRepository, 
            IPasswordHasher passwordHasher,
            IJWTProvider jWTProvider)
        {
            this.userRepository = userRepository;
            this.passwordHasher = passwordHasher;
            this.jWTProvider = jWTProvider;
        }

        public async Task<string> Login(string login, string password)
        {
            //проверить логин пароль

            //создать токен

            var user = await userRepository.GetByLogin(login);
            if (user == null)
            {
                throw new Exception();
            }
            if (user.UserClaims == null)
            {
                throw new Exception();
            }
            string token = string.Empty;
            if (user != null)
            {
                var result = passwordHasher.Verify(password, user.UserClaims.HashPassword);
                if (result == false)
                {
                    throw new Exception();
                }
                token = jWTProvider.GenerateToken(
                    new Dictionary<string, string>()
                    {
                        {"userId", user.Id.ToString()}
                    });
            }
            return token;
        }
        public async Task<bool> Register(string name, string login, string password, string email)
        {
            var hash = passwordHasher.Generate(password);

            var userClaims = new UserClaims()
            {
                Id = Guid.NewGuid(),
                Login = login,
                HashPassword = hash
            };

            var user = new User()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                UserClaimsId = userClaims.Id,
                UserClaims = userClaims
            };

            userClaims.User = user;

            try
            {
                await userRepository.Add(user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
