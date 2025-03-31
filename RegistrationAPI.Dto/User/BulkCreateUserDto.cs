namespace RegistrationAPI.Dto.User;

public class BulkCreateUserDto
{
    public IEnumerable<CreateUserDto> Users { get; set; } = new List<CreateUserDto>();
}