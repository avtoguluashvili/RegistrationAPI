using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using RegistrationAPI.Dto.User;
using RegistrationAPI.Interfaces.Services;

namespace RegistrationAPI.Endpoints.UserManagement
{
    public static class UserStatusEndpoints
    {
        public static void MapEndpoints(WebApplication app)
        {
            app.MapPatch("/api/users/status", async ([FromBody] UpdateUserStatusDto statusDto, [FromServices] IUserService userService) =>
            {
                if (statusDto == null)
                    return Results.BadRequest(new { Message = "Invalid status update data." });

                var updatedUser = await userService.UpdateUserStatusAsync(statusDto);
                return updatedUser is not null
                    ? Results.Ok(updatedUser)
                    : Results.NotFound(new { Message = $"User with id {statusDto.Id} not found." });
            }).WithName("UpdateUserStatus");
        }
    }
}