using CMS.BL.Constants;
using CMS.BL.DTOs;
using CMS.BL.Extensions.MappingExtensions;
using CMS.DAL.Repo.technology;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.BL.Service.technology
{
    public class TechnologyService : ITechnologyService
    {
        private readonly ITechnologyRepository _repo;

        public TechnologyService(ITechnologyRepository repo)
        {
            _repo = repo;
        }

        
        public async Task<IEnumerable<TechnologyGetDto>> GetAllAsync()
        {
            try
            {
                var technologies = await _repo.GetAllAsync();
                return technologies.Select(t => t.ToGetDto());
            }
            catch (Exception)
            {
                throw new ApplicationException(string.Format(ErrorMessages.GetAllFailed, EntityNames.Technology));
            }
        }

    
        public async Task<TechnologyGetDto?> GetByIdAsync(int id)
        {
            try
            {
                var tech = await _repo.GetByIdAsync(id);
                if (tech == null)
                    throw new ApplicationException(string.Format(ErrorMessages.NotFound, EntityNames.Technology, id));

                return tech.ToGetDto();
            }
            catch (Exception)
            {
                throw new ApplicationException(string.Format(ErrorMessages.GetByIdFailed, EntityNames.Technology, id));
            }
        }

        
        public async Task<TechnologyGetDto> AddAsync(TechnologyPostDto dto)
        {
            try
            {
                var entity = dto.ToEntity();
                var created = await _repo.AddAsync(entity);
                return created.ToGetDto();
            }
            catch (Exception)
            {
                throw new ApplicationException(string.Format(ErrorMessages.CreateFailed, EntityNames.Technology));
            }
        }

        public async Task<TechnologyGetDto?> UpdateAsync(int id, TechnologyPostDto dto)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                if (existing == null)
                    throw new ApplicationException(string.Format(ErrorMessages.NotFound, EntityNames.Technology, id));

                existing.UpdateFromDto(dto);
                var updated = await _repo.UpdateAsync(existing);

                return updated.ToGetDto();
            }
            catch (Exception)
            {
                throw new ApplicationException(string.Format(ErrorMessages.UpdateFailed, EntityNames.Technology, id));
            }
        }

        
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var deleted = await _repo.DeleteAsync(id);
                if (!deleted)
                    throw new ApplicationException(string.Format(ErrorMessages.NotFound, EntityNames.Technology, id));

                return deleted;
            }
            catch (Exception)
            {
                throw new ApplicationException(string.Format(ErrorMessages.DeleteFailed, EntityNames.Technology, id));
            }
        }
    }
}
