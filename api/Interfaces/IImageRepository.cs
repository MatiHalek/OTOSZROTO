namespace api.Interfaces
{
    public interface IImageRepository
    {
        int InsertGalleryImage(string imageToken,int filesCount);
    }
}
