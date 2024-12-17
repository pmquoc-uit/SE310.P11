using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Core.Interfaces;
using Infrastructure.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloudinary;
        public PhotoService(IOptions<CloudinarySettings> config)
        {
            var acc = new Account(config.Value.CloudName, config.Value.ApiKey, config.Value.ApiSecret);

            _cloudinary = new Cloudinary(acc);
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
                    //Transformation = new Transformation()
                    //    .Height(500).Width(500).Crop("fill").Gravity("face"),
                    Folder = "da-net8",
                    PublicId = "uploads/" + Guid.NewGuid().ToString() // Optional: Customize Public ID
                };

                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            return uploadResult;
        }

        public async Task<DeletionResult> DeletePhotoByIdAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);

            return await _cloudinary.DestroyAsync(deleteParams);
        }

        public async Task<DeletionResult> DeletePhotoByUrlAsync(string imageUrl)
        {
            DeletionParams deleteParams = new(GetPublicId(imageUrl));
            var result = await _cloudinary.DestroyAsync(deleteParams);
            return result;
        }

        private String GetPublicId(String imageUrl)
        {
            int startIndex = imageUrl.LastIndexOf('/') + 1;
            int endIndex = imageUrl.LastIndexOf('.');
            int length = endIndex - startIndex;
            return imageUrl.Substring(startIndex, length);
        }
    }
}
