using RegistrationAPI.Domain;
using RegistrationAPI.Domain.OTP;

namespace RegistrationAPI.Interfaces.Repositories.OTP;

public interface IBiometricRepository
{
    Task<bool> SaveBiometricAsync(Biometric biometric);
    Task<Biometric?> GetBiometricAsync(int userId);
    Task<bool> DeleteBiometricAsync(int userId);
}