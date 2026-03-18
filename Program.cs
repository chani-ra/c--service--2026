//c#-service-2026/Program.cs
using c__repository_2026.c__service_2026.Dto;
using c__repository_2026.c__service_2026.Interfaces;
using c__repository_2026.c__service_2026.Services;
using Service.Interfaces;

builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<IGalleryService, GalleryService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IDetectedService, DetectedCharacterService>();