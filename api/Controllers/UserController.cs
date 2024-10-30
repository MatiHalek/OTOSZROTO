using api.Dto;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        [HttpGet("{userID}")]
        public IActionResult Get(int userID)
        {
            return Ok(userRepository.Get(userID));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(userRepository.GetAll());
        }

        [HttpDelete("{userID}")]
        public IActionResult Delete(int userID)
        {
            return Ok(userRepository.Remove(userID));
        }

        [HttpPut("{userID}")]
        public IActionResult Delete(UserDto dto,int userID)
        {
            User user = new()
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
            };
            return Ok(userRepository.Update(user,userID));
        }
    }
}
