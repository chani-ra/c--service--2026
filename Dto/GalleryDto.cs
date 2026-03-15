using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c__repository_2026.c__service_2026.Dto
{
    public class GalleryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }           // שם הגלריה (למשל: "Brad Pitt Collection")
        public int CharacterId { get; set; }       // מזהה הדמות
        public string CharacterName { get; set; }  // ✨ שם הדמות ישירות
        public int UserId { get; set; }            // למי שייכת הגלריה
        public DateTime CreatedDate { get; set; }  // מתי נוצרה
        public List<ImageDto> Images { get; set; } = new List<ImageDto>(); // כל התמונות בגלריה
    }
}
