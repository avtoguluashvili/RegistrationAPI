using Microsoft.AspNetCore.Mvc;

namespace RegistrationAPI.Dto.User;

public class UserFilterDto
{
    [FromQuery(Name = "firstName")] public string? FirstName { get; set; }

    [FromQuery(Name = "lastName")] public string? LastName { get; set; }

    [FromQuery(Name = "email")] public string? Email { get; set; }
    public string? Status { get; set; }
}