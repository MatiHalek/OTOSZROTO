﻿namespace api.Dto
{
    public class AdvertismentDto
    {
        public string? Title { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? Model { get; set; }
        public int YearOfProduction { get; set; }
        public int NumberOfDoors { get; set; }
        public int NumberOfPlaces { get; set; }
        public string? Color { get; set; }
        public string? VIN { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string? Gearbox { get; set; }
        public string? FuelType { get; set; }
        public string? BodyType { get; set; }
        public string? Condition { get; set; }
        public int Mileage { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}