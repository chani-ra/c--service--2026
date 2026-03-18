         // ה-Entities מה-DB
using c__service_2026.Interfaces;         // ה-Repositories שלך
using c__service_2026.Dto;

namespace c__service_2026.Services
{
    public class GalleryService : IGalleryService
    {
        private readonly IGalleryService _galleryRepository;
        private readonly IImageService _imageRepository;
        private readonly ICharacterService _characterRepository;
        private readonly IDetectedService _detectionRepository;

        public GalleryService(
            IGalleryService galleryRepository,
            IImageService imageRepository,
            ICharacterService characterRepository,
            IDetectedService detectionRepository)
        {
            _galleryRepository = galleryRepository;
            _imageRepository = imageRepository;
            _characterRepository = characterRepository;
            _detectionRepository = detectionRepository;
        }

        public List<GalleryDto> GetAll()
        {
            var galleries = _galleryRepository.GetAll();
            return galleries.Select(MapToDTO).ToList();
        }

        public GalleryDto Get(int id)
        {
            var gallery = _galleryRepository.Get(id);
            return gallery == null ? null : MapToDTO(gallery);
        }

        public GalleryDto AddItem(GalleryDto item)
        {
            if (string.IsNullOrWhiteSpace(item.Name))
                throw new ArgumentException("שם הגלריה חובה");

            var gallery = new GalleryDto
            {
                Name = item.Name,
                Description = item.Description,
                CharacterId = item.CharacterId,
                UserId = item.UserId,
                CreatedDate = DateTime.Now
            };

            var result = _galleryRepository.AddItem(gallery);
            return MapToDTO(result);
        }

        public void UpdateItem(int id, GalleryDto item)
        {
            if (string.IsNullOrWhiteSpace(item.Name))
                throw new ArgumentException("שם הגלריה חובה");

            var gallery = _galleryRepository.Get(id);
            if (gallery == null)
                throw new ArgumentException("גלריה לא נמצאה");

            gallery.Name = item.Name;
            gallery.Description = item.Description;
            gallery.CharacterId = item.CharacterId;

            _galleryRepository.UpdateItem(id, gallery);
        }

        public void DeleteItem(int id)
        {
            var gallery = _galleryRepository.Get(id);
            if (gallery == null)
                throw new ArgumentException("גלריה לא נמצאה");

            _galleryRepository.DeleteItem(id);
        }

        public List<GalleryDto> GetByUser(int userId)
        {
            var galleries = _galleryRepository.GetGalleriesByUserId(userId);
            return galleries.Select(MapToDTO).ToList();
        }

        public List<GalleryDto> GetByCharacter(int characterId)
        {
            var galleries = _galleryRepository.GetGalleriesByCharacterId(characterId);
            return galleries.Select(MapToDTO).ToList();
        }

        public GalleryDto GetWithImages(int galleryId)
        {
            var gallery = _galleryRepository.Get(galleryId);
            return gallery == null ? null : MapToDTO(gallery);
        }

        public Dictionary<string, object> GetGalleryStatistics(int galleryId)
        {
            var gallery = _galleryRepository.Get(galleryId);
            if (gallery == null)
                throw new ArgumentException("גלריה לא נמצאה");

            var images = _imageRepository.GetImagesByGalleryId(galleryId);
            var totalDetections = 0;
            var avgConfidence = 0.0;

            foreach (var image in images)
            {
                var detections = _detectionRepository.GetDetectionsByImageId(image.Id);
                totalDetections += detections.Count;
                if (detections.Count > 0)
                    avgConfidence += detections.Average(d => d.Confidence);
            }

            avgConfidence = images.Count > 0 ? avgConfidence / images.Count : 0;

            return new Dictionary<string, object>
            {
                { "GalleryId", galleryId },
                { "GalleryName", gallery.Name },
                { "TotalImages", images.Count },
                { "TotalDetections", totalDetections },
                { "AverageConfidence", Math.Round(avgConfidence, 2) }
            };
        }

        private GalleryDto MapToDTO(GalleryDto gallery)
        {
            var images = _imageRepository.GetImagesByGalleryId(gallery.Id);
            var character = _characterRepository.Get(gallery.CharacterId);

            return new GalleryDto
            {
                Id = gallery.Id,
                Name = gallery.Name,
                Description = gallery.Description,
                CharacterId = gallery.CharacterId,
                CharacterName = character?.CharacterName ?? "Unknown",
                UserId = gallery.UserId,
                CreatedDate = gallery.CreatedDate,
                ImageCount = images.Count,
                Images = images.Select(MapImageToDTO).ToList()
            };
        }

        private ImageDto MapImageToDTO(ImageDto image)
        {
            var detections = _detectionRepository.GetDetectionsByImageId(image.Id);

            return new ImageDto
            {
                Id = image.Id,
                Url = image.Url,
                GalleryId = image.GalleryId,
                UserId = image.UserId,
                UploadDate = image.UploadDate,
                IsProcessed = image.IsProcessed,
                DetectionCount = detections.Count,
                Detections = detections.Select(MapDetectionToDTO).ToList()
            };
        }

        private DetectedCharacterDto MapDetectionToDTO(DetectedCharacterDto detection)
        {
            var character = _characterRepository.Get(detection.CharacterId);

            return new DetectedCharacterDto
            {
                Id = detection.Id,
                ImageId = detection.ImageId,
                CharacterId = detection.CharacterId,
                CharacterName = character?.CharacterName ?? "Unknown",
                Confidence = detection.Confidence,
                FaceCoordinates = detection.FaceCoordinates,
                DetectionDate = detection.DetectionDate,
                ModelUsed = detection.ModelUsed
            };
        }

        public Task<List<GalleryDto>> GetByUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<GalleryDto>> GetByCharacterAsync(int characterId)
        {
            throw new NotImplementedException();
        }

        public Task<GalleryDto> GetWithImagesAsync(int galleryId)
        {
            throw new NotImplementedException();
        }

        public Task<Dictionary<string, object>> GetGalleryStatisticsAsync(int galleryId)
        {
            throw new NotImplementedException();
        }

        public Task<List<GalleryDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GalleryDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GalleryDto> AddItemAsync(GalleryDto item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateItemAsync(int id, GalleryDto item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteItemAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}