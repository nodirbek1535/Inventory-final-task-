//======================================
//Nodirbek Nasrullayev Inventory Project
//======================================

using System;
using System.Threading.Tasks;
using Inventory_final_task_.Models.Identity;
using Inventory_final_task_.Services.Orchestrations.Auth;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace Inventory_final_task_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : RESTFulController
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService) =>
            this.authService = authService;

        [HttpPost("register")]
        public async ValueTask<ActionResult<UserResponse>> PostRegisterAsync(RegisterRequest request)
        {
            try
            {
                UserResponse userResponse = await this.authService.RegisterAsync(request);

                return Created(userResponse);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("confirm-email")]
        public async ValueTask<ActionResult<bool>> GetConfirmEmailAsync(string token)
        {
            try
            {
                bool isConfirmed = await this.authService.ConfirmEmailAsync(token);

                if (isConfirmed)
                    return Ok("Email muvaffaqiyatli tasdiqlandi!");

                return BadRequest("Token yaroqsiz yoki muddati o'tgan!");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost("login")]
        public async ValueTask<ActionResult<AuthResponse>> PostLoginAsync(LoginRequest request)
        {
            try
            {
                AuthResponse authResponse = await this.authService.LoginAsync(request);

                return Ok(authResponse);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
