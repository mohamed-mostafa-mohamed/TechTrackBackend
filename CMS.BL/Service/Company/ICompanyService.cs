using CMS.BL.DTOs;
using CMS.DAL.Models.Entities;
using CMS.DAL.Repo.compnay;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace CMS.BL.Service.company
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICompanyService
    {
        Task<IEnumerable<GetCompanyDto>> GetAllAsync();
        Task<GetCompanyDto?> GetByIdAsync(int id);
        Task<GetCompanyDto> CreateAsync(CreateCompanyDto dto);
        Task<GetCompanyDto?> UpdateAsync(int id, CreateCompanyDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
