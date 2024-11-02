using api.Data;
using api.Interfaces;

namespace api.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly AppDbContext context;
        public ImageRepository(AppDbContext context)
        {
            this.context = context;
        }
        public int InsertGalleryImage(string imageToken, int filesCount)
        {
            throw new NotImplementedException();
        }
    }
}
