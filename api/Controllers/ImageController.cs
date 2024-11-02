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
