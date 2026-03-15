using c__repository_2026.c__service_2026.Dto;
using Service.DTOs;
using System.Collections.Generic;

namespace Service.Interfaces
{
    public interface ICharacterService : IService<CharacterDto>
    {
        List<CharacterDto> SearchByName(string name);
        List<CharacterDto> GetTopDetected(int topCount);
        Dictionary<string, object> GetCharacterStatistics(int characterId);
    }
}