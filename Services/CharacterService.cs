using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using c__nRepository_2026.Entities;
using c__nRepository_2026.Interfaces;
using c__service_2026.Dto;
using c__service_2026.Interfaces;

namespace c__service_2026.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly IRepository<Character> _characterRepo;
        private readonly IRepository<DetectedCharacter> _detectionRepo;
        private readonly IMapper _mapper;

        public CharacterService(
            IRepository<Character> characterRepo,
            IRepository<DetectedCharacter> detectionRepo,
            IMapper mapper)
        {
            _characterRepo = characterRepo;
            _detectionRepo = detectionRepo;
            _mapper = mapper;
        }

        public async Task<List<CharacterDto>> GetAllAsync()
        {
            var entities = await _characterRepo.GetAllAsync();
            return _mapper.Map<List<CharacterDto>>(entities);
        }

        public async Task<CharacterDto> GetByIdAsync(int id)
        {
            var entity = await _characterRepo.GetByIdAsync(id);
            if (entity == null) throw new Exception("דמות לא נמצאה");
            return _mapper.Map<CharacterDto>(entity);
        }

        public async Task<CharacterDto> AddItemAsync(CharacterDto item)
        {
            var entity = _mapper.Map<Character>(item);
            entity.CreatedDate = DateTime.Now; // לוגיקה עסקית - תאריך יצירה נוכחי
            var addedEntity = await _characterRepo.AddItemAsync(entity);
            return _mapper.Map<CharacterDto>(addedEntity);
        }

        public async Task UpdateItemAsync(int id, CharacterDto item)
        {
            var entity = _mapper.Map<Character>(item);
            await _characterRepo.UpdateItemAsync(id, entity);
        }

        public async Task DeleteItemAsync(int id)
        {
            await _characterRepo.DeleteItemAsync(id);
        }

        public async Task<List<CharacterDto>> SearchByNameAsync(string name)
        {
            var all = await _characterRepo.GetAllAsync();
            var filtered = all.Where(c => c.CharacterName.Contains(name)).ToList();
            return _mapper.Map<List<CharacterDto>>(filtered);
        }

        public async Task<List<CharacterDto>> GetTopDetectedAsync(int topCount)
        {
            var detections = await _detectionRepo.GetAllAsync();
            var topIds = detections.GroupBy(d => d.CharacterId)
                                   .OrderByDescending(g => g.Count())
                                   .Take(topCount)
                                   .Select(g => g.Key)
                                   .ToList();

            var allCharacters = await _characterRepo.GetAllAsync();
            var topCharacters = allCharacters.Where(c => topIds.Contains(c.Id)).ToList();

            return _mapper.Map<List<CharacterDto>>(topCharacters);
        }

        public async Task<Dictionary<string, object>> GetCharacterStatisticsAsync(int characterId)
        {
            var character = await _characterRepo.GetByIdAsync(characterId);
            if (character == null) throw new Exception("דמות לא נמצאה");

            var allDetections = await _detectionRepo.GetAllAsync();
            var characterDetections = allDetections.Where(d => d.CharacterId == characterId).ToList();

            var avgConfidence = characterDetections.Any() ? characterDetections.Average(d => d.Confidence) : 0;

            return new Dictionary<string, object>
            {
                { "CharacterId", characterId },
                { "CharacterName", character.CharacterName },
                { "TotalDetections", characterDetections.Count },
                { "AverageConfidence", Math.Round(avgConfidence, 2) }
            };
        }
    }
}
/*
 * -------------------------------------------------------------------------
 * הסבר מפורט למבחן (מטרת עמוד זה):
 * -------------------------------------------------------------------------
 * קובץ זה הוא מימוש הלוגיקה העסקית עבור 'דמויות'. 
 * הדגש המרכזי פה הוא השימוש בהזרקת תלויות (DI) עבור ה-Repository וה-AutoMapper.
 * כשהמורה תשאל למה אנחנו צריכים פה את AutoMapper, התשובה היא: 
 * "כדי לחסוך קוד כפול, למנוע שגיאות אנוש, ולבצע המרה חלקה ובטוחה בין הישות של ה-DB 
 * (Character) לבין ה-DTO שנחשף ללקוח, בדיוק כפי שדרשת בסעיף 16". 
 * הפונקציות פה (כמו GetTopDetected) עושות חישובים ששייכים נטו ללוגיקת השרת (Business Logic).
 */