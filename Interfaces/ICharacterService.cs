using c__service_2026.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace c__service_2026.Interfaces
{
    public interface ICharacterService : IService<CharacterDto>
    {
        // פונקציות ייחודיות ללוגיקת דמויות (מעבר ל-CRUD הרגיל)
        Task<List<CharacterDto>> SearchByNameAsync(string name);
        Task<List<CharacterDto>> GetTopDetectedAsync(int topCount);
        Task<Dictionary<string, object>> GetCharacterStatisticsAsync(int characterId);
    }
}
/*
 * -------------------------------------------------------------------------
 * הסבר מפורט למבחן (מטרת עמוד זה):
 * -------------------------------------------------------------------------
 * ממשק זה מרחיב את IService עבור הישות CharacterDto.
 * כאן מוגדרת הלוגיקה העסקית (Business Logic) הייחודית לדמויות, שלא קיימת בטבלאות אחרות.
 * למשל: הפונקציה GetTopDetectedAsync נועדה להחזיר את X הדמויות שזוהו הכי הרבה פעמים במערכת.
 * הפונקציות מחזירות DTO בלבד, כדי לנתק את שכבת התצוגה ממסד הנתונים (הוראה סעיף 16).
 */