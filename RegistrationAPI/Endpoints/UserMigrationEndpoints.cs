using Microsoft.AspNetCore.Mvc;
using RegistrationAPI.Dto.User;
using RegistrationAPI.Interfaces.Services.User;
using RegistrationAPI.Shared;

namespace RegistrationAPI.Endpoints;

public static class UserMigrationEndpoints
{
    public static void MapEndpoints(WebApplication app)
    {
        app.MapPost(EndpointConfig.MigrateUserUrl,
            async ([FromBody] MigrateUserDto migrateUserDto, [FromServices] IUserService userService) =>
            {
                var migratedUser = await userService.MigrateUserAsync(migrateUserDto);
                return migratedUser is not null
                    ? Results.Ok(migratedUser)
                    : Results.NotFound(new
                        { Message = string.Format(EndpointConfig.UserMigrationNotFoundMessage, migrateUserDto.Id) });
            }).WithName(EndpointConfig.MigrateUserName);
    }
}