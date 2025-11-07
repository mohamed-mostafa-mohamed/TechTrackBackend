using CMS.DAL.Models.Entities;
using CMS.DAL.Repo.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CMS.DAL.Models.Data;

namespace CMS.DAL.Repo.roadmapstep
{
    public class RoadmapStepRepository : IGeneric<RoadmapStep>, IRoadmapStepRepository
    {
        private readonly ApplicationDbContext _context;

        public RoadmapStepRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RoadmapStep>> GetAllAsync()
        {
            return await _context.RoadmapSteps
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<RoadmapStep?> GetByIdAsync(int id)
        {
            return await _context.RoadmapSteps.FindAsync(id);
        }

        public async Task<RoadmapStep> AddAsync(RoadmapStep step)
        {
            _context.RoadmapSteps.Add(step);
            await _context.SaveChangesAsync();
            return step;
        }

        public async Task<RoadmapStep> UpdateAsync(RoadmapStep step)
        {
            _context.RoadmapSteps.Update(step);
            await _context.SaveChangesAsync();
            return step;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var step = await _context.RoadmapSteps.FindAsync(id);
            _context.RoadmapSteps.Remove(step!); 
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
