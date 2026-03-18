//c#-service-2026/Services/DetectedCharacterService.cs
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
    public class DetectedCharacterService : IDetectionService
    {
        private readonly IRepository<DetectedCharacter> _detectionRepo;
        private readonly IMapper _mapper;

        public DetectedCharacterService(IRepository<DetectedCharacter> detectionRepo, IMapper mapper)
        {
            _detectionRepo = detectionRepo;
            _mapper = mapper;
        }

        public async Task<List<DetectedCharacterDto>> GetAllAsync()
        {
            var entities = await _detectionRepo.GetAllAsync();
            return _mapper.Map<List<DetectedCharacterDto>>(entities);
        }

        public async Task<DetectedCharacterDto> GetByIdAsync(int id)
        {
            var entity = await _detectionRepo.GetByIdAsync(id);
            return _mapper.Map<DetectedCharacterDto>(entity);
        }

        public async Task<DetectedCharacterDto> AddItemAsync(DetectedCharacterDto item)
        {
            var entity = _mapper.Map<DetectedCharacter>(item);
            entity.DetectionDate = DateTime.Now;
            var added = await _detectionRepo.AddItemAsync(entity);
            return _mapper.Map<DetectedCharacterDto>(added);
        }

        public async Task UpdateItemAsync(int id, DetectedCharacterDto item)
        {
            var entity = _mapper.Map<DetectedCharacter>(item);
            await _detectionRepo.UpdateItemAsync(id, entity);
        }

        public async Task DeleteItemAsync(int id)
        {
            await _detectionRepo.DeleteItemAsync(id);
        }

        public async Task<List<DetectedCharacterDto>> GetByImageIdAsync(int imageId)
        {
            var all = await _detectionRepo.GetAllAsync();
            var filtered = all.Where(d => d.ImageId == imageId).ToList();
            return _mapper.Map<List<DetectedCharacterDto>>(filtered);
        }

        public async Task<List<DetectedCharacterDto>> GetByCharacterIdAsync(int characterId)
        {
            var all = await _detectionRepo.GetAllAsync();
            var filtered = all.Where(d => d.CharacterId == characterId).ToList();
            return _mapper.Map<List<DetectedCharacterDto>>(filtered);
        }

        public async Task<List<DetectedCharacterDto>> GetHighConfidenceAsync(double minConfidence)
        {
            var all = await _detectionRepo.GetAllAsync();
            var filtered = all.Where(d => d.Confidence >= minConfidence).ToList();
            return _mapper.Map<List<DetectedCharacterDto>>(filtered);
        }

        public async Task<Dictionary<string, object>> GetDetectionStatisticsAsync()
        {
            var all = await _detectionRepo.GetAllAsync();
            return new Dictionary<string, object>
            {
                { "TotalDetections", all.Count },
                { "AverageConfidence", all.Any() ? Math.Round(all.Average(d => d.Confidence), 2) : 0 },
                { "SuccessRateCount", all.Count(d => d.Confidence > 0.8) } // מניחים שמעל 0.8 זה זיהוי מוצלח
            };
        }
    }
}
/*
 * -------------------------------------------------------------------------
 * הסבר מפורט למבחן:
 * -------------------------------------------------------------------------
 * שירות זה אחראי על טבלת הזיהויים המחברת בין התמונה לדמות.
 * גם כאן הכל א-סינכרוני. שימי לב לפונקציה GetHighConfidenceAsync - היא מדגימה 
 * שימוש בלוגיקה (LINQ - Where) כדי לסנן נתונים לפני המרתם ל-DTO והחזרתם ללקוח. 
 * המטרה היא להוריד עומס מעיבוד הנתונים בדפדפן, ולבצע את הסינון הכבד בשרת.
 */