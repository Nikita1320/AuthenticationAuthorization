using AuthenticationAuthorization.Domain.Core.Models;
using AuthenticationAuthorization.Domain.Interfaces.RepositoryInterfaces;
using AuthenticationAuthorization.Infrastrucnure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AuthenticationAuthorization.Infrastrucnure.Data.Repositories
{
    public class UserRepository:IUserRepository
    {
        private ApplicationContext context;
        public UserRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task Add(User user)
        {
            await context.AddAsync(user);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            await context.Users
                .Where(c => c.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<List<User>> Get()
        {
            return await context.Users
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<User?> GetById(Guid id)
        {
            return await context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<User?> GetByLogin(string login)
        {
            var user = await context.UserClaims
                .FirstOrDefaultAsync(c => c.Login == login);

            if (user != null)
            {
                return user.User;
            }
            return null;
        }

        public async Task Update(User user)
        {
            var dbUser = await context.Users.FirstOrDefaultAsync(c => c.Id == user.Id);
            if (dbUser != null)
            {
                dbUser.Name = user.Name;
                dbUser.Email = user.Email;
            }
            context.SaveChanges();
        }
    }
}
