using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c__repository_2026.c__service_2026.Dto
{
    public class DetectedCharacterDto
    {
    
            
            public int Id { get; set; }

            
            public int ImageId { get; set; }

            public int CharacterId { get; set; }

           
            public string CharacterName { get; set; }

            public double Confidence { get; set; }

            public string FaceCoordinates { get; set; }

            public DateTime DetectionDate { get; set; }

            
            public string ModelUsed { get; set; }
        }
    }

