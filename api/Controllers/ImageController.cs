using api.Helpers;
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
        }
    }
}
