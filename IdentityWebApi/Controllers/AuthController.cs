using Azure.Identity;
using IdentityWebApi.Data;
using IdentityWebApi.Models;
using IdentityWebApi.Models.Authentication.Signup;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

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
                // check for the role
                if (await _roleManager.RoleExistsAsync(role))
                {
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
                        await _userManager.AddToRoleAsync(user, role);
                        // if user is created successfully
                        return StatusCode(StatusCodes.Status201Created, new Response
                        {
                            Status = "Success",
                            Message = "User created successfully",
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
                }
                else
                {
                    return StatusCode(StatusCodes.Status403Forbidden, new Response
                    {
                        Status = "Error",
                        Message = "Role does not exist",
                    });
                }
                #endregion

            }
        }
    }
}
