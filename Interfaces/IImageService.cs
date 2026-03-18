//c#-service-2026/Interfaces/IImageService.cs
using c__service_2026.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace c__service_2026.Interfaces
{
    public interface IImageService : IService<ImageDto>
    {
        Task<List<ImageDto>> GetByGalleryIdAsync(int galleryId);
        Task<List<ImageDto>> GetByUserIdAsync(int userId);
        Task<List<ImageDto>> GetUnprocessedAsync();
        Task<bool> MarkAsProcessedAsync(int imageId);
        Task<ImageDto> GetWithDetectionsAsync(int imageId);
    }
}
/*
 * -------------------------------------------------------------------------
 * הסבר מפורט למבחן (מטרת עמוד זה):
 * -------------------------------------------------------------------------
 * ממשק המגדיר את השירותים הקשורים לניהול התמונות הפיזיות במערכת.
 * מכיל לוגיקה עסקית מעניינת כמו GetUnprocessedAsync - שנועדה למשוך את כל התמונות
 * שהועלו לשרת אך טרם עברו סריקה על ידי אלגוריתם זיהוי הפנים.
 * שימוש בממשקים מסודרים כאלה מקל על עבודת צוות - אפשר שבת אחת תכתוב את ה-Controller
 * בזמן שבת אחרת מממשת את ה-Service, כיוון שהחוזה (ה-Interface) כבר מוגדר וברור.
 */