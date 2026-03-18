using c__service_2026.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace c__service_2026.Interfaces
{
    // תיקון: הירושה שונתה ל-ImageDto (קודם הייתה טעות ב-Generic)
    public interface IImageService : IService<ImageDto>
    {
        Task<List<ImageDto>> GetByGalleryAsync(int galleryId);
        Task<List<ImageDto>> GetByUserAsync(int userId);
        Task<List<ImageDto>> GetUnprocessedAsync();
        Task<bool> MarkAsProcessedAsync(int imageId);
        Task<ImageDto> GetWithDetectionsAsync(int imageId);
    }
}
/*
 * מטרת הקובץ (IImageService):
 * ממשק לניהול התמונות הגולמיות במערכת.
 * כולל לוגיקה לניהול סטטוס עיבוד (Unprocessed) - עוזר לדעת אילו תמונות חדשות הועלו 
 * ועדיין לא עברו תהליך זיהוי דמויות, וכן שליפת תמונה יחד עם כל הזיהויים שנמצאו בה.
 */