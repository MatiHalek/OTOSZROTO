using api.Dto;
using api.Interfaces;
using api.Models;
using api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertismentController : ControllerBase
    {
        private readonly IAdvertismentRepository advertismentRepository;

        public AdvertismentController(IAdvertismentRepository advertismentRepository)
        {
            this.advertismentRepository = advertismentRepository;
        }

        [HttpPost]
        public IActionResult Create(AdvertismentDto dto)
        {
            Advertisement advertisement = new Advertisement()
            {
                Title = dto.Title,
                Price = dto.Price,
                Description = dto.Description,
                Model = dto.Model,
                YearOfProduction = dto.YearOfProduction,
                NumberOfDoors = dto.NumberOfDoors,
                NumberOfPlaces = dto.NumberOfPlaces,
                IsPriceNegotiable = dto.IsPriceNegotiable,
                Category = dto.Category,
                Color = dto.Color,
                VIN = dto.VIN,
                Power = dto.Power,
                Displacement = dto.Displacement,
                Gearbox = dto.Gearbox,
                FuelType = dto.FuelType,
                BodyType = dto.BodyType,
                Condition = dto.Condition,
                Mileage = dto.Mileage,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                UserID = dto.UserID,
            };
            return Created("success", advertismentRepository.Create(advertisement));
        }

        [HttpPut("{advertismentID}")]
        public IActionResult Update(AdvertismentDto dto,int advertismentID)
        {
            Advertisement advertisement = new Advertisement()
            {
                Title = dto.Title,
                Price = dto.Price,
                Description = dto.Description,
                Model = dto.Model,
                YearOfProduction = dto.YearOfProduction,
                NumberOfDoors = dto.NumberOfDoors,
                NumberOfPlaces = dto.NumberOfPlaces,
                IsPriceNegotiable = dto.IsPriceNegotiable,
                Category = dto.Category,
                Color = dto.Color,
                VIN = dto.VIN,
                Power = dto.Power,
                Displacement = dto.Displacement,
                Gearbox = dto.Gearbox,
                FuelType = dto.FuelType,
                BodyType = dto.BodyType,
                Condition = dto.Condition,
                Mileage = dto.Mileage,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                UserID = dto.UserID,
            };
            return Ok(advertismentRepository.Update(advertisement, advertismentID));
        }

        [HttpDelete("{advertismentID}")]
        public IActionResult Delete(int advertismentID)
        {
            return Ok(advertismentRepository.Remove(advertismentID));
        }

        [HttpGet("{advertismentID}")]
        public IActionResult Get(int advertismentID)
        {
            return Ok(advertismentRepository.Get(advertismentID));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(advertismentRepository.GetAll());
        }
    }
}
