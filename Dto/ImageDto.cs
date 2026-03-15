using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c__repository_2026.c__service_2026.Dto
{
    public class ImageDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int GalleryId { get; set; }
        public int UserId { get; set; }
        public DateTime UploadedDate { get; set; } // תוסיף זה להמשך
    }
}
