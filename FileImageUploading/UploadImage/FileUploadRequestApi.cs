using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace FileImageUploading.UploadImage
{
    public class FileUploadRequestApi
    {
        public int ImgID { get; set; }
        public string? Customers { get; set; }
        public IFormFile? files { get; set; }
        public string ImgName { get; set; }
    }

    public class FileResponseModel
    { 
        public FileUploadRequestApi requestApi { get; set; }
        public string ResponseMessage { get; set; }
    }


}
