using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.BL.DTOs;
using CMS.DAL.Models.Entities;
using System;

namespace CMS.BL.Extensions.MappingExtensions
{
    public static class TrackMappingExtensions
    {
      
        public static Track ToEntity(this TrackPostDto dto)
        {
            return new Track
            {
                TrackName = dto.TrackName,
                Description = dto.Description,
                DifficultyLevel = dto.DifficultyLevel,
                EstimatedDuration = dto.EstimatedDuration,
                SubCategoryId = dto.SubCategoryId
            };
        }

        
        public static TrackGetDto ToGetDto(this Track entity)
        {
            return new TrackGetDto
            {
                TrackId = entity.TrackId,
                TrackName = entity.TrackName,
                Description = entity.Description,
                DifficultyLevel = entity.DifficultyLevel,
                EstimatedDuration = entity.EstimatedDuration,
                SubCategoryId = entity.SubCategoryId
            };
        }

       
        public static void UpdateFromDto(this Track entity, TrackPostDto dto)
        {
            entity.TrackName = dto.TrackName;
            entity.Description = dto.Description;
            entity.DifficultyLevel = dto.DifficultyLevel;
            entity.EstimatedDuration = dto.EstimatedDuration;
            entity.SubCategoryId = dto.SubCategoryId;
        }
    }
}
