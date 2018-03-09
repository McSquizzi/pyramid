using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PyramidStore.BL.Managers;
using PyramidStore.Core.Models;
using PyramidStore.Helpers;
using PyramidStore.ViewModels;

namespace PyramidStore.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        UserManager _manager;
        SignInManager<User> _signInManager;
        public AccountController(UserManager manager, SignInManager<User> signInManager)
        {
            _manager = manager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<object> Register([FromBody] LoginModel login)
        {
            var result = await _manager.CreateAsync(new Core.Models.User { UserName = login.Login }, login.Password);
            if (result.Succeeded)
            {
                return Task.FromResult(Ok("Register was succes"));
            }
            return Task.FromResult(BadRequest("Resiter was fail"));
        }

        [HttpPost]
        [Route("login")]
        public async Task<object> Login([FromBody] LoginModel login)
        {

            if (ModelState.IsValid)
            {
                var user = await _manager.FindByNameAsync(login.Login);

                if (user != null)
                {
                    var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);
                    if (result.Succeeded)
                    {

                        var claims = new[]
                        {
          new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
          new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

                        var key = AuthToken.GetSymmetricSecurityKey();
                        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(AuthToken.ISSUER,
                         AuthToken.AUDIENCE,
                          claims,
                          expires: DateTime.Now.AddMinutes(30),
                          signingCredentials: creds);

                        return Task.FromResult(Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) }));
                    }
                }
            }

            return Task.FromResult(BadRequest());

        }
    }
}