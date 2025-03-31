using RegistrationAPI.Domain.OTP;
using RegistrationAPI.Interfaces.Repositories.OTP;
using RegistrationAPI.Repository.Data;

namespace RegistrationAPI.Repository.OTP;

public class PinRepository : IPinRepository
{
    private readonly AppDbContext _context;

    public PinRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> SavePinAsync(Pin pin)
    {
        _context.Pins.Add(pin);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<Pin?> GetPinAsync(int userId)
    {
        return await _context.Pins.FindAsync(userId);
    }

    public async Task<bool> DeletePinAsync(int userId)
    {
        var pin = await GetPinAsync(userId);
        if (pin == null) return false;

        _context.Pins.Remove(pin);
        return await _context.SaveChangesAsync() > 0;
    }
}