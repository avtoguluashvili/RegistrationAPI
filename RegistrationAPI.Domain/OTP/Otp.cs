namespace RegistrationAPI.Domain.OTP
{
    public class Otp
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ContactInfo { get; set; } 
        public string OtpCode { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsVerified { get; set; } = false;
        public DateTime ExpiryTime { get; set; }
    }
}