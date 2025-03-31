using Microsoft.AspNetCore.Mvc;
using RegistrationAPI.Dto.User;
using RegistrationAPI.Interfaces.Services.User;
using RegistrationAPI.Shared;

namespace RegistrationAPI.Endpoints;

public static class UserStatusEndpoints
{
    public static void MapEndpoints(WebApplication app)
    {
        app.MapPatch(EndpointConfig.UserStatusUrl,
            async ([FromBody] UpdateUserStatusDto statusDto, [FromServices] IUserService userService) =>
            {
                var updatedUser = await userService.UpdateUserStatusAsync(statusDto);
                return updatedUser is not null
                    ? Results.Ok(new { Message = EndpointConfig.UserStatusUpdateMessage, User = updatedUser })
                    : Results.NotFound(new
                        { Message = string.Format(EndpointConfig.UserStatusNotFoundMessage, statusDto.Id) });
            }).WithName(EndpointConfig.UpdateUserStatusName);
    }
}