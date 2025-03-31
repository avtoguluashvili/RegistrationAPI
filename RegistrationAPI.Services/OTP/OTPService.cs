using AutoMapper;
using Microsoft.Extensions.Logging;
using RegistrationAPI.Domain.OTP;
using RegistrationAPI.Dto.OTP;
using RegistrationAPI.Interfaces.Repositories.OTP;
using RegistrationAPI.Interfaces.Services.OTP;
using RegistrationAPI.Shared;

namespace RegistrationAPI.Services.OTP
{
    public class OTPService : IOTPService
    {
        private readonly IMapper _mapper;
        private readonly IOTPRepository _otpRepository;
        private readonly ILogger<OTPService> _logger;
        private const int OtpExpirySeconds = 30;

        public OTPService(IOTPRepository otpRepository, IMapper mapper, ILogger<OTPService> logger)
        {
            _otpRepository = otpRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> SendOtpAsync(SendOtpDto otpDto)
        {
            try
            {
                _logger.LogInformation(string.Format(EndpointConfig.OtpSendingMessage, otpDto.ContactInfo));

                var otpCode = new Random().Next(1000, 9999).ToString();
                var otp = new Otp
                {
                    UserId = otpDto.UserId,
                    OtpCode = otpCode,
                    ContactInfo = otpDto.ContactInfo,
                    CreatedAt = DateTime.UtcNow,
                    ExpiryTime = DateTime.UtcNow.AddSeconds(OtpExpirySeconds)
                };

                bool saved = await _otpRepository.SaveOtpAsync(otp);

                if (!saved)
                {
                    _logger.LogError(string.Format(EndpointConfig.OtpSaveFailureMessage, otpDto.ContactInfo));
                    return false;
                }

                _logger.LogInformation(string.Format(EndpointConfig.OtpGenerationMessage, otpCode, otpDto.ContactInfo, otp.ExpiryTime));
                _logger.LogInformation(string.Format(EndpointConfig.OtpSentMessage, otpCode, otpDto.ContactInfo));
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Format(EndpointConfig.OtpErrorMessage, otpDto.ContactInfo));
                return false;
            }
        }

        public async Task<bool> VerifyOtpAsync(VerifyOtpDto otpDto)
        {
            try
            {
                _logger.LogInformation(string.Format(EndpointConfig.OtpVerificationAttemptMessage, otpDto.ContactInfo));

                var otp = await _otpRepository.GetOtpAsync(otpDto.ContactInfo);
                if (otp == null)
                {
                    _logger.LogWarning(string.Format(EndpointConfig.OtpNotFoundMessage, otpDto.ContactInfo));
                    return false;
                }

                _logger.LogInformation(string.Format(EndpointConfig.OtpCurrentTimeMessage, DateTime.UtcNow));
                _logger.LogInformation(string.Format(EndpointConfig.OtpExpiryTimeMessage, otp.ExpiryTime));

                if (DateTime.UtcNow > otp.ExpiryTime)
                {
                    _logger.LogWarning(string.Format(EndpointConfig.OtpExpiredMessage, otpDto.ContactInfo));
                    await _otpRepository.DeleteOtpAsync(otpDto.ContactInfo);
                    return false;
                }

                if (otp.OtpCode != otpDto.OtpCode)
                {
                    _logger.LogWarning(string.Format(EndpointConfig.OtpVerificationFailureMessage, otpDto.ContactInfo));
                    return false;
                }

                await _otpRepository.DeleteOtpAsync(otpDto.ContactInfo);
                _logger.LogInformation(string.Format(EndpointConfig.OtpVerificationSuccessMessage, otpDto.ContactInfo));
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Format(EndpointConfig.OtpErrorMessage, otpDto.ContactInfo));
                return false;
            }
        }
    }
}
