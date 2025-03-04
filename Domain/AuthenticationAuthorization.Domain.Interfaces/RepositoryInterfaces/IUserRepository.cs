using AuthenticationAuthorization.Domain.Core.Models;

namespace AuthenticationAuthorization.Domain.Interfaces.RepositoryInterfaces
{
    public interface IUserRepository
    {
        public Task<List<User>> Get();
        public Task<User> GetById(Guid id);
        public Task<User> GetByLogin(string login);
        public Task Add(User user);
        public Task Update(User user);
        public Task Delete(Guid id);
    }
}
