using Microsoft.AspNetCore.Mvc;
using RegistrationAPI.Dto.OTP;
using RegistrationAPI.Dto.User;
using RegistrationAPI.Interfaces.Services.OTP;
using RegistrationAPI.Interfaces.Services.User;
using RegistrationAPI.Shared;

namespace RegistrationAPI.Endpoints;

public static class BiometricManagementEndpoints
{
    public static void MapEndpoints(WebApplication app)
    {
        app.MapPost(EndpointConfig.EnableBiometricUrl,
            async ([FromBody] EnableBiometricDto biometricDto, [FromServices] IBiometricService biometricService) =>
            {
                var result = await biometricService.EnableBiometricAsync(biometricDto);
                return result
                    ? Results.Ok(new { Message = biometricDto.IsEnabled ? EndpointConfig.BiometricEnableSuccessMessage : EndpointConfig.BiometricDisableSuccessMessage })
                    : Results.BadRequest(new { Message = biometricDto.IsEnabled ? EndpointConfig.BiometricEnableFailureMessage : EndpointConfig.BiometricDisableFailureMessage });
            }).WithName(EndpointConfig.EnableBiometricName);
    }
}