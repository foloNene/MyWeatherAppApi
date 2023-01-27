using WeatherData.Configuration;
using WeatherData.Models.DTOs.Requests;
using WeatherData.Models.DTOs.Responses;

namespace WeatherApi.Services
{
    public interface IUserRepository
    {
        Task<RegistrationResponse> LoginAsync(UserLoginRequest user);
        Task<AuthResult> RefreshTokenAsync(TokenRequest tokenRequest);
        Task<RegistrationResponse> RegisterUserAsync(UserRegistrationDto user);
    }
}
