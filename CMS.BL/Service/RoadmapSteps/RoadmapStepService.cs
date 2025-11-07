using CMS.BL.Constants;
using CMS.BL.DTOs;
using CMS.BL.Extensions.MappingExtensions;
using CMS.BL.Service.roadmastep;
using CMS.DAL.Models.Entities;
using CMS.DAL.Repo.roadmapstep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.BL.Service.roadmastep
{
    public class RoadmapStepService : IRoadmapStepService
    {
        private readonly IRoadmapStepRepository _repo;

        public RoadmapStepService(IRoadmapStepRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<RoadmapStepGetDto>> GetAllAsync()
        {
            try
            {
                var steps = await _repo.GetAllAsync();
                return steps.Select(s => s.ToGetDto());
            }
            catch (Exception)
            {
                throw new ApplicationException(string.Format(ErrorMessages.GetAllFailed, EntityNames.RoadmapStep));
            }
        }

        public async Task<RoadmapStepGetDto?> GetByIdAsync(int id)
        {
            try
            {
                var step = await _repo.GetByIdAsync(id);
                if (step == null)
                    throw new ApplicationException(string.Format(ErrorMessages.NotFound, EntityNames.RoadmapStep, id));

                return step.ToGetDto();
            }
            catch (Exception)
            {
                throw new ApplicationException(string.Format(ErrorMessages.GetByIdFailed, EntityNames.RoadmapStep, id));
            }
        }

        public async Task<RoadmapStepGetDto> AddAsync(RoadmapStepPostDto dto)
        {
            try
            {
                var entity = dto.ToEntity();
                var added = await _repo.AddAsync(entity);
                return added.ToGetDto();
            }
            catch (Exception)
            {
                throw new ApplicationException(string.Format(ErrorMessages.CreateFailed, EntityNames.RoadmapStep));
            }
        }

        public async Task<RoadmapStepGetDto?> UpdateAsync(int id, RoadmapStepPostDto dto)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                if (existing == null)
                    throw new ApplicationException(string.Format(ErrorMessages.NotFound, EntityNames.RoadmapStep, id));

                existing.UpdateFromDto(dto);
                var updated = await _repo.UpdateAsync(existing);

                return updated.ToGetDto();
            }
            catch (Exception)
            {
                throw new ApplicationException(string.Format(ErrorMessages.UpdateFailed, EntityNames.RoadmapStep, id));
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var deleted = await _repo.DeleteAsync(id);
                if (!deleted)
                    throw new ApplicationException(string.Format(ErrorMessages.NotFound, EntityNames.RoadmapStep, id));

                return deleted;
            }
            catch (Exception)
            {
                throw new ApplicationException(string.Format(ErrorMessages.DeleteFailed, EntityNames.RoadmapStep, id));
            }
        }
    }
}
