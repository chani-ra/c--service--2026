using System;
using System.Collections.Generic;

namespace c__service_2026.Dto
{
    public class GalleryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CharacterId { get; set; }

        // נתונים "שטוחים" ומחושבים
        public string CharacterName { get; set; } = string.Empty;
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ImageCount { get; set; }

        // הכלה של כל התמונות שבתוך הגלריה
        public List<ImageDto> Images { get; set; } = new List<ImageDto>();
    }
}
/*
 * -------------------------------------------------------------------------
 * הסבר מפורט למבחן (GalleryDto):
 * -------------------------------------------------------------------------
 * זהו ה-DTO הגדול ביותר שלנו. הוא אוסף נתונים ממספר טבלאות כדי להגיש ללקוח 
 * אובייקט מוכן להצגה. הוא כולל את שם הדמות (CharacterName), את כמות התמונות 
 * בגלריה (ImageCount), ואת מערך התמונות המלא (Images). 
 * מבנה כזה מבטיח שה-WebAPI יחזיר תשובה אחת עשירה, ולא יאלץ את הלקוח לעשות 
 * עשרות קריאות API נפרדות לכל תמונה.
 */