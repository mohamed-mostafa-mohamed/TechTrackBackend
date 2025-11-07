using CMS.BL.Constants;
using CMS.BL.DTOs;
using CMS.BL.Extensions.MappingExtensions;
using CMS.DAL.Models.Entities;
using CMS.DAL.Repo.subcategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.BL.Service.subcategory
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _repo;

        public SubCategoryService(ISubCategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<SubCategoryGetDto>> GetAllAsync()
        {
            try
            {
                var subCategories = await _repo.GetAllAsync();
                return subCategories.Select(sc => sc.ToGetDto());
            }
            catch (Exception)
            {
                throw new ApplicationException(string.Format(ErrorMessages.GetAllFailed, EntityNames.SubCategory));
            }
        }

        public async Task<SubCategoryGetDto?> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _repo.GetByIdAsync(id);
                if (entity == null)
                    throw new ApplicationException(string.Format(ErrorMessages.NotFound, EntityNames.SubCategory, id));

                return entity.ToGetDto();
            }
            catch (Exception)
            {
                throw new ApplicationException(string.Format(ErrorMessages.GetByIdFailed, EntityNames.SubCategory, id));
            }
        }

        public async Task<SubCategoryGetDto> AddAsync(SubCategoryPostDto dto)
        {
            try
            {
                var entity = dto.ToEntity();
                var added = await _repo.AddAsync(entity);
                return added.ToGetDto();
            }
            catch (Exception)
            {
                throw new ApplicationException(string.Format(ErrorMessages.CreateFailed, EntityNames.SubCategory));
            }
        }

        public async Task<SubCategoryGetDto?> UpdateAsync(int id, SubCategoryPostDto dto)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                if (existing == null)
                    throw new ApplicationException(string.Format(ErrorMessages.NotFound, EntityNames.SubCategory, id));

                existing.UpdateFromDto(dto);
                var updated = await _repo.UpdateAsync(existing);
                return updated.ToGetDto();
            }
            catch (Exception)
            {
                throw new ApplicationException(string.Format(ErrorMessages.UpdateFailed, EntityNames.SubCategory, id));
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var deleted = await _repo.DeleteAsync(id);
                if (!deleted)
                    throw new ApplicationException(string.Format(ErrorMessages.NotFound, EntityNames.SubCategory, id));

                return deleted;
            }
            catch (Exception)
            {
                throw new ApplicationException(string.Format(ErrorMessages.DeleteFailed, EntityNames.SubCategory, id));
            }
        }
    }
}
