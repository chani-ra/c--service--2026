using c__repository_2026.c__service_2026.Dto;
using System.Collections.Generic;

namespace Service.Interfaces
{
    internal interface IDetectionService : IService<DetectedCharacterDto>
    {
        List<DetectedCharacterDto> GetByImage(int imageId);
        List<DetectedCharacterDto> GetByCharacter(int characterId);
        List<DetectedCharacterDto> GetHighConfidence(double minConfidence);
        Dictionary<string, object> GetDetectionStatistics();
    }
}