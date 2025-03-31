using RegistrationAPI.Dto.OTP;

namespace RegistrationAPI.Interfaces.Services.OTP;

public interface IOTPService
{
    Task<bool> SendOtpAsync(SendOtpDto otpDto);
    Task<bool> VerifyOtpAsync(VerifyOtpDto otpDto);
}