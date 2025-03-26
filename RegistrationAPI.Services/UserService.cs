using AutoMapper;
using RegistrationAPI.Domain;
using RegistrationAPI.Dto;
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
            var createdUser = await userRepository.AddAsync(user);
            return mapper.Map<UserDto>(createdUser);
        }

        public async Task<UserDto> UpdateUserAsync(int id, UpdateUserDto userDto)
        {
            var existingUser = await userRepository.GetByIdAsync(id);
            if (existingUser == null)
            {
                return null;
            }
            mapper.Map(userDto, existingUser);
            var updatedUser = await userRepository.UpdateAsync(existingUser);
            return mapper.Map<UserDto>(updatedUser);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            return await userRepository.DeleteAsync(id);
        }
    }
}
