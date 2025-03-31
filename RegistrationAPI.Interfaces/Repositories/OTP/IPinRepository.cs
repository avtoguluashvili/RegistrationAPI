using RegistrationAPI.Domain;
using RegistrationAPI.Domain.OTP;

namespace RegistrationAPI.Interfaces.Repositories.OTP;

public interface IPinRepository
{
    Task<bool> SavePinAsync(Pin pin);
    Task<Pin?> GetPinAsync(int userId);
    Task<bool> DeletePinAsync(int userId);
}