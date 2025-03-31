using RegistrationAPI.Dto.OTP;
using RegistrationAPI.Dto.User;

namespace RegistrationAPI.Interfaces.Services.OTP;

public interface IPinService
{
    Task<bool> SetupPinAsync(SetupPinDto pinDto);
    Task<bool> VerifyPinAsync(VerifyPinDto pinDto);
}