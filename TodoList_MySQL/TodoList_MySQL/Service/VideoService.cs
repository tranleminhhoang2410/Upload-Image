using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
using TodoList_MySQL.Helper;
using TodoList_MySQL.Service.Interface;

namespace TodoList_MySQL.Service
{
    public class VideoService : IVideoService
    {
        private readonly Cloudinary cloudinary;
        private readonly IUnitOfWork unitOfWork;

        public VideoService(IOptions<CloudinarySettings> config, IUnitOfWork unitOfWork)
        {
            var acc = new Account
                (
                    config.Value.CloudName,
                    config.Value.ApiKey,
                    config.Value.ApiSecret
                );

            cloudinary = new Cloudinary(acc);
            this.unitOfWork = unitOfWork;
            this.unitOfWork = unitOfWork;
        }

        public async Task<VideoUploadResult> AddVideoAsync(IFormFile file)
        {
            var uploadResult = new VideoUploadResult();

            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new VideoUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill"),
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

        public async Task<IReadOnlyList<Model.Video>> GetVideo()
        {
            return await unitOfWork.Repository<Model.Video>().ListAllAsync();
        }
    }
}
