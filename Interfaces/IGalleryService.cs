//c#-service-2026/Interfaces/IGalleryService.cs
using c__service_2026.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace c__service_2026.Interfaces
{
    public interface IGalleryService : IService<GalleryDto>
    {
        Task<List<GalleryDto>> GetByUserIdAsync(int userId);
        Task<List<GalleryDto>> GetByCharacterIdAsync(int characterId);
        Task<GalleryDto> GetWithImagesAsync(int galleryId);
        Task<Dictionary<string, object>> GetGalleryStatisticsAsync(int galleryId);
    }
}
/*
 * -------------------------------------------------------------------------
 * הסבר מפורט למבחן (מטרת עמוד זה):
 * -------------------------------------------------------------------------
 * ממשק לניהול לוגיקת הגלריות. 
 * דגש חשוב למבחן הוא הפונקציה GetByUserIdAsync: זוהי הכנה למערכת האבטחה (סעיף 21).
 * בעזרת הפונקציה הזו, נוכל לוודא שמשתמש מחובר רואה רק את הגלריות שהוא יצר (לפי ה-Token שלו).
 * בנוסף, הפונקציה GetWithImagesAsync מבטיחה החזרה של גלריה על כל תמונותיה בשליפה אחת ללקוח.
 */