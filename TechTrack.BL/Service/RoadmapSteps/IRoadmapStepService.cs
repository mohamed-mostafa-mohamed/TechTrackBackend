using CMS.BL.DTOs;
using CMS.DAL.Models.Entities;
using CMS.DAL.Repo.roadmapstep;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace CMS.BL.Service.roadmastep
{
    public interface IRoadmapStepService
    {
        Task<IEnumerable<RoadmapStepGetDto>> GetAllAsync();
        Task<RoadmapStepGetDto?> GetByIdAsync(int id);
        Task<RoadmapStepGetDto> AddAsync(RoadmapStepPostDto dto);
        Task<RoadmapStepGetDto?> UpdateAsync(int id, RoadmapStepPostDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
