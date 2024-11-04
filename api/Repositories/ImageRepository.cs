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

        public List<AdvertismentImage> GetGalleryImages(int advertismentID)
        {
            List<AdvertismentImage> advertismentImages = context.AdvertismentImages.Where(ai => ai.AdvertismentID == advertismentID).ToList();
            return advertismentImages;
        }

        public string DeleteGalleryImageForAdvertisment(int advertismentID)
        {
            List<AdvertismentImage> advertismentImages = context.AdvertismentImages.Where(ai => ai.AdvertismentID == advertismentID).ToList();
            string singlePath = "";
            if(advertismentImages.Count > 0)
            {
                singlePath = advertismentImages[0].ImageSource!;
            }

            foreach (var image in advertismentImages)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), $"Uploads/gallery/{image.ImageSource}");
                if (File.Exists(path))
                {
                    Console.WriteLine(path + "Esa");
                    File.Delete(path);
                }
                context.AdvertismentImages.Remove(image);
            }
            context.SaveChanges(true);
            return singlePath;
        }
    }
}
