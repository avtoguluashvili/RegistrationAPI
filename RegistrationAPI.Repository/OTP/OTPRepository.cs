using Microsoft.EntityFrameworkCore;
using RegistrationAPI.Domain.OTP;
using RegistrationAPI.Interfaces.Repositories.OTP;
using RegistrationAPI.Repository.Data;

namespace RegistrationAPI.Repository.OTP
{
    public class OTPRepository : IOTPRepository
    {
        private readonly AppDbContext _context;

        public OTPRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveOtpAsync(Otp otp)
        {
            try
            {
                _context.OTPs.Add(otp);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Otp?> GetOtpAsync(string contactInfo)
        {
            return await _context.OTPs
                .Where(o => o.ContactInfo == contactInfo)
                .OrderByDescending(o => o.CreatedAt)
                .FirstOrDefaultAsync();
        }


        public async Task<bool> DeleteOtpAsync(string contactInfo)
        {
            var otp = await GetOtpAsync(contactInfo);
            if (otp == null) return false;

            _context.OTPs.Remove(otp);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}