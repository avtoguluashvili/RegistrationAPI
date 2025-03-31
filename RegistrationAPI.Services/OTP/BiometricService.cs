using AutoMapper;
using Microsoft.Extensions.Logging;
using RegistrationAPI.Domain.OTP;
using RegistrationAPI.Dto.OTP;
using RegistrationAPI.Interfaces.Repositories.OTP;
using RegistrationAPI.Interfaces.Services.OTP;

namespace RegistrationAPI.Services.OTP
{
    public class BiometricService(
        IBiometricRepository biometricRepository,
        IMapper mapper,
        ILogger<BiometricService> logger)
        : IBiometricService
    {
        public async Task<bool> EnableBiometricAsync(EnableBiometricDto biometricDto)
        {
            try
            {
                var biometric = mapper.Map<Biometric>(biometricDto);

                string action = biometricDto.IsEnabled ? "enabling" : "disabling";
                logger.LogInformation("Attempting to {Action} biometric for user with ID {UserId}", action, biometricDto.UserId);

                var success = await biometricRepository.SaveBiometricAsync(biometric);

                if (success)
                {
                    logger.LogInformation("Biometric successfully {Action} for user with ID {UserId}", action, biometricDto.UserId);
                    return true;
                }

                logger.LogWarning("Failed to {Action} biometric for user with ID {UserId}", action, biometricDto.UserId);
                return false;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while {Action} biometric for user with ID {UserId}", biometricDto.IsEnabled ? "enabling" : "disabling", biometricDto.UserId);
                return false;
            }
        }
    }
}