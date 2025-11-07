using CMS.BL.Constants;
using CMS.BL.DTOs;
using CMS.BL.Extensions.MappingExtensions;
using CMS.DAL.Models.Entities;
using CMS.DAL.Repo.category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.BL.Service.category
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }

    
        public async Task<IEnumerable<CategoryGetDto>> GetAllCategoriesAsync()
        {
            try
            {
                var categories = await _repo.GetAllAsync();
                return categories.Select(c => c.ToGetDto()); 
            }
            catch (Exception)
            {
                throw new Exception(string.Format(ErrorMessages.GetAllFailed, EntityNames.Category));
            }
        }

        public async Task<CategoryGetDto?> GetCategoryByIdAsync(int id)
        {
            try
            {
                var category = await _repo.GetByIdAsync(id);
                if (category == null)
                    throw new Exception(string.Format(ErrorMessages.NotFound, EntityNames.Category, id));

                return category.ToGetDto();
            }
            catch (Exception)
            {
                throw new Exception(string.Format(ErrorMessages.GetByIdFailed, EntityNames.Category, id));
            }
        }

        
        public async Task<CategoryGetDto> CreateCategoryAsync(CategoryPostDto dto)
        {
            try
            {
                var entity = dto.ToEntity();               
                var created = await _repo.AddAsync(entity);
                return created.ToGetDto();                 
            }
            catch (Exception)
            {
                throw new Exception(string.Format(ErrorMessages.CreateFailed, EntityNames.Category));
            }
        }

        
        public async Task<CategoryGetDto?> UpdateCategoryAsync(int id, CategoryPostDto dto)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                if (existing == null)
                    throw new Exception(string.Format(ErrorMessages.NotFound, EntityNames.Category, id));

                existing.UpdateFromDto(dto);              
                var updated = await _repo.UpdateAsync(existing);

                return updated.ToGetDto();                
            }
            catch (Exception)
            {
                throw new Exception(string.Format(ErrorMessages.UpdateFailed, EntityNames.Category, id));
            }
        }

       
        public async Task<bool> DeleteCategoryAsync(int id)
        {
            try
            {
                var deleted = await _repo.DeleteAsync(id);
                if (!deleted)
                    throw new Exception(string.Format(ErrorMessages.NotFound, EntityNames.Category, id));

                return deleted;
            }
            catch (Exception)
            {
                throw new Exception(string.Format(ErrorMessages.DeleteFailed, EntityNames.Category, id));
            }
        }
    }
}
