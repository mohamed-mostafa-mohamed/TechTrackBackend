using CMS.BL.DTOs;
using CMS.DAL.Models.Entities;
using CMS.DAL.Repo.roadmap;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace CMS.BL.Service.roadmap
{
    public interface IRoadmapService
    {
        Task<IEnumerable<RoadmapGetDto>> GetAllAsync();
        Task<RoadmapGetDto?> GetByIdAsync(int id);
        Task<RoadmapGetDto> AddAsync(RoadmapPostDto dto);
        Task<RoadmapGetDto?> UpdateAsync(int id, RoadmapPostDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
