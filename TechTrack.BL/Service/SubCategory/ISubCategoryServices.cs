using CMS.BL.DTOs;
using CMS.DAL.Models.Entities;
using CMS.DAL.Repo.subcategory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace CMS.BL.Service.subcategory
{
    public interface ISubCategoryService
    {
        Task<IEnumerable<SubCategoryGetDto>> GetAllAsync();

        Task<SubCategoryGetDto?> GetByIdAsync(int id);

        Task<SubCategoryGetDto> AddAsync(SubCategoryPostDto subCategoryDto);

        Task<SubCategoryGetDto?> UpdateAsync(int id, SubCategoryPostDto subCategoryDto);

        Task<bool> DeleteAsync(int id);

    }
}