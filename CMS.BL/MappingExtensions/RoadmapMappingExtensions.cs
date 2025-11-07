using CMS.BL.DTOs;
using CMS.DAL.Models.Entities;
using System.Linq;

namespace CMS.BL.Extensions.MappingExtensions
{
    public static class RoadmapMappingExtensions
    {
        public static Roadmap ToEntity(this RoadmapPostDto dto)
        {
            return new Roadmap
            {
                TrackId = dto.TrackId,
                Title = dto.Title,
                Description = dto.Description
            };
        }

        public static RoadmapGetDto ToGetDto(this Roadmap entity)
        {
            return new RoadmapGetDto
            {
                RoadmapId = entity.RoadmapId,
                TrackId = entity.TrackId,
                Title = entity.Title,
                Description = entity.Description,
                RoadmapSteps = entity.RoadmapSteps?
                    .Select(step => new RoadmapStepGetDto
                    {
                        RoadmapStepId = step.RoadmapStepId,
                        RoadmapId = step.RoadmapId,
                        StepTitle = step.StepTitle,
                        StepDescription = step.StepDescription,
                        StepOrder = step.StepOrder
                    })
                    .ToList()
            };
        }

        public static void UpdateFromDto(this Roadmap entity, RoadmapPostDto dto)
        {
            entity.TrackId = dto.TrackId;
            entity.Title = dto.Title;
            entity.Description = dto.Description;
        }
    }
}
