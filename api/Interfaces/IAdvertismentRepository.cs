using api.Models;

namespace api.Interfaces
{
    public interface IAdvertismentRepository
    {
        Advertisement Create(Advertisement advertisement);
        Advertisement Update(Advertisement advertisement,int advertisementID);
        List<Advertisement> GetAll();
        Advertisement Get(int advertisementID);
        int Remove(int advertisementID);
    }
}
