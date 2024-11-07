using api.Data;
using api.Interfaces;
using api.Models;

namespace api.Repositories
{
    public class AdvertismentRepository : IAdvertismentRepository
    {
        private readonly AppDbContext context;
        public AdvertismentRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Advertisement Create(Advertisement advertisement)
        {
            try
            {
                context.Advertisements.Add(advertisement);
                context.SaveChanges();
                return advertisement;
            }
            catch (Exception ex)
            {
                throw new Exception($"Creating new advertisment failed: {ex.Message}");
            }
        }

        public Advertisement Get(int advertisementID)
        {
            Advertisement advertisement = context.Advertisements.Find(advertisementID)!;
            if (advertisement == null)
            {
                throw new Exception($"Failed to fetch advertisment with advertisementID = {advertisementID}");
            }
            return advertisement;
        }

        public List<Advertisement> GetAll()
        {
            List<Advertisement> advertisements = context.Advertisements.ToList();
            if (advertisements.Count > 0) return advertisements;
            return new List<Advertisement>();
        }

        public int Remove(int advertisementID)
        {
            Advertisement advertisement = context.Advertisements.Find(advertisementID)!;
            if (advertisement == null) throw new Exception($"Failed to delete advertisement with id = {advertisementID}");
            try
            {
                context.Advertisements.Remove(advertisement);
                return context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete advertisment: {ex.Message}");
            }
        }

        public Advertisement Update(Advertisement advertisement, int advertisementID)
        {
            Advertisement advertisement_db = context.Advertisements.Find(advertisementID)!;
            if (advertisement_db == null)
            {
                throw new Exception($"Failed to update advertisment with advertisment id = {advertisementID}");
            }

            advertisement_db.Title = advertisement.Title;
            advertisement_db.Price = advertisement.Price;
            advertisement_db.Description = advertisement.Description;
            advertisement_db.Model = advertisement.Model;
            advertisement_db.YearOfProduction = advertisement.YearOfProduction;
            advertisement_db.NumberOfDoors = advertisement.NumberOfDoors;
            advertisement_db.NumberOfPlaces = advertisement.NumberOfPlaces;
            advertisement_db.IsPriceNegotiable = advertisement.IsPriceNegotiable;
            advertisement_db.Category = advertisement.Category;
            advertisement_db.Color = advertisement.Color;
            advertisement_db.VIN = advertisement.VIN;
            advertisement_db.Power = advertisement.Power;
            advertisement_db.Displacement = advertisement.Displacement;
            advertisement_db.Gearbox = advertisement.Gearbox;
            advertisement_db.FuelType = advertisement.FuelType;
            advertisement_db.BodyType = advertisement.BodyType;
            advertisement_db.Condition = advertisement.Condition;
            advertisement_db.Mileage = advertisement.Mileage;
            advertisement_db.Email = advertisement.Email;
            advertisement_db.PhoneNumber = advertisement.PhoneNumber;

            try
            {
                context.Advertisements.Update(advertisement_db);
                context.SaveChanges();
                return advertisement_db;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update advertisment: {ex.Message}");
            }
        }
    }
}
