namespace RegistrationAPI.Dto.User;

public class UpdateUserStatusDto
{
    public int Id { get; set; }
    public string Status { get; set; } = null!;
}