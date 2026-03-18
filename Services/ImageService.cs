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
    public class ImageService : IImageService
    {
        private readonly IRepository<Image> _imageRepo;
        private readonly IMapper _mapper;

        public ImageService(IRepository<Image> imageRepo, IMapper mapper)
        {
            _imageRepo = imageRepo;
            _mapper = mapper;
        }

        public async Task<List<ImageDto>> GetAllAsync()
        {
            var entities = await _imageRepo.GetAllAsync();
            return _mapper.Map<List<ImageDto>>(entities);
        }

        public async Task<ImageDto> GetByIdAsync(int id)
        {
            var entity = await _imageRepo.GetByIdAsync(id);
            return _mapper.Map<ImageDto>(entity);
        }

        public async Task<ImageDto> AddItemAsync(ImageDto item)
        {
            var entity = _mapper.Map<Image>(item);
            var added = await _imageRepo.AddItemAsync(entity);
            return _mapper.Map<ImageDto>(added);
        }

        public async Task UpdateItemAsync(int id, ImageDto item)
        {
            var entity = _mapper.Map<Image>(item);
            await _imageRepo.UpdateItemAsync(id, entity);
        }

        public async Task DeleteItemAsync(int id)
        {
            await _imageRepo.DeleteItemAsync(id);
        }

        public async Task<List<ImageDto>> GetByGalleryIdAsync(int galleryId)
        {
            var all = await _imageRepo.GetAllAsync();
            var filtered = all.Where(i => i.GalleryId == galleryId).ToList();
            return _mapper.Map<List<ImageDto>>(filtered);
        }

        public async Task<List<ImageDto>> GetByUserIdAsync(int userId)
        {
            var all = await _imageRepo.GetAllAsync();
            var filtered = all.Where(i => i.UserId == userId).ToList();
            return _mapper.Map<List<ImageDto>>(filtered);
        }

        public async Task<List<ImageDto>> GetUnprocessedAsync()
        {
            // לוגיקה שמחזירה תמונות שעדיין אין להן זיהויים כלל (לא עובדו)
            var all = await _imageRepo.GetAllAsync();
            var unprocessed = all.Where(i => i.DetectedCharacters == null || !i.DetectedCharacters.Any()).ToList();
            return _mapper.Map<List<ImageDto>>(unprocessed);
        }

        public async Task<bool> MarkAsProcessedAsync(int imageId)
        {
            // פונקציית דמה - במערכת אמיתית פה היינו מעדכנים סטטוס עיבוד
            return await Task.FromResult(true);
        }

        public async Task<ImageDto> GetWithDetectionsAsync(int imageId)
        {
            var entity = await _imageRepo.GetByIdAsync(imageId);
            return _mapper.Map<ImageDto>(entity);
        }
    }
}
/*
 * -------------------------------------------------------------------------
 * הסבר מפורט למבחן:
 * -------------------------------------------------------------------------
 * שירות לתמונות שכולל לוגיקה מעניינת כמו 'GetUnprocessedAsync'. 
 * פונקציה זו בודקת אילו תמונות הועלו ועדיין ה-Collection של ה-DetectedCharacters 
 * שלהן ריק, כלומר מנוע הזיהוי עוד לא עבר עליהן. 
 * שימי לב שוב לחסכון העצום בקוד: פונקציות העדכון וההוספה משתמשות בשורה אחת 
 * של _mapper.Map כדי להמיר את הנתונים, מה שעושה את הקוד נקי מאוד וקריא 
 * בדיוק כמו שפרויקט בשיטת השכבות (N-Tier Architecture) צריך להיות.
 */