using Microsoft.AspNetCore.Mvc;
using RegistrationAPI.Dto.User;
using RegistrationAPI.Interfaces.Services;

namespace RegistrationAPI.Endpoints
{
    public static class UserEndpoints
    {
        public static void MapEndpoints(WebApplication app)
        {
            // GET all users
            app.MapGet("/api/users", async ([FromServices] IUserService userService) =>
            {
                var users = await userService.GetAllUsersAsync();
                return Results.Ok(users);
            }).WithName("User_GetAllUsers");

            // GET user by id
            app.MapGet("/api/users/{id:int}", async (int id, [FromServices] IUserService userService) =>
            {
                var user = await userService.GetUserByIdAsync(id);
                return user is not null
                    ? Results.Ok(user)
                    : Results.NotFound(new { Message = $"User with id {id} does not exist." });
            }).WithName("User_GetUserById");

            // POST create user
            app.MapPost("/api/users", async ([FromBody] CreateUserDto userDto, [FromServices] IUserService userService) =>
            {
                if (string.IsNullOrWhiteSpace(userDto.FirstName) ||
                    string.IsNullOrWhiteSpace(userDto.LastName) ||
                    string.IsNullOrWhiteSpace(userDto.Email))
                {
                    return Results.BadRequest(new { Message = "Invalid input. FirstName, LastName, and Email are required." });
                }
                var createdUser = await userService.CreateUserAsync(userDto);
                return Results.Created($"/api/users/{createdUser.Id}", createdUser);
            }).WithName("User_CreateUser");

            // PUT update user
            app.MapPut("/api/users/{id:int}", async (int id, [FromBody] UpdateUserDto userDto, [FromServices] IUserService userService) =>
            {
                if (userDto == null)
                {
                    return Results.BadRequest(new { Message = "Invalid input." });
                }
                var updatedUser = await userService.UpdateUserAsync(id, userDto);
                return updatedUser is not null
                    ? Results.Ok(updatedUser)
                    : Results.NotFound(new { Message = $"User with id {id} does not exist." });
            }).WithName("User_UpdateUser");

            // DELETE user
            app.MapDelete("/api/users/{id:int}", async (int id, [FromServices] IUserService userService) =>
            {
                var result = await userService.DeleteUserAsync(id);
                return !result
                    ? Results.NotFound(new { Message = $"User with id {id} does not exist." })
                    : Results.NoContent();
            }).WithName("User_DeleteUser");
        }
    }
}