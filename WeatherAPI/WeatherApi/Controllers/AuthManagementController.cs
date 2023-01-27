using Microsoft.AspNetCore.Mvc;
using WeatherApi.Services;
using WeatherData.Models.DTOs.Requests;

namespace WeatherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthManagementController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public AuthManagementController(
            IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Onboarding of Users
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto user)
        {
            //Utlilze the model
            if (ModelState.IsValid)
            {
                var result = await _userRepository.RegisterUserAsync(user);
                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            return BadRequest("Some Properties are not valid");
        }

        /// <summary>
        /// Login users
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest user)
        {

            if (ModelState.IsValid)
            {
                var result = await _userRepository.LoginAsync(user);
                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }

            }
            return BadRequest("some properties are not valid");

        }

        /// <summary>
        /// Refresh Token For Authenication
        /// </summary>
        /// <param name="tokenRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenRequest tokenRequest)
        {
            if (ModelState.IsValid)
            {
                var result = await _userRepository.RefreshTokenAsync(tokenRequest);

                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }

            return BadRequest("Invalid details");

        }


    }
}
