using FileImageUploading.UploadImage;

namespace FileImageUploading.Repository
{
    public class FileUploadClass:FileUploadInterface
    {

        public static IWebHostEnvironment _environment;

        public FileUploadClass(IWebHostEnvironment enviornment)
        {
            _environment = enviornment;
        }
        public  FileResponseModel PostFile(FileUploadRequestApi file)
        {

            FileResponseModel response= new FileResponseModel();
            FileUploadRequestApi requestApi= new FileUploadRequestApi();

            string webRootPath = _environment.WebRootPath;
            string contentRootPath = _environment.ContentRootPath;



            _environment.WebRootPath = Path.Combine(webRootPath, "Upload\\Images");


            try
            {
                requestApi.ImgID = 11;
                requestApi.ImgName = file.ImgName;
                if (file.files.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath);
                    }
                    using (FileStream filestream = System.IO.File.Create(_environment.WebRootPath + "\\" + file.files.FileName))
                    {
                        file.files.CopyTo(filestream);
                        filestream.Flush();
                        //  return "\\Upload\\" + objFile.files.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            response.ResponseMessage = "File Uploaded";

        return response;

        }
    }
}
