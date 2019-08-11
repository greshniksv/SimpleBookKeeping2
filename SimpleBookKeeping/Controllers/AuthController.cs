using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Database.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SimpleBookKeeping.Common.DTOs;
using SimpleBookKeeping.Common.Requests.Users;
using SimpleBookKeeping.Database.Models;
using SimpleBookKeeping.Models;
using SimpleBookKeeping.Settings;

namespace SimpleBookKeeping.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        private AppSettings appSettings;

        public AuthController(IMapper mapper, IMediator mediator, IOptions<AppSettings> appSettings)
        {
            this.mapper = mapper;
            this.mediator = mediator;
            this.appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        [Route("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]AuthModel userDto)
        {
            var user = await mediator.Send(new GetAuthenticatedUser(userDto.Login, userDto.Password));

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            return Ok(new
            {
                Id = user.UserId,
                Login = user.Login,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]UserDto userDto)
        {
            // map dto to entity
            var user = mapper.Map<User>(userDto);

            try
            {
                // save 
                //_userService.Create(user, userDto.Password);
                return Ok();
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("hello")]
        public async Task<IActionResult> Hello()
        {
            var user = await mediator.Send(new GetUser(HttpContext.User.Identity.Name));

            return Ok("Hello");
        }
    }
}