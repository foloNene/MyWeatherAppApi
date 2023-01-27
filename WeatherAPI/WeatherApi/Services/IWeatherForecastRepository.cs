using WeatherData.Models.OpenWeatherAp;

namespace WeatherApi.Services
{
    public interface IWeatherForecastRepository
    {
        Task<WeatherResponse> GetForecast(string city);
        
    }
}
