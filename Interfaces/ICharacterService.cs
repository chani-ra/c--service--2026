using c__service_2026.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace c__service_2026.Interfaces
{
    public interface ICharacterService : IService<CharacterDto>
    {
        Task<List<CharacterDto>> SearchByNameAsync(string name);
        Task<List<CharacterDto>> GetTopDetectedAsync(int topCount);
        Task<Dictionary<string, object>> GetCharacterStatisticsAsync(int characterId);
    }
}
/*
 * מטרת הקובץ (ICharacterService):
 * ממשק ייעודי ללוגיקה של ניהול דמויות.
 * בנוסף לפעולות הרגילות, הוא מגדיר מתודות לחיפוש דמות לפי שם, שליפת הדמויות הכי מזוהות 
 * והפקת סטטיסטיקה על דמות ספציפית (למשל: כמה פעמים הופיעה ובאיזה תאריכים).
 */