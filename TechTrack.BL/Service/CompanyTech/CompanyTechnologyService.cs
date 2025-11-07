using CMS.BL.Constants;
using CMS.BL.DTOs;
using CMS.BL.Extensions.MappingExtensions;
using CMS.DAL.Models.Entities;
using CMS.DAL.Repo.companytech;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.BL.Service.companytech
{
    public class CompanyTechnologyService : ICompanyTechnologyService
    {
        private readonly ICompanyTechnologyRepository _repo;

        public CompanyTechnologyService(ICompanyTechnologyRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<GetCompanyTechnologyDto>> GetAllAsync()
        {
            try
            {
                var list = await _repo.GetAllAsync();
                return list.Select(ct => ct.ToGetDto());
            }
            catch (Exception)
            {
                throw new ApplicationException(string.Format(ErrorMessages.GetAllFailed, EntityNames.CompanyTech));
            }
        }

        public async Task<GetCompanyTechnologyDto?> GetByIdAsync(int id)
        {
            try
            {
                var ct = await _repo.GetByIdAsync(id);
                if (ct == null)
                    throw new ApplicationException(string.Format(ErrorMessages.NotFound, EntityNames.CompanyTech, id));

                return ct.ToGetDto();
            }
            catch (Exception)
            {
                throw new ApplicationException(string.Format(ErrorMessages.GetByIdFailed, EntityNames.CompanyTech, id));
            }
        }

        public async Task<GetCompanyTechnologyDto> CreateAsync(CreateCompanyTechnologyDto dto)
        {
            try
            {
                var entity = dto.ToEntity();
                var created = await _repo.AddAsync(entity);
                return created.ToGetDto();
            }
            catch (Exception)
            {
                throw new ApplicationException(string.Format(ErrorMessages.CreateFailed, EntityNames.CompanyTech));
            }
        }

        public async Task<GetCompanyTechnologyDto?> UpdateAsync(int id, CreateCompanyTechnologyDto dto)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                if (existing == null)
                    throw new ApplicationException(string.Format(ErrorMessages.NotFound, EntityNames.CompanyTech, id));

                existing.UpdateFromDto(dto);
                var updated = await _repo.UpdateAsync(existing);
                return updated.ToGetDto();
            }
            catch (Exception)
            {
                throw new ApplicationException(string.Format(ErrorMessages.UpdateFailed, EntityNames.CompanyTech, id));
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var deleted = await _repo.DeleteAsync(id);
                if (!deleted)
                    throw new ApplicationException(string.Format(ErrorMessages.NotFound, EntityNames.CompanyTech, id));

                return deleted;
            }
            catch (Exception)
            {
                throw new ApplicationException(string.Format(ErrorMessages.DeleteFailed, EntityNames.CompanyTech, id));
            }
        }
    }
}
