using System;

namespace c__service_2026.Dto
{
    public class CharacterDto
    {
        public int Id { get; set; }
        public string CharacterName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }

        // שדות מחושבים (לא קיימים ישירות בטבלה ב-DB)
        public int TotalDetections { get; set; }
        public string ProfileImageUrl { get; set; } = string.Empty;
    }
}
/*
 * -------------------------------------------------------------------------
 * הסבר מפורט למבחן (למה אנחנו צריכים את Dto / CharacterDto?):
 * -------------------------------------------------------------------------
 * אובייקט DTO (Data Transfer Object) נועד להעברת נתונים בין השרת (API) ללקוח (Client).
 * הסיבה שיצרנו אותו היא כדי להפריד בין איך שהנתונים נשמרים במסד הנתונים (Entities) 
 * לבין מה שאנחנו בוחרים להציג למשתמש. 
 * למשל, כאן הוספנו את השדה 'TotalDetections' (סך הכל זיהויים). זהו שדה "מחושב" - 
 * הוא לא נשמר בעמודה בטבלה, אלא שכבת ה-Service תחשב אותו בזמן אמת ותמלא אותו פה, 
 * כדי שלצד-לקוח (Client Side) יהיה קל להציג את הנתון בלי לעשות חישובים מסובכים בעצמו.
 * בהמשך נשתמש בספריית AutoMapper (לפי דרישת הפרויקט) כדי להמיר אוטומטית בין 
 * הישות המקורית (Character) לבין ה-DTO הזה.
 */