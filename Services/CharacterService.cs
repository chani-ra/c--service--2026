//c#-service-2026/Services/CharacterService.cs
using c__service_2026.Dto;           // ה-Entities מה-DB
using c__service_2026.Interfaces;

namespace c__service_2026.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterService _characterRepository;
        private readonly IDetectedService _detectionRepository;

        public CharacterService(ICharacterService characterRepository, IDetectedService detectionRepository)
        {
            _characterRepository = characterRepository;
            _detectionRepository = detectionRepository;
        }

        public List<CharacterDto> GetAll()
        {
            var characters = _characterRepository.GetAll();
            return characters.Select(MapToDTO).ToList();
        }

        public CharacterDto Get(int id)
        {
            var character = _characterRepository.Get(id);
            return character == null ? null : MapToDTO(character);
        }

        public CharacterDto AddItem(CharacterDto item)
        {
            if (string.IsNullOrWhiteSpace(item.CharacterName))
                throw new ArgumentException("שם הדמות חובה");

            var character = new CharacterDto
            {
                CharacterName = item.CharacterName,
                Description = item.Description,
                ProfileImageUrl = item.ProfileImageUrl,
                CreatedDate = DateTime.Now
            };

            var result = _characterRepository.AddItem(character);
            return MapToDTO(result);
        }

        public void UpdateItem(int id, CharacterDto item)
        {
            if (string.IsNullOrWhiteSpace(item.CharacterName))
                throw new ArgumentException("שם הדמות חובה");

            var character = _characterRepository.Get(id);
            if (character == null)
                throw new ArgumentException("דמות לא נמצאה");

            character.CharacterName = item.CharacterName;
            character.Description = item.Description;
            character.ProfileImageUrl = item.ProfileImageUrl;

            _characterRepository.UpdateItem(id, character);
        }

        public void DeleteItem(int id)
        {
            var character = _characterRepository.Get(id);
            if (character == null)
                throw new ArgumentException("דמות לא נמצאה");

            _characterRepository.DeleteItem(id);
        }

        public List<CharacterDto> SearchByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return new List<CharacterDto>();

            var characters = _characterRepository.SearchByName(name);
            return characters.Select(MapToDTO).ToList();
        }

        public List<CharacterDto> GetTopDetected(int topCount)
        {
            var detections = _detectionRepository.GetAll();
            var topCharacterIds = detections
                .GroupBy(d => d.CharacterId)
                .OrderByDescending(g => g.Count())
                .Take(topCount)
                .Select(g => g.Key)
                .ToList();

            var characters = new List<CharacterDto>();
            foreach (var characterId in topCharacterIds)
            {
                var character = _characterRepository.Get(characterId);
                if (character != null)
                    characters.Add(MapToDTO(character));
            }

            return characters;
        }

        public Dictionary<string, object> GetCharacterStatistics(int characterId)
        {
            var character = _characterRepository.Get(characterId);
            if (character == null)
                throw new ArgumentException("דמות לא נמצאה");

            var detections = _detectionRepository.GetDetectionsByCharacterId(characterId);
            var avgConfidence = detections.Count > 0 ? detections.Average(d => d.Confidence) : 0;

            return new Dictionary<string, object>
            {
                { "CharacterId", characterId },
                { "CharacterName", character.CharacterName },
                { "TotalDetections", detections.Count },
                { "AverageConfidence", Math.Round(avgConfidence, 2) },
                { "HighConfidenceCount", detections.Count(d => d.Confidence >= 85) }
            };
        }

        private CharacterDto MapToDTO(CharacterDto character)
        {
            var detections = _detectionRepository.GetDetectionsByCharacterId(character.Id);

            return new CharacterDto
            {
                Id = character.Id,
                CharacterName = character.CharacterName,
                Description = character.Description,
                ProfileImageUrl = character.ProfileImageUrl,
                CreatedDate = character.CreatedDate,
                TotalDetections = detections.Count
            };
        }

        public Task<List<CharacterDto>> SearchByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<CharacterDto>> GetTopDetectedAsync(int topCount)
        {
            throw new NotImplementedException();
        }

        public Task<Dictionary<string, object>> GetCharacterStatisticsAsync(int characterId)
        {
            throw new NotImplementedException();
        }

        public Task<List<CharacterDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CharacterDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CharacterDto> AddItemAsync(CharacterDto item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateItemAsync(int id, CharacterDto item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteItemAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}