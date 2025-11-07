using CMS.DAL.Models.Entities;
using CMS.DAL.Repo.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CMS.DAL.Models.Data;

namespace CMS.DAL.Repo.track
{
    public class TrackRepository : IGeneric<Track>, ITrackRepository
    {
        private readonly ApplicationDbContext _context;

        public TrackRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Track>> GetAllAsync()
        {
            return await _context.Tracks.AsNoTracking()
                .ToListAsync();
        }

        public async Task<Track?> GetByIdAsync(int id)
        {
            return await _context.Tracks
                .FirstOrDefaultAsync(t => t.TrackId == id);
        }

        public async Task<Track> AddAsync(Track track)
        {
            _context.Tracks.Add(track);
            await _context.SaveChangesAsync();
            return track;
        }

        public async Task<Track> UpdateAsync(Track track)
        {
            _context.Tracks.Update(track);
            await _context.SaveChangesAsync();
            return track;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.Tracks.FindAsync(id);
            _context.Tracks.Remove(existing!);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
