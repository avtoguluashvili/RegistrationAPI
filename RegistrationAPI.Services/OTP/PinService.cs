using AutoMapper;
using RegistrationAPI.Domain.OTP;
using RegistrationAPI.Dto.OTP;
using RegistrationAPI.Interfaces.Repositories.OTP;
using RegistrationAPI.Interfaces.Services.OTP;

namespace RegistrationAPI.Services.OTP
{
    public class PinService(IPinRepository pinRepository, IMapper mapper) : IPinService
    {
        public async Task<bool> SetupPinAsync(SetupPinDto pinDto)
        {
            try
            {
                var pin = mapper.Map<Pin>(pinDto);
                pin.CreatedAt = DateTime.UtcNow;

                return await pinRepository.SavePinAsync(pin);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SetupPinAsync: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> VerifyPinAsync(VerifyPinDto pinDto)
        {
            try
            {
                var pin = await pinRepository.GetPinAsync(pinDto.UserId);
                return pin != null && pin.PinCode == pinDto.Pin;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in VerifyPinAsync: {ex.Message}");
                return false;
            }
        }
    }
}