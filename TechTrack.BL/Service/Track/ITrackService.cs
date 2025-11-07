using CMS.BL.DTOs;
using CMS.DAL.Models.Entities;
using CMS.DAL.Repo.track;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace CMS.BL.Service.track
{
    public interface ITrackService
    {
        Task<IEnumerable<TrackGetDto>> GetAllAsync();
        Task<TrackGetDto?> GetByIdAsync(int id);
        Task<TrackGetDto> AddAsync(TrackPostDto dto);
        Task<TrackGetDto?> UpdateAsync(int id, TrackPostDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
