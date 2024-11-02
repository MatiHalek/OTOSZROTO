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
        private readonly IImageRepository imageRepository;
        public ImageController(IWebHostEnvironment hostEnvironment, IImageRepository imageRepository)
        {
            this.hostEnvironment = hostEnvironment;
            this.imageRepository = imageRepository;
        }
        [HttpPost("uploadGalleryImages/{advertismentID}")]
        public async Task<IActionResult> UploadGalleryImages(List<IFormFile> files,int advertismentID)
        {
            string imageToken = await Utils.UploadImages(files, "gallery");
            imageRepository.InsertGalleryImage(imageToken,files,advertismentID);
            return Ok(imageToken);
        }

        [HttpGet("uploadGalleryImages/{advertismentID}")]
        public IActionResult GetGalleryImages(int advertismentID)
        {
            List<byte[]> fileBytesList = imageRepository.GetGalleryImages(advertismentID);
            byte[] fileBytes = Utils.CombineChunks(fileBytesList);
            return File(fileBytes, "image/png");
        }
    }
}
