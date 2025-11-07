using CMS.BL.DTOs;
using CMS.DAL.Models.Entities;

namespace CMS.BL.Extensions.MappingExtensions
{
    public static class MappingExtensions
    {
        // Existing methods
        public static Category ToEntity(this CategoryPostDto dto)
        {
            return new Category
            {
                CategoryName = dto.Name,
                Description = dto.Description
            };
        }

        public static CategoryGetDto ToGetDto(this Category entity)
        {
            return new CategoryGetDto
            {
                CategoryId = entity.CategoryId,
                CategoryName = entity.CategoryName,
                Description = entity.Description
            };
        }

        // ✅ NEW: Update existing entity from DTO (no manual mapping in service)
        public static void UpdateFromDto(this Category entity, CategoryPostDto dto)
        {
            entity.CategoryName = dto.Name;
            entity.Description = dto.Description;
        }
    }
}
