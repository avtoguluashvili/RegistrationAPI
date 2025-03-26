using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using RegistrationAPI.Dto.User;
using RegistrationAPI.Interfaces.Services;

namespace RegistrationAPI.Endpoints
{
    public static class UserSearchEndpoints
    {
        public static void MapEndpoints(WebApplication app)
        {
            app.MapGet("/api/users/search", async (
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
                return Results.Ok(users);
            }).WithName("SearchUsers");
        }
    }
}