using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.BL.DTOs;
using CMS.DAL.Models.Entities;

namespace CMS.BL.Extensions.MappingExtensions
{
    public static class SubCategoryMappingExtensions
    {
        public static SubCategory ToEntity(this SubCategoryPostDto dto)
        {
            return new SubCategory
            {
                SubCategoryName = dto.SubCategoryName,
                Description = dto.Description,
                DifficultyLevel = dto.DifficultyLevel,
                EstimatedDuration = dto.EstimatedDuration,
                CategoryId = dto.CategoryId
            };
        }

        public static SubCategoryGetDto ToGetDto(this SubCategory entity)
        {
            return new SubCategoryGetDto
            {
                SubCategoryId = entity.SubCategoryId,
                SubCategoryName = entity.SubCategoryName,
                Description = entity.Description,
                DifficultyLevel = entity.DifficultyLevel,
                EstimatedDuration = entity.EstimatedDuration,
                CategoryId = entity.CategoryId
            };
        }

        public static void UpdateFromDto(this SubCategory entity, SubCategoryPostDto dto)
        {
            entity.SubCategoryName = dto.SubCategoryName;
            entity.Description = dto.Description;
            entity.DifficultyLevel = dto.DifficultyLevel;
            entity.EstimatedDuration = dto.EstimatedDuration;
            entity.CategoryId = dto.CategoryId;
        }
    }
}
