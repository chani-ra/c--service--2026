using c__repository_2026.c__service_2026.Dto;
using System.Collections.Generic;

namespace Service.Interfaces
{
    internal interface IGalleryService : IService<GalleryDto>
    {
        List<GalleryDto> GetByUser(int userId);
        List<GalleryDto> GetByCharacter(int characterId);
        GalleryDto GetWithImages(int galleryId);
        Dictionary<string, object> GetGalleryStatistics(int galleryId);
    }
}