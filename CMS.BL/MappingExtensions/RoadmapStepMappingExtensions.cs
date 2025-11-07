
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.BL.DTOs;
using CMS.DAL.Models.Entities;

namespace CMS.BL.Extensions.MappingExtensions
{
    public static class RoadmapStepMappingExtensions
    {
        public static RoadmapStep ToEntity(this RoadmapStepPostDto dto)
        {
            return new RoadmapStep
            {
                RoadmapId = dto.RoadmapId,
                StepTitle = dto.StepTitle,
                StepDescription = dto.StepDescription,
                StepOrder = dto.StepOrder
            };
        }

        public static RoadmapStepGetDto ToGetDto(this RoadmapStep entity)
        {
            return new RoadmapStepGetDto
            {
                RoadmapStepId = entity.RoadmapStepId,
                RoadmapId = entity.RoadmapId,
                StepTitle = entity.StepTitle,
                StepDescription = entity.StepDescription,
                StepOrder = entity.StepOrder
            };
        }

        public static void UpdateFromDto(this RoadmapStep entity, RoadmapStepPostDto dto)
        {
            entity.RoadmapId = dto.RoadmapId;
            entity.StepTitle = dto.StepTitle;
            entity.StepDescription = dto.StepDescription;
            entity.StepOrder = dto.StepOrder;
        }
    }
}
