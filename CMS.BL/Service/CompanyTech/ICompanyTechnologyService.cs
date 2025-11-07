using CMS.BL.DTOs;
using CMS.DAL.Models.Entities;
using CMS.DAL.Repo.companytech;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace CMS.BL.Service.companytech
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICompanyTechnologyService
    {
        Task<IEnumerable<GetCompanyTechnologyDto>> GetAllAsync();
        Task<GetCompanyTechnologyDto?> GetByIdAsync(int id);
        Task<GetCompanyTechnologyDto> CreateAsync(CreateCompanyTechnologyDto dto);
        Task<GetCompanyTechnologyDto?> UpdateAsync(int id, CreateCompanyTechnologyDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
