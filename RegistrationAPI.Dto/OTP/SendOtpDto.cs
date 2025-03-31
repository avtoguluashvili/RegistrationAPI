using System;

namespace RegistrationAPI.Dto.OTP
{
    public class SendOtpDto
    {
        public int UserId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime RequestTime { get; set; }
        public string Purpose { get; set; }
        public string ContactInfo { get; set; }

        public SendOtpDto()
        {
            RequestTime = DateTime.UtcNow;
        }
    }
}