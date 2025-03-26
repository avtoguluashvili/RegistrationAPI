﻿using RegistrationAPI.Domain;

namespace RegistrationAPI.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> AddAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<bool> DeleteAsync(int id);
        Task<User> MigrateUserAsync(User user);
    }
}