using Newtonsoft.Json;
using System.Text.Json;
using WeatherData.Models.OpenWeatherAp;

namespace WeatherApi.Services
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private IConfiguration _configuration;
        private readonly IHttpClientFactory httpClientFactory;
        public WeatherForecastRepository(IConfiguration configuration,
            IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            this.httpClientFactory = httpClientFactory;
        }

        public async Task <WeatherResponse> GetForecast(string city)
        {

            try
            {
                string APP_ID = _configuration["APIWeatherSecret"];
                var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={APP_ID}";


                var httpClient = httpClientFactory.CreateClient();
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<WeatherResponse>(await response.Content.ReadAsStringAsync());
                    //var responsestring = await response.Content.ReadAsStringAsync();
                    //var details = System.Text.Json.JsonSerializer.Deserialize<WeatherResponse>(responsestring,
                    //    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    //return details!;

                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {
                // log the error
                throw;
                
            }


           

        }


    }
}

//

//using (var httpclient = new HttpClient())
//{
//    var response = await httpclient.GetAsync(url);

//    if (response.IsSuccessStatusCode)
//    {
//        var responsestring = await response.Content.ReadAsStringAsync();
//        var details = JsonSerializer.Deserialize<WeatherResponse>(responsestring,
//            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
//        return details!;
//    }
//    else
//    {
//        return null!;
//    }

//}