using AutoMapper;
using RegistrationAPI.Domain;
using RegistrationAPI.Dto.User;
using RegistrationAPI.Interfaces.Repositories;
using RegistrationAPI.Interfaces.Services;

namespace RegistrationAPI.Services
{
    public class UserService(IUserRepository userRepository, IMapper mapper) : IUserService
    {
        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await userRepository.GetByIdAsync(id);
            return user == null ? null : mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await userRepository.GetAllAsync();
            return mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> CreateUserAsync(CreateUserDto userDto)
        {
            var user = mapper.Map<User>(userDto);
            if (string.IsNullOrWhiteSpace(user.Status))
            {
                user.Status = "Active";
            }
            var createdUser = await userRepository.AddAsync(user);
            return mapper.Map<UserDto>(createdUser);
        }


        public async Task<UserDto> UpdateUserAsync(int id, UpdateUserDto userDto)
        {
            var existingUser = await userRepository.GetByIdAsync(id);
            mapper.Map(userDto, existingUser);
            var updatedUser = await userRepository.UpdateAsync(existingUser);
            return mapper.Map<UserDto>(updatedUser);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            return await userRepository.DeleteAsync(id);
        }

        public async Task<UserDto?> MigrateUserAsync(MigrateUserDto migrateUserDto)
        {
            var user = await userRepository.GetByIdAsync(migrateUserDto.Id);

            user.LegacySystemId = migrateUserDto.LegacySystemId;
            var migratedUser = await userRepository.MigrateUserAsync(user);
            return mapper.Map<UserDto>(migratedUser);
        }
        public async Task<UserDto?> UpdateUserStatusAsync(UpdateUserStatusDto statusDto)
        {
            var user = await userRepository.GetByIdAsync(statusDto.Id);
            if (user == null)
                return null;

            user.Status = statusDto.Status;
            var updatedUser = await userRepository.UpdateAsync(user);
            return mapper.Map<UserDto>(updatedUser);
        }

        public async Task<IEnumerable<UserDto>> BulkCreateUsersAsync(BulkCreateUserDto bulkDto)
        {
            var createdUsers = new List<UserDto>();

            foreach (var userDto in bulkDto.Users)
            {
                var user = mapper.Map<User>(userDto);
                if (string.IsNullOrWhiteSpace(user.Status))
                {
                    user.Status = "Active";
                }
                var createdUser = await userRepository.AddAsync(user);
                createdUsers.Add(mapper.Map<UserDto>(createdUser));
            }

            return createdUsers;
        }
        public async Task<IEnumerable<UserDto>> SearchUsersAsync(UserFilterDto filter)
        {
            var users = await userRepository.GetAllAsync();
            if (!string.IsNullOrWhiteSpace(filter.FirstName))
                users = users.Where(u => u.FirstName.Contains(filter.FirstName, StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrWhiteSpace(filter.LastName))
                users = users.Where(u => u.LastName.Contains(filter.LastName, StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrWhiteSpace(filter.Email))
                users = users.Where(u => u.Email.Contains(filter.Email, StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrWhiteSpace(filter.Status))
                users = users.Where(u => u.Status.Equals(filter.Status, StringComparison.OrdinalIgnoreCase));

            return mapper.Map<IEnumerable<UserDto>>(users);
        }

    }
}
