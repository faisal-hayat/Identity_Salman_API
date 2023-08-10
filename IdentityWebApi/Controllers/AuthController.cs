using Azure.Identity;
using IdentityWebApi.Data;
using IdentityWebApi.Models;
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

                return StatusCode(StatusCodes.Status403Forbidden, new Response
                {
                    Status = "Error",
                    Message = "User already exist",
                });
            }else
            {
                #region create user
                // create the new user
                IdentityUser user = new IdentityUser()
                {
                    Email = registerUser.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = registerUser.Username
                };
                var result = await _userManager.CreateAsync(user, registerUser.Password);

                if (result.Succeeded)
                {
                    // if user is created successfully
                    return StatusCode(StatusCodes.Status201Created, new Response
                    {
                        Status = "User created successfully",
                        Message = "Success",
                    });
                }
                else
                {
                    // if user is not created
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response
                    {
                        Status = "Error",
                        Message = "Failed to signup de to server internal error",
                    });
                }
                #endregion

            }
        }
    }
}
