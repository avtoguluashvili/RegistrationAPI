using Microsoft.AspNetCore.Mvc;
using RegistrationAPI.Dto.User;
using RegistrationAPI.Interfaces.Services;

namespace RegistrationAPI.Endpoints
{
    public static class UserBulkEndpoints
    {
        public static void MapEndpoints(WebApplication app)
        {
            app.MapPost("/api/users/bulk", async ([FromBody] BulkCreateUserDto bulkDto, [FromServices] IUserService userService) =>
            {
                if (bulkDto == null || !bulkDto.Users.Any())
                    return Results.BadRequest(new { Message = "No users provided for bulk import." });

                var result = await userService.BulkCreateUsersAsync(bulkDto);
                return Results.Created("/api/users/bulk", result);
            }).WithName("User_BulkCreateUsers");
        }
    }
}