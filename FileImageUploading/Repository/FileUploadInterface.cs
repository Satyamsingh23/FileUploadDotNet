using FileImageUploading.UploadImage;

namespace FileImageUploading.Repository
{
    public interface FileUploadInterface
    {
        public FileResponseModel PostFile(FileUploadRequestApi fileUploadRequestApi);
    }
}
