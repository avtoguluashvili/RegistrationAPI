using Microsoft.AspNetCore.Mvc;
using RegistrationAPI.Dto.User;
using RegistrationAPI.Interfaces.Services;

namespace RegistrationAPI.Endpoints
{
    public static class UserMigrationEndpoints
    {
        public static void MapEndpoints(WebApplication app)
        {
            app.MapPost("/api/users/migrate", async ([FromBody] MigrateUserDto migrateUserDto, [FromServices] IUserService userService) =>
            {
                if (migrateUserDto.Id <= 0 || string.IsNullOrWhiteSpace(migrateUserDto.LegacySystemId))
                {
                    return Results.BadRequest(new { Message = "Invalid migration data provided." });
                }

                var migratedUser = await userService.MigrateUserAsync(migrateUserDto);
                return migratedUser is not null
                    ? Results.Ok(migratedUser)
                    : Results.NotFound(new { Message = $"User with id {migrateUserDto.Id} not found." });
            }).WithName("MigrateUser");
        }
    }
}