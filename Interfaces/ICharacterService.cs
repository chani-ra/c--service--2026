using c__repository_2026.c__service_2026.Dto;
using System.Collections.Generic;

namespace c#-service-2026.Interfaces
{
    internal interface ICharacterService : IService<CharacterDto>
    {
        List<CharacterDto> SearchByName(string name);
        List<CharacterDto> GetTopDetected(int topCount);
        Dictionary<string, object> GetCharacterStatistics(int characterId);
    }
}