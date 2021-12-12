using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using LawApp.Common.Models.Dto.AuthModels;
using LawApp.Common.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace LawApp.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginViewModel model)
        {
            var emailCorrect = await _userService.CheckEmailCorrect(model.Email);
            if (!emailCorrect)
            {
                return StatusCode(422, "Incorrect email");
            }

            var userExist = await _userService.CheckUserByEmailAsync(model.Email);
            if (!userExist)
            {
                return Forbid();
            }

            var passCorrect = await _userService.CheckPasswordByEmail(model.Email, model.Password);
            if (!passCorrect)
            {
                return StatusCode(401, "Wrong password");
            }

            await AuthenticateAsync(model.Email);

            return Accepted();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var emailCorrect = await _userService.CheckEmailCorrect(model.Email);
            if (!emailCorrect)
            {
                return StatusCode(422, "Incorrect email");
            }

            var userExist = await _userService.CheckUserByEmailAsync(model.Email);
            if (!userExist)
            {
                if (model.Password.Equals(model.ConfirmPassword))
                {
                    await _userService.CreateUserAsync(model);

                    await AuthenticateAsync(model.Email);
                }
                else
                {
                    ModelState.AddModelError("", "Password mismatch");
                }
            }
            else
            {
                //такой пользователь уже есть и redirect к логину
            }
            return Accepted();
        }

        [HttpGet("logout")]
        public async Task Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        private async Task AuthenticateAsync(string userName)
        {
            var claims = new List<Claim>
            {
                new (ClaimsIdentity.DefaultNameClaimType, userName)
            };

            var id = new ClaimsIdentity(claims, "ApplicationCookie", 
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

    }
}
