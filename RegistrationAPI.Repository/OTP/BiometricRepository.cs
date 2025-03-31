using RegistrationAPI.Domain.OTP;
using RegistrationAPI.Interfaces.Repositories.OTP;
using RegistrationAPI.Repository.Data;

namespace RegistrationAPI.Repository.OTP;

public class BiometricRepository : IBiometricRepository
{
    private readonly AppDbContext _context;

    public BiometricRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> SaveBiometricAsync(Biometric biometric)
    {
        _context.Biometrics.Add(biometric);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<Biometric?> GetBiometricAsync(int userId)
    {
        return await _context.Biometrics.FindAsync(userId);
    }

    public async Task<bool> DeleteBiometricAsync(int userId)
    {
        var biometric = await GetBiometricAsync(userId);
        if (biometric == null) return false;

        _context.Biometrics.Remove(biometric);
        return await _context.SaveChangesAsync() > 0;
    }
}