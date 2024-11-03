using api.Dto;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IUserTokenRepository userTokenRepository;
        private readonly IJwtService jwtService;
        private readonly IEmailService emailService;
        public AuthController(IUserRepository userRepository, IUserTokenRepository userTokenRepository, IJwtService jwtService, IEmailService emailService)
        {
            this.userTokenRepository = userTokenRepository;
            this.userRepository = userRepository;
            this.emailService = emailService;
            this.jwtService = jwtService;
        }
        [HttpPost("register")]
        public IActionResult Create(UserDto dto)
        {
            User user = new()
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Access = "user",
            };
            return Created("success", userRepository.Create(user));
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = userRepository.GetByEmail(dto.Email!);
            if (user == null) return BadRequest(new { message = "Invalid Credentials" });

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
            {
                return BadRequest(new { message = "Invalid Credentials" });
            }

            var jwt = jwtService.Generate(user.UserID);

            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            });

            return Ok(new
            {
                message = "success"
            });
        }

        [HttpGet("user")]
        public IActionResult GetUserByJwt()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = jwtService.Verify(jwt!);

                int userId = int.Parse(token.Issuer);

                var user = userRepository.Get(userId);

                return Ok(user);
            }
            catch (Exception)
            {
                return Ok(null);
            }
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");

            return Ok(new
            {
                message = "success"
            });
        }

        [HttpPost("reset/{email}")]
        public IActionResult Reset(string email)
        {
            User user = userRepository.GetByEmail(email);
            if(user == null) return NotFound();
            string token = Utils.GenerateRandomString(25);

            emailService.SendEmailAsync(email, "Password restart"
                , $"<a href='http://localhost:3000/restart?token={token}'>Zrestatruj hasło klikając w ten link!</a>");
            
            UserToken userToken = new UserToken()
            {
                Token = token,
                UserID = user.UserID,
            };

            userTokenRepository.Create(userToken);

            return Ok("success");
        }

        [HttpPut("reset/{token}-{password}")]
        public IActionResult Reset(string token, string password)
        {
            userTokenRepository.Update(token,password);

            return Ok("success");
        }
    }
}
