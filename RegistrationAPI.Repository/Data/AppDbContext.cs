using Microsoft.EntityFrameworkCore;
using RegistrationAPI.Domain.Users;
using RegistrationAPI.Domain.OTP;

namespace RegistrationAPI.Repository.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Pin> Pins { get; set; }
        public DbSet<Otp> OTPs { get; set; }
        public DbSet<Biometric> Biometrics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}