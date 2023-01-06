using CloudinaryDotNet.Actions;
using TodoList_MySQL.Model;

namespace TodoList_MySQL.Service.Interface
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);

        Task<DeletionResult> DeletePhotoAsync(string publicId);

        Task<IReadOnlyList<Photo>> GetUserPhoto(int userId);
    }
}
