using c__repository_2026.c__service_2026.Dto;
using c__repository_2026.c__service_2026.Interfaces;
using System.Collections.Generic;

namespace c__repository_2026.c__service_2026.Interfaces
{
    public interface ICharacterService : IService<CharacterDto>
    {
        List<CharacterDto> SearchByName(string name);
        List<CharacterDto> GetTopDetected(int topCount);
        Dictionary<string, object> GetCharacterStatistics(int characterId);
    }
}
