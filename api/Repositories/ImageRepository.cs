using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace api.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly AppDbContext context;
        public ImageRepository(AppDbContext context)
        {
            this.context = context;
        }
        public int InsertGalleryImage(string imageToken, List<IFormFile> files, int advertismentID)
        {
            for (int i = 0; i < files.Count; i++)
            {
                AdvertismentImage advertismentImage = new AdvertismentImage()
                {
                    ImageSource = $"car_{imageToken}/{imageToken}_{i}{Path.GetExtension(files[i].FileName)}",
                    AdvertismentID = advertismentID,
                };
                context.AdvertismentImages.Add(advertismentImage);
            }
            context.SaveChanges();
            return 1;
        }

        public List<byte[]> GetGalleryImages(int advertismentID)
        {
            var advertismentImages = context.AdvertismentImages.Where(ai => ai.AdvertismentID == advertismentID).ToList();
            List<byte[]> bytes = new List<byte[]>();
            foreach (var image in advertismentImages)
            {
                byte[] imageBytes = System.IO.File.ReadAllBytes(
                    Path.Combine(Directory.GetCurrentDirectory(), $"Uploads/gallery"));
                bytes.Add(imageBytes);
            }
            return bytes;
        }
    }
}
