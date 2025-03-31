using Microsoft.AspNetCore.Mvc;
using RegistrationAPI.Dto.User;
using RegistrationAPI.Interfaces.Services.User;
using RegistrationAPI.Shared;

namespace RegistrationAPI.Endpoints;

public static class UserBulkEndpoints
{
    public static void MapEndpoints(WebApplication app)
    {
        app.MapPost(EndpointConfig.BulkUserUrl,
            async ([FromBody] BulkCreateUserDto bulkDto, [FromServices] IUserService userService) =>
            {
                var result = await userService.BulkCreateUsersAsync(bulkDto);
                return Results.Created(EndpointConfig.BulkUserUrl,
                    new { Message = EndpointConfig.BulkCreateSuccessMessage, Users = result });
            }).WithName(EndpointConfig.BulkCreateUsersName);
    }
}