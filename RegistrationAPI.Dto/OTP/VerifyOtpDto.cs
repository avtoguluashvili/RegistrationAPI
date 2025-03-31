namespace RegistrationAPI.Dto.OTP
{
    public class VerifyOtpDto
    {
        public string PhoneNumber { get; set; }
        public string OtpCode { get; set; }
        public string ContactInfo { get; set; }
    }
}