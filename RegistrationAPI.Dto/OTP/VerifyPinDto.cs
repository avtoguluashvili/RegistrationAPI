namespace RegistrationAPI.Dto.OTP
{
    public class VerifyPinDto
    {
        public int UserId { get; set; }
        public string Pin { get; set; }
        public string? ContactInfo { get; set; }
    }
}