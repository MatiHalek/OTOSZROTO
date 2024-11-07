using api.Models;

namespace api.Interfaces
{
    public interface IImageRepository
    {
        int InsertGalleryImage(string imageToken, List<IFormFile> files, int advertismentID);
        List<AdvertismentImage> GetGalleryImages(int advertismentID);
    }
}
