using CloudinaryDotNet.Actions;

namespace TodoList_MySQL.Service.Interface
{
    public interface IVideoService
    {
        Task<VideoUploadResult> AddVideoAsync(IFormFile file);

        Task<DeletionResult> DeletePhotoAsync(string publicId);

        Task<IReadOnlyList<Model.Video>> GetVideo();
    }
}
