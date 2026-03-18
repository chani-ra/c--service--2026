//c#-service-2026/Services/DetectedCharacterService.cs
using.c__service_2026.Dto;
using c__service_2026.Dto;
using c__service_2026.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace c__service_2026.Services
{
    public class DetectedCharacterService : IDetectedService
    {
        private readonly IDetectedService _detectionRepository;
        private readonly ICharacterService _characterRepository;

        public DetectedCharacterService(IDetectedService detectionRepository, ICharacterRepository characterRepository)
        {
            _detectionRepository = detectionRepository;
            _characterRepository = characterRepository;
        }

        public List<DetectedCharacterDto> GetAll()
        {
            return _detectionRepository.GetAll().Select(MapToDTO).ToList();
        }

        public DetectedCharacterDto Get(int id)
        {
            var detection = _detectionRepository.Get(id);
            return detection == null ? null : MapToDTO(detection);
        }

        public DetectedCharacterDto AddItem(DetectedCharacterDto item)
        {
            item.DetectionDate = DateTime.Now;
            var result = _detectionRepository.AddItem(item);
            return MapToDTO(result);
        }

        public List<DetectedCharacterDto> GetHighConfidence(double minConfidence)
        {
            return _detectionRepository.GetAll()
                .Where(d => d.Confidence >= minConfidence)
                .Select(MapToDTO).ToList();
        }

        public Dictionary<string, object> GetDetectionStatistics()
        {
            var all = _detectionRepository.GetAll();
            return new Dictionary<string, object>
            {
                { "TotalDetections", all.Count },
                { "AverageConfidence", all.Any() ? all.Average(d => d.Confidence) : 0 },
                { "SuccessRate", all.Count(d => d.Confidence > 70) }
            };
        }

        public void UpdateItem(int id, DetectedCharacterDto item) => _detectionRepository.UpdateItem(id, item);
        public void DeleteItem(int id) => _detectionRepository.DeleteItem(id);
        public List<DetectedCharacterDto> GetByImage(int imageId) => _detectionRepository.GetDetectionsByImageId(imageId).Select(MapToDTO).ToList();
        public List<DetectedCharacterDto> GetByCharacter(int characterId) => _detectionRepository.GetDetectionsByCharacterId(characterId).Select(MapToDTO).ToList();

        private DetectedCharacterDto MapToDTO(DetectedCharacterDto d)
        {
            var charName = _characterRepository.Get(d.CharacterId)?.CharacterName ?? "Unknown";
            return new DetectedCharacterDto
            {
                Id = d.Id,
                CharacterId = d.CharacterId,
                CharacterName = charName,
                Confidence = d.Confidence,
                DetectionDate = d.DetectionDate,
                ImageId = d.ImageId,
                FaceCoordinates = d.FaceCoordinates,
                ModelUsed = d.ModelUsed
            };
        }

        public Task<List<DetectedCharacterDto>> GetByImageAsync(int imageId)
        {
            throw new NotImplementedException();
        }

        public Task<List<DetectedCharacterDto>> GetByCharacterAsync(int characterId)
        {
            throw new NotImplementedException();
        }

        public Task<List<DetectedCharacterDto>> GetHighConfidenceAsync(double minConfidence)
        {
            throw new NotImplementedException();
        }

        public Task<Dictionary<string, object>> GetDetectionStatisticsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<DetectedCharacterDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<DetectedCharacterDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DetectedCharacterDto> AddItemAsync(DetectedCharacterDto item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateItemAsync(int id, DetectedCharacterDto item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteItemAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}