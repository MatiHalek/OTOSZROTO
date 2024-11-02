namespace api.Interfaces
{
    public interface IImageRepository
    {
        int Create();
        int InsertGalleryImage(string imageToken,int filesCount);
    }
}
