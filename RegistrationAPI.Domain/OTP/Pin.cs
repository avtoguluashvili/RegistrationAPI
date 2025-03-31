namespace RegistrationAPI.Domain.OTP
{
    public class Pin
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string PinCode { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}