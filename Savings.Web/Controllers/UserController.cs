using Microsoft.AspNetCore.Mvc;
using Savings.Model.ViewModel;
using Savings.Service.Interfaces;
using System;
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

        /// <summary>
        /// "Singn Up"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// "Register Hash Password"
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public IActionResult Register(string password)
        {
            var (hash, salt) = UserService.HashPassword(password);
            // Save hash and salt to the database
            return Ok(new { Hash = hash, Salt = salt });
        }

        /// <summary>
        /// "Update User"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("Update user")]
        public async Task<IActionResult> UpdateUser(UpdateUserViewModel model)
        {
            var response = await UserService.UpdateUser(model);
            if (response != null)
            {
                return Ok(response);
            }
            else return BadRequest(response);
        }

        /// <summary>
        /// "Update PhoneNumber"
        /// </summary>
        /// <param name="PhoneNumber"></param>
        /// <returns></returns>
        [HttpPut("Update PhoneNumber")]
        public async Task<IActionResult> UpdatePhoneNumber(string PhoneNumber)
        {
            var response = await UserService.UpdatePhoneNumber(PhoneNumber);
            if (response != null)
            {
                return Ok(response);
            }
            else return BadRequest(response);
        }

        /// <summary>
        /// "Get By Id"
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("Get By Id")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var response = await UserService.GetById(Id);
            if (response != null)
            {
                return Ok(response);
            }
            else return BadRequest(response);
        }

        /// <summary>
        /// "Deactivate User"
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPatch("Deactivate User ")]
        public async Task<IActionResult> DeactivateUser(Guid Id)
        {
            var response = await UserService.DeactivateUser(Id);
            if (response == true)
            {
                return Ok(response);
            }
            else return BadRequest(response);
        }

        /// <summary>
        /// "Activate User"
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPatch("Activate User ")]
        public async Task<IActionResult> ActivateUser(Guid Id)
        {
            var response = await UserService.ActivateUser(Id);
            if (response == true)
            {
                return Ok(response);
            }
            else return BadRequest(response);
        }
    }
}
