using Microsoft.AspNetCore.Mvc;
using RegistrationAPI.Dto.OTP;
using RegistrationAPI.Interfaces.Services.OTP;
using RegistrationAPI.Shared;

namespace RegistrationAPI.Endpoints
{
    public static class OTPManagementEndpoints
    {
        public static void MapEndpoints(WebApplication app)
        {
            app.MapPost(EndpointConfig.SendOtpUrl,
                async ([FromBody] SendOtpDto otpDto, [FromServices] IOTPService otpService) =>
                {
                    var result = await otpService.SendOtpAsync(otpDto);
                    return result ? Results.Ok(new { Message = EndpointConfig.SendOtpSuccessMessage })
                        : Results.BadRequest(new { Message = EndpointConfig.SendOtpFailureMessage });
                }).WithName(EndpointConfig.SendOtp);

            app.MapPost(EndpointConfig.VerifyOtpUrl,
                async ([FromBody] VerifyOtpDto otpDto, [FromServices] IOTPService otpService) =>
                {
                    try
                    {
                        var result = await otpService.VerifyOtpAsync(otpDto);
                        return result ? Results.Ok(new { Message = EndpointConfig.VerifyOtpSuccessMessage })
                            : Results.BadRequest(new { Message = EndpointConfig.VerifyOtpFailureMessage });
                    }
                    catch (InvalidOperationException ex)
                    {
                        return Results.BadRequest(new { Message = ex.Message });
                    }
                }).WithName(EndpointConfig.VerifyOtp);
        }
    }
}