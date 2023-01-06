using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
using TodoList_MySQL.Helper;
using TodoList_MySQL.Model;
using TodoList_MySQL.Service.Interface;
using TodoList_MySQL.Specification.ModelSpecification;

namespace TodoList_MySQL.Service
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary cloudinary;
        private readonly IUnitOfWork unitOfWork;

        public PhotoService(IOptions<CloudinarySettings> config, IUnitOfWork unitOfWork)
        {
            var acc = new Account
                (
                    config.Value.CloudName,
                    config.Value.ApiKey,
                    config.Value.ApiSecret
                );

            cloudinary = new Cloudinary(acc);
            this.unitOfWork = unitOfWork;
        }

        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face"),
                    Folder = "photo"
                };
                uploadResult = await cloudinary.UploadAsync(uploadParams);
            }

            return uploadResult;
        }

        public async Task<DeletionResult> DeletePhotoAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);

            var result = await cloudinary.DestroyAsync(deleteParams);

            return result;
        }

        public async Task<IReadOnlyList<Photo>> GetUserPhoto(int userId)
        {
            var spec = new PhotoWithInfomationSpecifiction(userId);

            return await unitOfWork.Repository<Photo>().ListAsync(spec);
        }
    }
}
