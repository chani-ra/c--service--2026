using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c__repository_2026.c__service_2026.Dto
{
    internal class CharacterDto
    {
        public int Id { get; set; }
        public string CharacterName { get; set; }
        public required string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }

}
