using CMS.BL.DTOs;
using CMS.DAL.Models.Entities;
using CMS.DAL.Repo.category;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace CMS.BL.Service.category
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryGetDto>> GetAllCategoriesAsync();
        Task<CategoryGetDto?> GetCategoryByIdAsync(int id);
        Task<CategoryGetDto> CreateCategoryAsync(CategoryPostDto dto);
        Task<CategoryGetDto?> UpdateCategoryAsync(int id, CategoryPostDto dto);
        Task<bool> DeleteCategoryAsync(int id);
    }
}