//c#-service-2026/Dto/ImageDto.cs
using System;
using System.Collections.Generic;

namespace c__service_2026.Dto
{
    public class ImageDto
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public int GalleryId { get; set; }
        public int UserId { get; set; }

        // רשימה של כל הדמויות שזוהו בתמונה הזו
        public List<DetectedCharacterDto> Detections { get; set; } = new List<DetectedCharacterDto>();
    }
}
/*
 * -------------------------------------------------------------------------
 * הסבר מפורט למבחן (ImageDto):
 * -------------------------------------------------------------------------
 * אובייקט המייצג תמונה יחידה במערכת. 
 * מלבד הנתונים הבסיסיים של התמונה, הוספנו כאן רשימה מסוג 'Detections'.
 * זה אומר שכאשר המשתמש שולף תמונה מהשרת, הוא מיד מקבל בתוך אותו אובייקט JSON 
 * את כל תוצאות הזיהוי שבוצעו עליה. זה מתאפשר בזכות ה-Include (Eager Loading) 
 * שעשינו קודם בשכבת ה-Repository, ומבטיח חווית משתמש מהירה ורספונסיבית בצד הלקוח.
 */