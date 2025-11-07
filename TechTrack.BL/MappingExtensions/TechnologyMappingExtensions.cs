using CMS.BL.DTOs;
using CMS.DAL.Models.Entities;

namespace CMS.BL.Extensions.MappingExtensions
{
    public static class TechnologyMappingExtensions
    {
        public static Technology ToEntity(this TechnologyPostDto dto)
        {
            return new Technology
            {
                TechnologyName = dto.TechnologyName,
                Description = dto.Description ?? "",
                VideoUrl = dto.VideoUrl,
                TrackId = dto.TrackId,
                CreatedAt = DateTime.UtcNow
            };
        }

        public static TechnologyGetDto ToGetDto(this Technology entity)
        {
            return new TechnologyGetDto
            {
                TechnologyId = entity.TechnologyId,
                TechnologyName = entity.TechnologyName,
                Description = entity.Description,
                VideoUrl = entity.VideoUrl,
                TrackId = entity.TrackId,
                CreatedAt = entity.CreatedAt
            };
        }

        public static void UpdateFromDto(this Technology entity, TechnologyPostDto dto)
        {
            entity.TechnologyName = dto.TechnologyName;
            entity.Description = dto.Description ?? "";
            entity.VideoUrl = dto.VideoUrl;
            entity.TrackId = dto.TrackId;
            // Keep CreatedAt unchanged
        }
    }
}
