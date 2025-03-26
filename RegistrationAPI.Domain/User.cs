namespace RegistrationAPI.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsMigrated { get; set; }
        public string? LegacySystemId { get; set; }
        public string Status { get; set; }
    }
}