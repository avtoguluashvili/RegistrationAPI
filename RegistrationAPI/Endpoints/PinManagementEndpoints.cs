using Microsoft.AspNetCore.Mvc;
using RegistrationAPI.Dto.OTP;
using RegistrationAPI.Dto.User;
using RegistrationAPI.Interfaces.Services.OTP;
using RegistrationAPI.Interfaces.Services.User;
using RegistrationAPI.Shared;

namespace RegistrationAPI.Endpoints;

public static class PinManagementEndpoints
{
    public static void MapEndpoints(WebApplication app)
    {
        // Setup PIN
        app.MapPost(EndpointConfig.SetupPinUrl,
            async ([FromBody] SetupPinDto pinDto, [FromServices] IPinService pinService) =>
            {
                var result = await pinService.SetupPinAsync(pinDto);
                return result ? Results.Ok(new { Message = EndpointConfig.SetupPinSuccessMessage })
                    : Results.BadRequest(new { Message = EndpointConfig.InvalidPinMessage });
            }).WithName(EndpointConfig.SetupPinName);

        // Verify PIN
        app.MapPost(EndpointConfig.VerifyPinUrl,
            async ([FromBody] VerifyPinDto pinDto, [FromServices] IPinService pinService) =>
            {
                var result = await pinService.VerifyPinAsync(pinDto);
                return result ? Results.Ok(new { Message = EndpointConfig.VerifyPinSuccessMessage })
                    : Results.BadRequest(new { Message = EndpointConfig.InvalidPinMessage });
            }).WithName(EndpointConfig.VerifyPinName);
    }
}