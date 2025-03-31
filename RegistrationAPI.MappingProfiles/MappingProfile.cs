using AutoMapper;
using RegistrationAPI.Domain.OTP;
using RegistrationAPI.Domain.Users;
using RegistrationAPI.Dto.OTP;
using RegistrationAPI.Dto.User;

namespace RegistrationAPI.MappingProfiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<User, CreateUserDto>().ReverseMap();
        CreateMap<User, UpdateUserDto>().ReverseMap();
        CreateMap<EnableBiometricDto, Biometric>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.IsEnabled, opt => opt.MapFrom(src => src.IsEnabled))
            .ForMember(dest => dest.EnabledAt, opt => opt.MapFrom(src => src.EnabledAt));
        CreateMap<SetupPinDto, Pin>()
            .ForMember(dest => dest.PinCode, opt => opt.MapFrom(src => src.Pin))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());

        CreateMap<VerifyPinDto, Pin>()
            .ForMember(dest => dest.PinCode, opt => opt.MapFrom(src => src.Pin))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));
    }
}