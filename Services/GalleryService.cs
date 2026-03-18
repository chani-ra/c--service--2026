//c#-service-2026/Services/GalleryService.cs 
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
    public class GalleryService : IGalleryService
    {
        private readonly IRepository<Gallery> _galleryRepo;
        private readonly IMapper _mapper;

        public GalleryService(IRepository<Gallery> galleryRepo, IMapper mapper)
        {
            _galleryRepo = galleryRepo;
            _mapper = mapper;
        }

        public async Task<List<GalleryDto>> GetAllAsync()
        {
            var entities = await _galleryRepo.GetAllAsync();
            return _mapper.Map<List<GalleryDto>>(entities);
        }

        public async Task<GalleryDto> GetByIdAsync(int id)
        {
            var entity = await _galleryRepo.GetByIdAsync(id);
            return _mapper.Map<GalleryDto>(entity);
        }

        public async Task<GalleryDto> AddItemAsync(GalleryDto item)
        {
            var entity = _mapper.Map<Gallery>(item);
            entity.CreatedDate = DateTime.Now;
            var added = await _galleryRepo.AddItemAsync(entity);
            return _mapper.Map<GalleryDto>(added);
        }

        public async Task UpdateItemAsync(int id, GalleryDto item)
        {
            var entity = _mapper.Map<Gallery>(item);
            await _galleryRepo.UpdateItemAsync(id, entity);
        }

        public async Task DeleteItemAsync(int id)
        {
            await _galleryRepo.DeleteItemAsync(id);
        }

        public async Task<List<GalleryDto>> GetByUserIdAsync(int userId)
        {
            var all = await _galleryRepo.GetAllAsync();
            var filtered = all.Where(g => g.UserId == userId).ToList();
            return _mapper.Map<List<GalleryDto>>(filtered);
        }

        public async Task<List<GalleryDto>> GetByCharacterIdAsync(int characterId)
        {
            var all = await _galleryRepo.GetAllAsync();
            var filtered = all.Where(g => g.CharacterId == characterId).ToList();
            return _mapper.Map<List<GalleryDto>>(filtered);
        }

        public async Task<GalleryDto> GetWithImagesAsync(int galleryId)
        {
            // בזכות ה-Include שעשינו ב-Repository, התמונות כבר מגיעות מחוברות!
            var entity = await _galleryRepo.GetByIdAsync(galleryId);
            return _mapper.Map<GalleryDto>(entity);
        }

        public async Task<Dictionary<string, object>> GetGalleryStatisticsAsync(int galleryId)
        {
            var gallery = await _galleryRepo.GetByIdAsync(galleryId);
            if (gallery == null) throw new Exception("גלריה לא נמצאה");

            return new Dictionary<string, object>
            {
                { "GalleryId", gallery.Id },
                { "GalleryName", gallery.Name },
                { "TotalImages", gallery.Images?.Count ?? 0 }
            };
        }
    }
}
/*
 * -------------------------------------------------------------------------
 * הסבר מפורט למבחן:
 * -------------------------------------------------------------------------
 * שירות לניהול הגלריות. 
 * הנקודה החזקה כאן (לציון 100) היא הפונקציה GetWithImagesAsync. בגלל שבשכבת 
 * ה-Repository (GalleryRepository) כתבנו Include(g => g.Images), יש לנו Eager Loading.
 * המשמעות היא שה-Entity חוזר מהמסד עם כל התמונות שלו כבר טעונות. ה-AutoMapper מספיק 
 * חכם כדי לראות שיש רשימה של Images ב-Entity, ולהמיר אותה אוטומטית לרשימה של ImageDto 
 * שנמצאת בתוך ה-GalleryDto. זה קסם של כתיבת קוד נכון!
 */