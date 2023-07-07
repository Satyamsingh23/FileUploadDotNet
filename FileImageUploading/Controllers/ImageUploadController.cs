using FileImageUploading.Repository;
using FileImageUploading.UploadImage;
using Microsoft.AspNetCore.Http;        
using Microsoft.AspNetCore.Mvc;

namespace FileImageUploading.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageUploadController : ControllerBase
    {

        public readonly FileUploadInterface _interface;
        

        public ImageUploadController(IWebHostEnvironment environment,FileUploadInterface fileUploadInterface)
        {
            

            _interface = fileUploadInterface;


        }

        [HttpPost]
        [Route("UploadFile")]
        

        public IActionResult UploadFile( [FromForm]   FileUploadRequestApi file)
        {
            var data = _interface.PostFile(file);
            return Ok(data);
        }


    }
}
