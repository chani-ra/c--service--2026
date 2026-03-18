//c#-service-2026/Services/GalleryService.cs
using c__service_2026.Dto;
using c__service_2026.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;

namespace c__service_2026.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageService _imageRepository;
        private readonly IDetectedService _detectionRepository;

        public ImageService(IImageService imageRepository, IDetectedService detectionRepository)
        {
            _imageRepository = imageRepository;
            _detectionRepository = detectionRepository;
        }

        public List<ImageDto> GetAll()
        {
            return _imageRepository.GetAll().Select(MapToDTO).ToList();
        }

        public ImageDto Get(int id)
        {
            var image = _imageRepository.Get(id);
            return image == null ? null : MapToDTO(image);
        }

        public ImageDto AddItem(ImageDto item)
        {
            if (string.IsNullOrEmpty(item.Url))
                throw new ArgumentException("URL תמונה הוא שדה חובה");

            item.UploadedDate = DateTime.Now;
            var result = _imageRepository.AddItem(item);
            return MapToDTO(result);
        }

        public void UpdateItem(int id, ImageDto item)
        {
            var existing = _imageRepository.Get(id);
            if (existing == null) throw new Exception("תמונה לא נמצאה");

            existing.Url = item.Url;
            _imageRepository.UpdateItem(id, existing);
        }

        public void DeleteItem(int id)
        {
            _imageRepository.DeleteItem(id);
        }

        public List<ImageDto> GetByGallery(int galleryId)
        {
            return _imageRepository.GetImagesByGalleryId(galleryId).Select(MapToDTO).ToList();
        }

        public ImageDto GetWithDetections(int imageId)
        {
            var image = Get(imageId);
            // כאן אפשר להוסיף לוגיקה שמצרפת את הזיהויים הספציפיים לתמונה
            return image;
        }

        private ImageDto MapToDTO(ImageDto image)
        {
            return new ImageDto
            {
                Id = image.Id,
                Url = image.Url,
                GalleryId = image.GalleryId,
                UserId = image.UserId,
                UploadedDate = image.UploadedDate
            };
        }

        // מימושים נוספים מה-Interface
        public List<ImageDto> GetByUser(int userId) => _imageRepository.GetByUserId(userId).Select(MapToDTO).ToList();
        public List<ImageDto> GetUnprocessed() => _imageRepository.GetAll().Where(i => i.Id > 0).ToList(); // לוגיקה לדוגמה
        public bool MarkAsProcessed(int imageId) => true;

        public Task<List<ImageDto>> GetByGalleryAsync(int galleryId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ImageDto>> GetByUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ImageDto>> GetUnprocessedAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> MarkAsProcessedAsync(int imageId)
        {
            throw new NotImplementedException();
        }

        public Task<ImageDto> GetWithDetectionsAsync(int imageId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ImageDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ImageDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ImageDto> AddItemAsync(ImageDto item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateItemAsync(int id, ImageDto item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteItemAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}