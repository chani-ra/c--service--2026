//c#-service-2026/Dto/ImageDto.cs
using System;

namespace c__service_2026.Dto
{
    public class ImageDto
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public int GalleryId { get; set; }
        public int UserId { get; set; }
        public DateTime UploadedDate { get; set; }
    }
}
/*
 * מטרת הקובץ (ImageDto):
 * הנתונים של תמונה בודדת שמועברים מהשרת ללקוח. 
 * השדה 'UploadedDate' התווסף כאן כפי שביקשת. בזמן ההמרה מ-Entity ל-DTO, 
 * אנחנו נדאג למפות את הנתונים בהתאם.
 */