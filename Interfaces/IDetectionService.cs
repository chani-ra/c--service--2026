//c#-service-2026/Interfaces/IDetectionService.cs
using c__service_2026.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace c__service_2026.Interfaces
{
    public interface IDetectionService : IService<DetectedCharacterDto>
    {
        Task<List<DetectedCharacterDto>> GetByImageIdAsync(int imageId);
        Task<List<DetectedCharacterDto>> GetByCharacterIdAsync(int characterId);
        Task<List<DetectedCharacterDto>> GetHighConfidenceAsync(double minConfidence);
        Task<Dictionary<string, object>> GetDetectionStatisticsAsync();
    }
}
/*
 * -------------------------------------------------------------------------
 * הסבר מפורט למבחן (מטרת עמוד זה):
 * -------------------------------------------------------------------------
 * ממשק המגדיר את פעולות השירות עבור 'זיהויים' (DetectedCharacter).
 * פונקציות מרכזיות כאן כמו GetHighConfidenceAsync מאפשרות למערכת לסנן
 * ולהציג רק זיהויים ברמת ביטחון גבוהה (למשל מעל 90% ודאות שזו אותה דמות).
 * הממשק עובד אך ורק עם DetectedCharacterDto.
 */