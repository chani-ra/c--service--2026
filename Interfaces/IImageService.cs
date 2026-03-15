using c__repository_2026.c__service_2026.Dto;
using c__repository_2026.c__service_2026.Interfaces;
using System.Collections.Generic;

namespace Service.Interfaces
{
    public interface IImageService : IService<GalleryDto>
    {
        List<ImageDto> GetByGallery(int galleryId);
        List<ImageDto> GetByUser(int userId);
        List<ImageDto> GetUnprocessed();
        bool MarkAsProcessed(int imageId);
        ImageDto GetWithDetections(int imageId);
    }
}