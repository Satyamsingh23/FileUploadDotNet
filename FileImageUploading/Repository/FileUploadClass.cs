using FileImageUploading.Models;
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
        public  FileResponseModel PostFile(FileUploadRequestApi obj)
        {

            FileResponseModel response= new FileResponseModel();
            FileUploadRequestApi requestApi= new FileUploadRequestApi();
            FileUpload070723 value = new FileUpload070723();
            sdirectdbContext _db = new sdirectdbContext();

            try
            {
                //requestApi.ImgID = obj.ImgID;
                //requestApi.ImgName = obj.ImgName;
                if (obj.files.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\Upload"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath +"\\Upload\\");
                    }
                    string val1 = DateTime.Now.ToString();
                    val1 = val1.Replace("/", string.Empty);
                    val1 = val1.Replace(":", string.Empty);
                    val1 = val1.Replace(" ", string.Empty);
                   
                    using (FileStream filestream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\"+val1+ obj.files.FileName))
                    {
                        obj.files.CopyTo(filestream);
                        filestream.Flush();
                        value.ImgLoc = "\\Upload\\"+ val1 +obj.files.FileName ;
                        _db.FileUpload070723s.Add(value);
                        _db.SaveChanges();
                        //  return "\\Upload\\" + objFile.files.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            response.requestApi= obj;
            response.ResponseMessage = "File Uploaded";

        return response;

        }
    }
}
