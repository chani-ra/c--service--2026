using c__service_2026.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace c__service_2026.Interfaces
{
    public interface IGalleryService : IService<GalleryDto>
    {
        Task<List<GalleryDto>> GetByUserAsync(int userId);
        Task<List<GalleryDto>> GetByCharacterAsync(int characterId);
        Task<GalleryDto> GetWithImagesAsync(int galleryId);
        Task<Dictionary<string, object>> GetGalleryStatisticsAsync(int galleryId);
    }
}
/*
 * מטרת הקובץ (IGalleryService):
 * ממשק לניהול גלריות תמונות.
 * מאפשר שליפת גלריות לפי משתמש (דרישה מס' 21 - אבטחה והרשאות) וכן שליפה מלאה 
 * הכוללת את כל אובייקטי התמונות שבתוך הגלריה (Eager Loading בתוך ה-DTO).
 */