using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c__repository_2026.c__service_2026.Dto
{
   

  
        public class GalleryDto
        {
            
            public int Id { get; set; }

            public string Name { get; set; }

            public string Description { get; set; }

            
            public int CharacterId { get; set; }

           
            public string CharacterName { get; set; }

            public int UserId { get; set; }

            public DateTime CreatedDate { get; set; }

            
            public int ImageCount { get; set; }

            public List<ImageDto> Images { get; set; } = new List<ImageDTO>();
        }
    }
}
