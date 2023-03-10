using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WeatherCore;

namespace WeatherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsSetupController : ControllerBase
    {
        private readonly ApiDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<ClaimsSetupController> _logger;

        public ClaimsSetupController(
            ApiDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<ClaimsSetupController> logger)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        /// <summary>
        /// To get All Claims for a particular User
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetallClaims(string email)
        {
            // Check if the user exist
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null) // User does not exist
            {
                _logger.LogInformation($"The user with the {email} does not exist");
                return BadRequest(new
                {
                    error = "User does not exist"
                });
            }

            var userClaims = await _userManager.GetClaimsAsync(user);
            return Ok(userClaims);
        }

        /// <summary>
        /// Add Claim to a  User
        /// </summary>
        /// <param name="email"></param>
        /// <param name="claimName"></param>
        /// <param name="claimValue"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddClaimsToUser")]
        public async Task<IActionResult> AddClaimsToUser(string email, string claimName, string claimValue)
        {
            // Check if the user exist
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null) // User does not exist
            {
                _logger.LogInformation($"The user with the {email} does not exist");
                return BadRequest(new
                {
                    error = "User does not exist"
                });
            }

            var userClaim = new Claim(claimName, claimValue);

            var result = await _userManager.AddClaimAsync(user, userClaim);

            if (result.Succeeded)
            {
                return Ok(new
                {
                    result = $"User {user.Email} has a claim {claimName} added to them"
                });
            }

            return BadRequest(new
            {
                error = $"Unable to add claim to {claimName} to {user.Email}"
            });
        }


    }
}
