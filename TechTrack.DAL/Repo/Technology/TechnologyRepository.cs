using CMS.DAL.Models.Entities;
using CMS.DAL.Repo.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CMS.DAL.Models.Data;

namespace CMS.DAL.Repo.technology
{
    public class TechnologyRepository : IGeneric<Technology>, ITechnologyRepository
    {
        private readonly ApplicationDbContext _context;

        public TechnologyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Technology>> GetAllAsync()
        {
            return await _context.Technologies
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Technology?> GetByIdAsync(int id)
        {
            return await _context.Technologies
                .FirstOrDefaultAsync(t => t.TechnologyId == id);
        }

        public async Task<Technology> AddAsync(Technology technology)
        {
            _context.Technologies.Add(technology);
            await _context.SaveChangesAsync();
            return technology;
        }

        public async Task<Technology> UpdateAsync(Technology technology)
        {
            _context.Technologies.Update(technology);
            await _context.SaveChangesAsync();
            return technology;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tech = await _context.Technologies.FindAsync(id);
            _context.Technologies.Remove(tech!);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
