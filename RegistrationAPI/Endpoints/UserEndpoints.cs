using Microsoft.AspNetCore.Mvc;
using RegistrationAPI.Dto.User;
using RegistrationAPI.Interfaces.Services.User;
using RegistrationAPI.Shared;

namespace RegistrationAPI.Endpoints;

public static class UserEndpoints
{
    public static void MapEndpoints(WebApplication app)
    {
        // GET all users
        app.MapGet(EndpointConfig.BaseUserUrl, async ([FromServices] IUserService userService) =>
        {
            var users = await userService.GetAllUsersAsync();
            return Results.Ok(users);
        }).WithName(EndpointConfig.GetAllUsersName);

        // GET user by id
        app.MapGet(EndpointConfig.UserByIdUrl, async (int id, [FromServices] IUserService userService) =>
        {
            var user = await userService.GetUserByIdAsync(id);
            return user is not null
                ? Results.Ok(user)
                : Results.NotFound(new { Message = string.Format(EndpointConfig.UserNotFoundMessage, id) });
        }).WithName(EndpointConfig.GetUserByIdName);

        // POST create user
        app.MapPost(EndpointConfig.BaseUserUrl,
            async ([FromBody] CreateUserDto userDto, [FromServices] IUserService userService) =>
            {
                if (string.IsNullOrWhiteSpace(userDto.FirstName) ||
                    string.IsNullOrWhiteSpace(userDto.LastName) ||
                    string.IsNullOrWhiteSpace(userDto.Email))
                    return Results.BadRequest(new { Message = EndpointConfig.InvalidInputMessage });
                var createdUser = await userService.CreateUserAsync(userDto);
                return Results.Created($"{EndpointConfig.BaseUserUrl}/{createdUser.Id}",
                    new
                    {
                        Message = string.Format(EndpointConfig.UserCreatedMessage, createdUser.Id), User = createdUser
                    });
            }).WithName(EndpointConfig.CreateUserName);

        // PUT update user
        app.MapPut(EndpointConfig.UserByIdUrl,
            async (int id, [FromBody] UpdateUserDto userDto, [FromServices] IUserService userService) =>
            {
                var updatedUser = await userService.UpdateUserAsync(id, userDto);
                return updatedUser is not null
                    ? Results.Ok(updatedUser)
                    : Results.NotFound(new { Message = string.Format(EndpointConfig.UserNotFoundMessage, id) });
            }).WithName(EndpointConfig.UpdateUserName);

        // DELETE user
        app.MapDelete(EndpointConfig.UserByIdUrl, async (int id, [FromServices] IUserService userService) =>
        {
            var result = await userService.DeleteUserAsync(id);
            return !result
                ? Results.NotFound(new { Message = string.Format(EndpointConfig.UserNotFoundMessage, id) })
                : Results.NoContent();
        }).WithName(EndpointConfig.DeleteUserName);
    }
}