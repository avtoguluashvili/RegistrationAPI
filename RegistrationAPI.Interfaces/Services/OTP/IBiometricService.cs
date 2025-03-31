using RegistrationAPI.Dto.OTP;
using RegistrationAPI.Dto.User;

namespace RegistrationAPI.Interfaces.Services.OTP;

public interface IBiometricService
{
    Task<bool> EnableBiometricAsync(EnableBiometricDto biometricDto);
}