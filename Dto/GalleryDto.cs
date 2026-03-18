using c__repository_2026.c__service_2026.Dto;
using System;
using System.Collections.Generic;

namespace c__service_2026.Dto
{
    public class GalleryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CharacterId { get; set; }
        public string CharacterName { get; set; } = string.Empty;
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ImageCount { get; set; }

        // תיקון קריטי: שונה מ-ImageDTO (אותיות גדולות) ל-ImageDto (כמו שם המחלקה האמיתי)
        public List<ImageDto> Images { get; set; } = new List<ImageDto>();
    }
}
/*
 * מטרת הקובץ (GalleryDto):
 * אובייקט שמחזיר למשתמש את פרטי הגלריה.
 * הוא מכיל מידע נוסף שנוח למשתמש לראות, כמו 'ImageCount' (כמות התמונות בגלריה) 
 * ואת 'CharacterName'. הוא גם מחזיק רשימה של ImageDto, כך שכשנשלוף גלריה, 
 * הלקוח יקבל את כל פרטי התמונות שבתוכה מיד.
 */