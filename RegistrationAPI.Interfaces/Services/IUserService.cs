using RegistrationAPI.Dto.User;

namespace RegistrationAPI.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserDto> GetUserByIdAsync(int id);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> CreateUserAsync(CreateUserDto userDto);
        Task<UserDto> UpdateUserAsync(int id, UpdateUserDto userDto);
        Task<bool> DeleteUserAsync(int id);
        Task<UserDto?> MigrateUserAsync(MigrateUserDto migrateUserDto);
        Task<UserDto?> UpdateUserStatusAsync(UpdateUserStatusDto statusDto);
        Task<IEnumerable<UserDto>> BulkCreateUsersAsync(BulkCreateUserDto bulkDto);
        Task<IEnumerable<UserDto>> SearchUsersAsync(UserFilterDto filter);

    }
}