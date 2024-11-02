namespace api.Interfaces
{
    public interface IImageRepository
    {
        int InsertGalleryImage(string imageToken, List<IFormFile> files, int advertismentID);
        List<byte[]> GetGalleryImages(int advertismentID);
    }
}
