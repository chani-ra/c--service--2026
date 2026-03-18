using c__service_2026.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace c__service_2026.Interfaces
{
    public interface IDetectedService : IService<DetectedCharacterDto>
    {
        Task<List<DetectedCharacterDto>> GetByImageAsync(int imageId);
        Task<List<DetectedCharacterDto>> GetByCharacterAsync(int characterId);
        Task<List<DetectedCharacterDto>> GetHighConfidenceAsync(double minConfidence);
        Task<Dictionary<string, object>> GetDetectionStatisticsAsync();
    }
}
/*
 * מטרת הקובץ (IDetectedService):
 * ממשק זה מגדיר את הפעולות עבור תוצאות הזיהוי של האלגוריתם.
 * הוא מאפשר לשלוף את כל הזיהויים ששייכים לתמונה מסוימת או לדמות מסוימת, 
 * וכן לסנן זיהויים לפי "רמת ביטחון" (Confidence) - דרישה נפוצה במערכות זיהוי פנים.
 */