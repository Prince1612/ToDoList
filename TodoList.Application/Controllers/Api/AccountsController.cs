using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Application.Models;
using TodoList.DataModel.Models.Accounts;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.Authentication;

namespace TodoList.Application.Controllers.Api
{
    [Route("/api/[controller]")]
    public class AccountsController : Controller
    {
        UserManager<CustomUser> _userManager;
        SignInManager<CustomUser> _signInManager;
        public AccountsController(UserManager<CustomUser> userManager, SignInManager<CustomUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult GetData()
        {
            return Ok("HEllo world");
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserViewModel user)
        {
            if (user == null || !ModelState.IsValid)
                return BadRequest();

            CustomUser customUser = new CustomUser { UserName = user.UserName, Email = user.Email };
            IdentityResult result = await _userManager.CreateAsync(customUser, user.Password);

            if (result.Succeeded)
            {
                IdentityResult claimIdentityResult = await _userManager.AddClaimAsync(customUser, new Claim(ClaimTypes.Role, user.Role));
                if (claimIdentityResult.Succeeded)
                    return Created(string.Empty, null);
            }
            return StatusCode(500, result.Errors);
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel userInfo)
        {
            if (userInfo == null || !ModelState.IsValid)
                return BadRequest();

            CustomUser customUser = await _userManager.FindByNameAsync(userInfo.UserName);

            if (customUser == null)
                return StatusCode(403, "Invalid credentials");

            var result = await _signInManager.PasswordSignInAsync(customUser, userInfo.Password, false, false);
            if (result.Succeeded)
            {

                RedirectToRoute("/");
                return Ok();
            }
            else
                return StatusCode(403, "Invalid credentials");
        }

        [HttpPost("login/{url}")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel userInfo, string url)
        {
            if (userInfo == null || !ModelState.IsValid)
                return BadRequest();

            CustomUser customUser = await _userManager.FindByNameAsync(userInfo.UserName);

            if (customUser == null)
                return StatusCode(403, "Invalid credentials");

            var result = await _signInManager.PasswordSignInAsync(customUser, userInfo.Password, false, false);
            if (result.Succeeded)
            {

                return Redirect(url);
            }
            else
                return StatusCode(403, "Invalid credentials");
        }
    }
}
