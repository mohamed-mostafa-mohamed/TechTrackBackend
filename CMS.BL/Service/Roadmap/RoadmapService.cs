using CMS.BL.Constants;
using CMS.BL.DTOs;
using CMS.BL.Extensions.MappingExtensions;
using CMS.DAL.Repo.roadmap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.BL.Service.roadmap
{
    public class RoadmapService : IRoadmapService
    {
        private readonly IRoadmapRepository _repo;

        public RoadmapService(IRoadmapRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<RoadmapGetDto>> GetAllAsync()
        {
            try
            {
                var roadmaps = await _repo.GetAllAsync();
                return roadmaps.Select(r => r.ToGetDto());
            }
            catch (Exception)
            {
                throw new ApplicationException(string.Format(ErrorMessages.GetAllFailed, EntityNames.Roadmap));
            }
        }

        public async Task<RoadmapGetDto?> GetByIdAsync(int id)
        {
            try
            {
                var roadmap = await _repo.GetByIdAsync(id);
                if (roadmap == null)
                    throw new ApplicationException(string.Format(ErrorMessages.NotFound, EntityNames.Roadmap, id));

                return roadmap.ToGetDto();
            }
            catch (Exception)
            {
                throw new ApplicationException(string.Format(ErrorMessages.GetByIdFailed, EntityNames.Roadmap, id));
            }
        }

        public async Task<RoadmapGetDto> AddAsync(RoadmapPostDto dto)
        {
            try
            {
                var entity = dto.ToEntity();
                var added = await _repo.AddAsync(entity);
                return added.ToGetDto();
            }
            catch (Exception)
            {
                throw new ApplicationException(string.Format(ErrorMessages.CreateFailed, EntityNames.Roadmap));
            }
        }

        public async Task<RoadmapGetDto?> UpdateAsync(int id, RoadmapPostDto dto)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                if (existing == null)
                    throw new ApplicationException(string.Format(ErrorMessages.NotFound, EntityNames.Roadmap, id));

                existing.UpdateFromDto(dto);
                var updated = await _repo.UpdateAsync(existing);
                return updated.ToGetDto();
            }
            catch (Exception)
            {
                throw new ApplicationException(string.Format(ErrorMessages.UpdateFailed, EntityNames.Roadmap, id));
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var deleted = await _repo.DeleteAsync(id);
                if (!deleted)
                    throw new ApplicationException(string.Format(ErrorMessages.NotFound, EntityNames.Roadmap, id));

                return deleted;
            }
            catch (Exception)
            {
                throw new ApplicationException(string.Format(ErrorMessages.DeleteFailed, EntityNames.Roadmap, id));
            }
        }
    }
}
