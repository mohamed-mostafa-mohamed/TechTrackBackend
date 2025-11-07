using CMS.DAL.Models.Entities;
using CMS.DAL.Repo.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CMS.DAL.Models.Data;

namespace CMS.DAL.Repo.roadmap
{
    public class RoadmapRepository : IGeneric<Roadmap>, IRoadmapRepository
    {
        private readonly ApplicationDbContext _context;

        public RoadmapRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Roadmap>> GetAllAsync()
        {
            return await _context.Roadmaps
                .Include(r => r.RoadmapSteps.OrderBy(s => s.StepOrder))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Roadmap?> GetByIdAsync(int id)
        {
            return await _context.Roadmaps
                .Include(r => r.RoadmapSteps.OrderBy(s => s.StepOrder))
                .FirstOrDefaultAsync(r => r.RoadmapId == id);
        }

        public async Task<Roadmap> AddAsync(Roadmap roadmap)
        {
            _context.Roadmaps.Add(roadmap);
            await _context.SaveChangesAsync();
            return roadmap;
        }

        public async Task<Roadmap> UpdateAsync(Roadmap roadmap)
        {
            _context.Roadmaps.Update(roadmap);
            await _context.SaveChangesAsync();
            return roadmap;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var roadmap = await _context.Roadmaps.FindAsync(id);
            _context.Roadmaps.Remove(roadmap!); 
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
