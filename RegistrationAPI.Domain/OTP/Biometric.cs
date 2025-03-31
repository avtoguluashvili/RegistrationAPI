namespace RegistrationAPI.Domain.OTP
{
    public class Biometric
    {
        public int Id { get; set; } 
        public int UserId { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime EnabledAt { get; set; }
    }
}