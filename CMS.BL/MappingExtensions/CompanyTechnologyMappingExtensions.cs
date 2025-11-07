using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.BL.DTOs;
using CMS.DAL.Models.Entities;

namespace CMS.BL.Extensions.MappingExtensions
{
    public static class CompanyTechnologyMappingExtensions
    {
        public static CompanyTechnology ToEntity(this CreateCompanyTechnologyDto dto)
        {
            return new CompanyTechnology
            {
                CompanyId = dto.CompanyId,
                TechnologyId = dto.TechnologyId,
                UsageLevel = dto.UsageLevel,
                Notes = dto.Notes
            };
        }

        public static GetCompanyTechnologyDto ToGetDto(this CompanyTechnology entity)
        {
            return new GetCompanyTechnologyDto
            {
                CompanyTechnologyId = entity.CompanyTechnologyId,
                CompanyId = entity.CompanyId,
                CompanyName = entity.Company?.CompanyName,
                TechnologyId = entity.TechnologyId,
                TechnologyName = entity.Technology?.TechnologyName,
                UsageLevel = entity.UsageLevel,
                Notes = entity.Notes
            };
        }

        public static void UpdateFromDto(this CompanyTechnology entity, CreateCompanyTechnologyDto dto)
        {
            entity.CompanyId = dto.CompanyId;
            entity.TechnologyId = dto.TechnologyId;
            entity.UsageLevel = dto.UsageLevel;
            entity.Notes = dto.Notes;
        }
    }
}
