using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.BL.DTOs;
using CMS.DAL.Models.Entities;
namespace CMS.BL.Extensions.MappingExtensions
{
    public static class CompanyMappingExtensions
    {
      
        public static Company ToEntity(this CreateCompanyDto dto)
        {
            return new Company
            {
                CompanyName = dto.CompanyName,
                Industry = dto.Industry,
                WebsiteUrl = dto.WebsiteUrl,
                Description = dto.Description
            };
        }

     
        public static GetCompanyDto ToGetDto(this Company entity)
        {
            return new GetCompanyDto
            {
                CompanyId = entity.CompanyId,
                CompanyName = entity.CompanyName,
                Industry = entity.Industry,
                WebsiteUrl = entity.WebsiteUrl,
                Description = entity.Description
            };
        }

        public static void UpdateFromDto(this Company entity, CreateCompanyDto dto)
        {
            entity.CompanyName = dto.CompanyName;
            entity.Industry = dto.Industry;
            entity.WebsiteUrl = dto.WebsiteUrl;
            entity.Description = dto.Description;
        }
    }
}

