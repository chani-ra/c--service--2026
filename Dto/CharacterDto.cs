//c#-service-2026/Dto/CharacterDto.cs
using System;

namespace c__service_2026.Dto
{
    public class CharacterDto
    {
        public int Id { get; set; }
        public string CharacterName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int TotalDetections { get; set; }
        public DateTime CreatedDate { get; set; }

        // שיניתי מ-object ל-string, כי URL של תמונה הוא טקסט
        public string ProfileImageUrl { get; set; } = string.Empty;
    }
}
/*
 * מטרת הקובץ (CharacterDto):
 * DTO (Data Transfer Object) מייצג את המידע שאנחנו שולחים ללקוח (Client) או מקבלים ממנו.
 * בשונה ממחלקת ה-Character הרגילה (שמייצגת טבלה במסד הנתונים), כאן אנחנו יכולים להוסיף 
 * שדות מחושבים כמו 'TotalDetections' (סך כל הזיהויים) שלא נשמרים ישירות ב-DB אלא מחושבים בשכבת הלוגיקה (Service),
 * וכן אנחנו מסתירים מידע רגיש מה-DB במידה ויש. 
 * המורה דרשה (סעיף 16) להשתמש ב-AutoMapper ע"מ להמיר אובייקטים אלו.
 */