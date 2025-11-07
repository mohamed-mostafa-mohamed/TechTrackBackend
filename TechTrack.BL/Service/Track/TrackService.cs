using CMS.BL.Constants;
using CMS.BL.DTOs;
using CMS.BL.Extensions.MappingExtensions;
using CMS.DAL.Models.Entities;
using CMS.DAL.Repo.track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.BL.Service.track
{
    public class TrackService : ITrackService
    {
        private readonly ITrackRepository _repo;

        public TrackService(ITrackRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<TrackGetDto>> GetAllAsync()
        {
            try
            {
                var tracks = await _repo.GetAllAsync();
                return tracks.Select(t => t.ToGetDto());
            }
            catch (Exception)
            {
                throw new ApplicationException(string.Format(ErrorMessages.GetAllFailed, EntityNames.Track));
            }
        }

        public async Task<TrackGetDto?> GetByIdAsync(int id)
        {
            try
            {
                var track = await _repo.GetByIdAsync(id);
                if (track == null)
                    throw new ApplicationException(string.Format(ErrorMessages.NotFound, EntityNames.Track, id));

                return track.ToGetDto();
            }
            catch (Exception)
            {
                throw new ApplicationException(string.Format(ErrorMessages.GetByIdFailed, EntityNames.Track, id));
            }
        }

        public async Task<TrackGetDto> AddAsync(TrackPostDto dto)
        {
            try
            {
                var entity = dto.ToEntity();
                var created = await _repo.AddAsync(entity);
                return created.ToGetDto();
            }
            catch (Exception)
            {
                throw new ApplicationException(string.Format(ErrorMessages.CreateFailed, EntityNames.Track));
            }
        }

        public async Task<TrackGetDto?> UpdateAsync(int id, TrackPostDto dto)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                if (existing == null)
                    throw new ApplicationException(string.Format(ErrorMessages.NotFound, EntityNames.Track, id));

                existing.UpdateFromDto(dto);
                var updated = await _repo.UpdateAsync(existing);

                return updated.ToGetDto();
            }
            catch (Exception)
            {
                throw new ApplicationException(string.Format(ErrorMessages.UpdateFailed, EntityNames.Track, id));
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var deleted = await _repo.DeleteAsync(id);
                if (!deleted)
                    throw new ApplicationException(string.Format(ErrorMessages.NotFound, EntityNames.Track, id));

                return deleted;
            }
            catch (Exception)
            {
                throw new ApplicationException(string.Format(ErrorMessages.DeleteFailed, EntityNames.Track, id));
            }
        }
    }
}
