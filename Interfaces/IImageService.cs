using c__repository_2026.c__service_2026.Dto;
using System.Collections.Generic;

namespace Service.Interfaces
{
    internal interface IImageService : IService<ImageDto>
    {
        List<ImageDto> GetByGallery(int galleryId);
        List<ImageDto> GetByUser(int userId);
        List<ImageDto> GetUnprocessed();
        bool MarkAsProcessed(int imageId);
        ImageDto GetWithDetections(int imageId);
    }
}