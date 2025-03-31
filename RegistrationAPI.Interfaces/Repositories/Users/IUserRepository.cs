using RegistrationAPI.Domain.Users;

namespace RegistrationAPI.Interfaces.Repositories.Users;

public interface IUserRepository
{
    Task<User> AddAsync(User user);
    Task<User?> GetByIdAsync(int id);
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> UpdateAsync(User user);
    Task<bool> DeleteAsync(int id);
    Task<User> MigrateUserAsync(User user);
}
