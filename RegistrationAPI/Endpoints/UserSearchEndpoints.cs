using Microsoft.AspNetCore.Mvc;
using RegistrationAPI.Dto.User;
using RegistrationAPI.Interfaces.Services.User;
using RegistrationAPI.Shared;

namespace RegistrationAPI.Endpoints;

public static class UserSearchEndpoints
{
    public static void MapEndpoints(WebApplication app)
    {
        app.MapGet(EndpointConfig.SearchUserUrl, async (
            [FromQuery] string? firstName,
            [FromQuery] string? lastName,
            [FromQuery] string? email,
            [FromServices] IUserService userService) =>
        {
            var filter = new UserFilterDto
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email
            };

            var users = await userService.SearchUsersAsync(filter);
            return Results.Ok(new { Message = EndpointConfig.UserSearchSuccessMessage, Users = users });
        }).WithName(EndpointConfig.SearchUsersName);
    }
}