using Mail;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using WeatherApi.Services;
using WeatherCore;
using WeatherData.Models.DTOs.Requests;
using WeatherData.Models.DTOs.Responses;

namespace WeatherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthManagementController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthManagementController(
            IUserRepository userRepository,
            IEmailService emailService,
            UserManager<ApplicationUser> userManager
            )
        {
            _userRepository = userRepository;
            _emailService = emailService;
            _userManager = userManager;

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
                   // //first method
                   // //add Email verification..add Token to verify
                   // var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                   // var email_body = "Please confirm your email address <a href = \"URL\>Click here</a>";


                   // var callback_url = Request.Scheme + "://" + Request.Host + Url.Action("ConfirmEmail", "Authentication",
                   //new { email = user.Email, token = token });

                   // var body = email_body.Replace("URL",
                   //    callback_url);

                   // //Send Mail
                   // var result = SendEmail(body, user.Email);

                   // if (result)
                   //     return Ok("Please verify your email, through the verification email we have just sent.");

                   // return Ok("Please request an email verification link");

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

        //Verification 
        //[HttpGet]
        //[Route("Verification")]
        //public async Task<IActionResult> Verification(string email)
        //{
          
        //    if (email != null)
        //    {
        //        var existingUser = await _userManager.FindByEmailAsync(email);
                
        //        if (existingUser != null)
        //        {
        //           throw new ArgumentException("user credential is invalid");
        //        }

        //        //Second Method
        //        var token = await _userManager.GenerateEmailConfirmationTokenAsync(email);
        //        var confirmationLink = Url.Action(nameof(ConfirmEmail), "AuthManagement",
        //          new { token, email = newUser.Email }, Request.Scheme);
        //        var message = new Message(new[] { user.Email! }, "Comfirmation email link", confirmationLink!);
        //        _emailService.SendEmail(message);

        //        return StatusCodes(StatusCode.200Ok,
        //            new Response { status = "success", Message = "Email sent successfully" });


        //    }
        //}


        //Confirm Email
        [HttpGet]
        [Route("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            if (token == null || email == null)
            {
                return BadRequest(new RegistrationResponse()
                {
                    Errors = new List<string>()
                    {
                        "Invalid email confirmation Url"

                    }
                });
            }

            var user = await _userManager.FindByEmailAsync(email);

                if(user == null)
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<string>()
                        {
                            "Invalid emali parameter"
                        }
                    });
                }

                var result = await _userManager.ConfirmEmailAsync(user, token);

                var status = result.Succeeded ? "Thank you for confirming your Mail"
                    : "Your email is not confirmed, please tru again later";

                return Ok(status);

        }
        

        /// <summary>
        /// Test Email 
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        //public IActionResult TestMail()
        //{
        //    var message =
        //        new Message(new string[]
        //        { "quinn5@ethereal.email" }, "Test", "<h1>Testing....</h1>");
        
        //    _emailService.SendMail(message);

        //    return Ok();

        //}

        [HttpPost]
        public IActionResult SendEmail(Message request)
        {
            _emailService.SendMail(request);
            return Ok();
        }

    }
}
