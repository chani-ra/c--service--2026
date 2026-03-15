using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c__repository_2026.c__service_2026.Dto
{
    public class DetectedCharacterDTO
    {
        public int Id { get; set; }
        public int ImageId { get; set; }
        public int CharacterId { get; set; }
        public string CharacterName { get; set; }  // ✨ שם הדמות (לא צריך להחזיר את כל האובייקט)
        public float Confidence { get; set; }       // ערך בין 0 ל-1 (דיוק הזיהוי)
        public DateTime DetectionDate { get; set; }
    }
}
