using RegistrationAPI.Domain;
using RegistrationAPI.Domain.OTP;
using static System.Net.WebRequestMethods;

namespace RegistrationAPI.Interfaces.Repositories.OTP;

public interface IOTPRepository
{
    Task<bool> SaveOtpAsync(Otp otp);
    Task<Otp?> GetOtpAsync(string phoneNumberOrEmail);
    Task<bool> DeleteOtpAsync(string phoneNumberOrEmail);
}