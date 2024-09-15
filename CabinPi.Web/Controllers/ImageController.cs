using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace CabinPi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : Controller
    {
        private readonly IConfiguration _configuration;

        public ImageController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET api/Products
        [HttpGet]
        public IActionResult Get(string name)
        {
            var path = Path.Combine(_configuration.GetValue<string>("ImagePath"), name);
            if (!System.IO.File.Exists(path))
                return NotFound();
            var fileBytes = System.IO.File.ReadAllBytes(path);

            using (Image image = Image.Load(fileBytes))
            {
                image.Mutate(x => x.Resize(640, 0));
                using (MemoryStream ms = new MemoryStream())
                {
                    image.SaveAsJpeg(ms);
                    fileBytes = ms.ToArray();
                }
            }

            return File(fileBytes, "image/jpeg");
        }
    }
}
