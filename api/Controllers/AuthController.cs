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
        private readonly IJwtService jwtService;
        private readonly IEmailService emailService;
        public AuthController(IUserRepository userRepository, IJwtService jwtService, IEmailService emailService)
        {
            this.userRepository = userRepository;
            this.jwtService = jwtService;
            this.emailService = emailService;
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

        [HttpPost("reset/{userID}")]
        public IActionResult Reset(int userID)
        {
            User user = userRepository.Get(userID);
            if(user == null) return NotFound();
            string token = Utils.GenerateRandomString(25);
            emailService.SendEmailAsync("kacperpiaskowy937@gmail.com", "Password restart"
                , $"<a href='http://localhost:3000/restart?token={token}'>http://localhost:3000/restart?token={token}</a>");
            return Ok("success");
        }
    }
}
