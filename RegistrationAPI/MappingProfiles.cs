using AutoMapper;
using RegistrationAPI.Dto.User;
using User = RegistrationAPI.Models.User;

namespace RegistrationAPI;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<User, CreateUserDto>().ReverseMap()
            .ForMember(dest => dest.Status, opt => opt.Ignore());
        CreateMap<User, UpdateUserDto>().ReverseMap()
            .ForMember(dest => dest.Status, opt => opt.Ignore());
    }
}