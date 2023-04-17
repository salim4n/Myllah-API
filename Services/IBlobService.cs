namespace Myllah_API.Services
{
    public interface IBlobService
    {
        Task<string> GetBlob(string blobName);
        Task<bool> DeleteBlob(string blobName);
        Task<string> UploadBlob(string blobName, IFormFile file);
    }
}
