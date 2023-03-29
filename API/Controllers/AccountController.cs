using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Core.DTOs;
using API.Core.Service;
using API.Dtos;
using API.Models;
using FlyMateAPI.Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AccountController : ControllerBase
    {
        public readonly UserManager<User> _userManager;
        private readonly TokenService _tokenService;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public AccountController(UserManager<User> userMagager, RoleManager<ApplicationRole> roleManager, TokenService tokenService)
        {
            _tokenService = tokenService;
            _userManager = userMagager;
            _roleManager = roleManager;
        }

        [HttpPost]
        [Route("roles/add")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequest request)
        {
            var appRole = new ApplicationRole { Name = request.Role };
            var createRole = await _roleManager.CreateAsync(appRole);

            return Ok(new { message = "role created successfully" });
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<UserDto>> LoginAsync(LoginDto loginDto)
        {

            var user = await _userManager.FindByNameAsync(loginDto.Username);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                return Unauthorized();
            }

            return new UserDto
            {
                Email = user.Email,
                Token = await _tokenService.GenerateToken(user)
            };
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var user = new User { UserName = registerDto.Username, Email = registerDto.Email, Address = null };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return ValidationProblem();
            }

            await _userManager.AddToRoleAsync(user, "MEMBER");

            return StatusCode(201);
        }

        [Authorize]
        [HttpGet("currentUser")]

        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            return new UserDto
            {
                Email = user.Email,
                Token = await _tokenService.GenerateToken(user)
            };
        }

        [HttpPost]
        [Route("Authenticate")]
        public async Task<UserDto> Authenticate(LoginDto loginDto)
        {
            User user = await _userManager.FindByNameAsync(loginDto.Username);


            if (user == null)
            {
                return null;
            }



            var tokenHandler = new JwtSecurityTokenHandler();
            // var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is a secret key and need to be at least 12 characters"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim("UserRole", "member")
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is a secret key and need to be at least 12 characters")), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            // user.Token = tokenHandler.WriteToken(token);


            return new UserDto            
            {
                
                Email = user.Email,
                Token = tokenHandler.WriteToken(token),
            };
        }

    }
}