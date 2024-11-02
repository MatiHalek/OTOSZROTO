using api.Helpers;
using api.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IWebHostEnvironment hostEnvironment;
        public ImageController(IWebHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
        }
        [HttpPost("upload/{directory}")]
        public async Task<IActionResult> UploadImages(List<IFormFile> files, string directory)
        {
            if (files == null || files.Count == 0)
                return Ok("esa");
            var uploads = Path.Combine(Directory.GetCurrentDirectory(), $"Uploads/{directory}");

            if (!Directory.Exists(uploads))
                Directory.CreateDirectory(uploads);

            foreach (var file in files)
            {
                string fileName = $"avatar_{Utils.GenerateRandomString(15)}{Path.GetExtension(file.FileName)}";

                var filePath = Path.Combine(uploads, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

            }
            return Ok("correct");
        //private readonly IImageRepository imageRepository;
        public ImageController(IWebHostEnvironment hostEnvironment/*, IImageRepository imageRepository*/)
        {
            this.hostEnvironment = hostEnvironment;
            //this.imageRepository = imageRepository;
        }
        [HttpPost("uploadGalleryImages/{advertismentID}")]
        public async Task<IActionResult> UploadGalleryImages(List<IFormFile> files,int advertismentID)
        {
            string imageToken = await Utils.UploadImages(files, "gallery");
            for (int i = 0; i < files.Count; i++)
            {
                
            }
            return Ok(imageToken);
        }
    }
}
