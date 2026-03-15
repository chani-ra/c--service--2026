using c__repository_2026.c__service_2026.Dto;
using c__repository_2026.c__service_2026.Interfaces;
using System.Collections.Generic;

namespace Service.Interfaces
{
    public interface IGalleryService : IService<GalleryDto>
    {
        List<GalleryDto> GetByUser(int userId);
        List<GalleryDto> GetByCharacter(int characterId);
        GalleryDto GetWithImages(int galleryId);
        Dictionary<string, object> GetGalleryStatistics(int galleryId);
    }
}