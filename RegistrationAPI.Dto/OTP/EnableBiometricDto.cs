namespace RegistrationAPI.Dto.OTP
{
    public class EnableBiometricDto
    {
        public int UserId { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime EnabledAt { get; set; }
    }
}