using System;

namespace c__service_2026.Dto
{
    public class DetectedCharacterDto
    {
        public int Id { get; set; }
        public int ImageId { get; set; }
        public int CharacterId { get; set; }

        // שדה "שטוח" שיילקח מתוך טבלת הדמויות
        public string CharacterName { get; set; } = string.Empty;

        public float Confidence { get; set; } // הותאם ל-float כמו ב-DB
        public DateTime DetectionDate { get; set; }

        // נתונים נוספים שהאלגוריתם עשוי להחזיר
        public string FaceCoordinates { get; set; } = string.Empty;
        public string ModelUsed { get; set; } = string.Empty;
    }
}
/*
 * -------------------------------------------------------------------------
 * הסבר מפורט למבחן (DetectedCharacterDto):
 * -------------------------------------------------------------------------
 * מחלקה זו מייצגת זיהוי של דמות בתוך תמונה.
 * היתרון הגדול של ה-DTO בא לידי ביטוי כאן בשדה 'CharacterName'.
 * בבסיס הנתונים המקורי יש לנו רק 'CharacterId', אבל הלקוח (הדפדפן) צריך להציג 
 * את שם הדמות, ולא מספר סתמי. ה-DTO מאפשר לנו "לשטח" (Flattening) את קשרי הגומלין!
 * כשנשתמש ב-AutoMapper, הוא יידע לגשת אוטומטית לישות המקושרת ולהעתיק משם את השם.
 * כך אנחנו חוסכים פניות נוספות מהלקוח לשרת ומשפרים את ביצועי האפליקציה.
 */