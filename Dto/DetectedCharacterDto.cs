using System;

namespace c__service_2026.Dto
{
    public class DetectedCharacterDto
    {
        public int Id { get; set; }
        public int ImageId { get; set; }
        public int CharacterId { get; set; }
        public string CharacterName { get; set; } = string.Empty;
        public double Confidence { get; set; }
        public string FaceCoordinates { get; set; } = string.Empty;
        public DateTime DetectionDate { get; set; }
        public string ModelUsed { get; set; } = string.Empty;
    }
}
/*
 * מטרת הקובץ (DetectedCharacterDto):
 * אובייקט העברת הנתונים עבור זיהוי ספציפי בתמונה. 
 * שימי לב שהוספנו כאן את 'CharacterName' למרות שהוא לא קיים בטבלת הזיהויים המקורית - 
 * זה היתרון של DTO! אנחנו "משטחים" את המידע כדי שלצד-לקוח יהיה קל להציג את שם הדמות
 * מבלי לעשות בקשות נוספות לשרת. ה-AutoMapper יידע לקחת את השם מתוך קשר הגומלין.
 */