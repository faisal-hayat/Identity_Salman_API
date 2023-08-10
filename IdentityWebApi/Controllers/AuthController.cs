using IdentityWebApi.Data;
using IdentityWebApi.Models.Authentication.Signup;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private IConfiguration _configuration;


        public AuthController(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, IConfiguration configuration,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _configuration = configuration;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("Authentication")]
        public async Task<IActionResult> Register([FromBody]RegisterUser registerUser, string role)
        {
            var userExist = await _userManager.FindByEmailAsync(registerUser.Email);
            if (registerUser == null) {

                throw new ArgumentNullException();
            }
            return Ok();
        }
    }
}
