using Microsoft.EntityFrameworkCore;
using RegistrationAPI.Repository.Data;
using RegistrationAPI.Domain.Users;
using RegistrationAPI.Interfaces.Repositories.Users;

namespace RegistrationAPI.Repository.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext context;

        public UserRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<User> AddAsync(User user)
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateAsync(User user)
        {
            context.Users.Update(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await context.Users.FindAsync(id);
            if (user == null) return false;
            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<User> MigrateUserAsync(User user)
        {
            user.IsMigrated = true;
            context.Users.Update(user);
            await context.SaveChangesAsync();
            return user;
        }
    }
}