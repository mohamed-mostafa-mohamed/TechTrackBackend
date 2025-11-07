using CMS.BL.Constants;
using CMS.BL.DTOs;
using CMS.BL.Extensions.MappingExtensions; 
using CMS.DAL.Models.Entities;
using CMS.DAL.Repo.compnay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.BL.Service.company
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _repo;

        public CompanyService(ICompanyRepository repo)
        {
            _repo = repo;
        }

       
        public async Task<IEnumerable<GetCompanyDto>> GetAllAsync()
        {
            try
            {
                var companies = await _repo.GetAllAsync();
                return companies.Select(c => c.ToGetDto()); 
            }
            catch (Exception)
            {
                throw new Exception(string.Format(ErrorMessages.GetAllFailed, EntityNames.Company));
            }
        }

       
        public async Task<GetCompanyDto?> GetByIdAsync(int id)
        {
            try
            {
                var company = await _repo.GetByIdAsync(id);
                if (company == null)
                    throw new Exception(string.Format(ErrorMessages.NotFound, EntityNames.Company, id));

                return company.ToGetDto(); 
            }
            catch (Exception)
            {
                throw new Exception(string.Format(ErrorMessages.GetByIdFailed, EntityNames.Company, id));
            }
        }

      
        public async Task<GetCompanyDto> CreateAsync(CreateCompanyDto dto)
        {
            try
            {
                var entity = dto.ToEntity(); 
                var created = await _repo.AddAsync(entity);
                return created.ToGetDto();   
            }
            catch (Exception)
            {
                throw new Exception(string.Format(ErrorMessages.CreateFailed, EntityNames.Company));
            }
        }

        
        public async Task<GetCompanyDto?> UpdateAsync(int id, CreateCompanyDto dto)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                if (existing == null)
                    throw new Exception(string.Format(ErrorMessages.NotFound, EntityNames.Company, id));

                existing.UpdateFromDto(dto); 
                var updated = await _repo.UpdateAsync(existing);

                return updated.ToGetDto();   
            }
            catch (Exception)
            {
                throw new Exception(string.Format(ErrorMessages.UpdateFailed, EntityNames.Company, id));
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var deleted = await _repo.DeleteAsync(id);
                if (!deleted)
                    throw new Exception(string.Format(ErrorMessages.NotFound, EntityNames.Company, id));

                return deleted;
            }
            catch (Exception)
            {
                throw new Exception(string.Format(ErrorMessages.DeleteFailed, EntityNames.Company, id));
            }
        }
    }
}
