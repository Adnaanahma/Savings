using Microsoft.AspNetCore.Mvc;
using Savings.Model.ViewModel;
using Savings.Service.Interfaces;
using System.Threading.Tasks;

namespace Savings.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService UserService;

        public UserController(IUserService userService)
        {
            UserService = userService;
        }

        [HttpPost("SignUp user")]
        public async Task<IActionResult> SignUpUser(SignUpModel model)
        {
            var response = await UserService.SignUpUser(model);
            if (response != null)
            {
                return Ok(response);
            }
            else return BadRequest(response);
        }

        [HttpPost("register")]
        public IActionResult Register(string password)
        {
            var (hash, salt) = UserService.HashPassword(password);
            // Save hash and salt to the database
            return Ok(new { Hash = hash, Salt = salt });
        }

        [HttpPost("login")]
        public IActionResult Login(string password, string storedSalt, string storedHash)
        {
            var response = UserService.VerifyPassword(password, storedSalt, storedHash);

            if (response == true)
            {
                return Ok(response);
            }
            else return BadRequest(response);

        }


    }
}
