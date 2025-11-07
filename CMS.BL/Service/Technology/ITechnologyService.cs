using CMS.BL.DTOs;
using CMS.DAL.Models.Entities;
using CMS.DAL.Repo.technology;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace CMS.BL.Service.technology
{
    public interface ITechnologyService
    {
        Task<IEnumerable<TechnologyGetDto>> GetAllAsync();
        Task<TechnologyGetDto?> GetByIdAsync(int id);
        Task<TechnologyGetDto> AddAsync(TechnologyPostDto dto);
        Task<TechnologyGetDto?> UpdateAsync(int id, TechnologyPostDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
