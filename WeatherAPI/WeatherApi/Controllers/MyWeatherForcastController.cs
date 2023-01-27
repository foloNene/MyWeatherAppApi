using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeatherApi.Services;
using WeatherData.Models;
using WeatherData.Models.OpenWeatherAp;
using Serilog;

namespace WeatherApi.Controllers
{

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "AppUser")] // only registered user can access the contoller.
    [Route("api/[controller]")]
    [ApiController]
  
    public class MyWeatherForcastController : ControllerBase
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;
        private readonly ILogger<MyWeatherForcastController> _logger;
        private readonly IScopeInformation _scopeInfo;

        public MyWeatherForcastController(
            IWeatherForecastRepository weatherForecastRepository,
            ILogger<MyWeatherForcastController> logger,
            IScopeInformation scopeInfo
            )
        {
            _weatherForecastRepository = weatherForecastRepository;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _scopeInfo = scopeInfo;
        }

        ////[Authorize(Policy = "DepartmentPolicy")] // only user with Policy claim department can access the method.
        [HttpGet]
        public async Task<ActionResult> City(string city)
        {
            try
            {
                //Logging
                var userEmail = User.Claims.FirstOrDefault(a => a.Type == "Email")?.Value;
                var userId = User.Claims.FirstOrDefault(a => a.Type == "Sub")?.Value;

                object[] Infos = { User.Claims, userEmail };
                object[] Info = { User.Claims, userId };

                //Additional Info like machine name.
                using (_logger.BeginScope(_scopeInfo.HostScopeInfo))
                {
                    _logger.LogInformation(message: "{userEmail} gets weather forcast {claims}",
                     args: Infos);
                    _logger.LogInformation(message: "{userId} is inside get weather forcast{claims}",
                        args: Info);
                }

                WeatherResponse weatherResponse = await _weatherForecastRepository.GetForecast(city);
                if (weatherResponse == null)
                {
                    _logger.LogInformation($"The City {city} wasn't found");
                    return BadRequest("Enter Valid City");
                }

                return Ok(weatherResponse);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occured. Please try again");
            }
           
        }

    }
}
