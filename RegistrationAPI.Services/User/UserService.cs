using AutoMapper;
using Microsoft.Extensions.Logging;
using RegistrationAPI.Dto.User;
using RegistrationAPI.Interfaces.Repositories.Users;
using RegistrationAPI.Interfaces.Services.User;
using RegistrationAPI.Domain.Users;

namespace RegistrationAPI.Services.User;

public class UserService(IUserRepository userRepository, IMapper mapper, ILogger<UserService> logger)
    : IUserService
{
    public async Task<UserDto> GetUserByIdAsync(int id)
    {
        logger.LogInformation("Fetching user with id {Id}", id);
        var user = await userRepository.GetByIdAsync(id);
        return mapper.Map<UserDto>(user);
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        logger.LogInformation("Fetching all users");
        var users = await userRepository.GetAllAsync();
        logger.LogInformation("Found {Count} users", users?.Count() ?? 0);
        return mapper.Map<IEnumerable<UserDto>>(users);
    }

    public async Task<UserDto> CreateUserAsync(CreateUserDto userDto)
    {
        logger.LogInformation("Creating new user");
        if (string.IsNullOrWhiteSpace(userDto.FirstName) ||
            string.IsNullOrWhiteSpace(userDto.LastName) ||
            string.IsNullOrWhiteSpace(userDto.Email))
        {
            logger.LogWarning("Invalid input for creating user");
            throw new ArgumentException("Invalid input. FirstName, LastName, and Email are required.");
        }

        var user = mapper.Map<Domain.Users.User>(userDto);
        if (string.IsNullOrWhiteSpace(user.Status)) user.Status = "Active";
        var createdUser = await userRepository.AddAsync(user);
        logger.LogInformation("User created with id {Id}", createdUser.Id);
        return mapper.Map<UserDto>(createdUser);
    }

    public async Task<UserDto> UpdateUserAsync(int id, UpdateUserDto userDto)
    {
        logger.LogInformation("Updating user with id {Id}", id);
        var existingUser = await userRepository.GetByIdAsync(id);
        mapper.Map(userDto, existingUser);
        var updatedUser = await userRepository.UpdateAsync(existingUser);
        logger.LogInformation("User with id {Id} updated successfully", id);
        return mapper.Map<UserDto>(updatedUser);
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        logger.LogInformation("Deleting user with id {Id}", id);
        var result = await userRepository.DeleteAsync(id);
        if (!result)
            logger.LogWarning("User with id {Id} not found for deletion", id);
        else
            logger.LogInformation("User with id {Id} deleted successfully", id);
        return result;
    }

    public async Task<UserDto?> MigrateUserAsync(MigrateUserDto migrateUserDto)
    {
        logger.LogInformation("Migrating user with id {Id}", migrateUserDto.Id);
        var user = await userRepository.GetByIdAsync(migrateUserDto.Id);
        user.LegacySystemId = migrateUserDto.LegacySystemId;
        var migratedUser = await userRepository.MigrateUserAsync(user);
        logger.LogInformation("User with id {Id} migrated successfully", migrateUserDto.Id);
        return mapper.Map<UserDto>(migratedUser);
    }

  public async Task<UserDto?> UpdateUserStatusAsync(UpdateUserStatusDto statusDto)
{
    logger.LogInformation("Updating status for user with id {Id}", statusDto.Id);

    var user = await userRepository.GetByIdAsync(statusDto.Id);
    if (user == null)
    {
        logger.LogWarning("User with id {Id} not found for status update", statusDto.Id);
        return null;
    }

    user.Status = statusDto.Status;
    var updatedUser = await userRepository.UpdateAsync(user);

    logger.LogInformation("User with id {Id} status updated to {Status}", statusDto.Id, statusDto.Status);
    return mapper.Map<UserDto>(updatedUser);
}


    public async Task<IEnumerable<UserDto>> BulkCreateUsersAsync(BulkCreateUserDto bulkDto)
    {
        logger.LogInformation("Bulk creating users");
        var createdUsers = new List<UserDto>();
        foreach (var userDto in bulkDto.Users)
        {
            var createdUser = await CreateUserAsync(userDto);
            createdUsers.Add(createdUser);
        }

        logger.LogInformation("Bulk create completed, created {Count} users", createdUsers.Count);
        return createdUsers;
    }

    public async Task<IEnumerable<UserDto>> SearchUsersAsync(UserFilterDto filter)
    {
        logger.LogInformation("Searching users with provided filter");
        var users = await userRepository.GetAllAsync();
        if (!string.IsNullOrWhiteSpace(filter.FirstName))
            users = users.Where(u => u.FirstName.Contains(filter.FirstName, StringComparison.OrdinalIgnoreCase));
        if (!string.IsNullOrWhiteSpace(filter.LastName))
            users = users.Where(u => u.LastName.Contains(filter.LastName, StringComparison.OrdinalIgnoreCase));
        if (!string.IsNullOrWhiteSpace(filter.Email))
            users = users.Where(u => u.Email.Contains(filter.Email, StringComparison.OrdinalIgnoreCase));
        if (!string.IsNullOrWhiteSpace(filter.Status))
            users = users.Where(u => u.Status.Equals(filter.Status, StringComparison.OrdinalIgnoreCase));
        var result = mapper.Map<IEnumerable<UserDto>>(users);
        logger.LogInformation("Search completed, found {Count} users", result?.Count() ?? 0);
        return result;
    }
}