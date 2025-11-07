using CMS.DAL.Models.Entities;
using CMS.DAL.Repo.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CMS.DAL.Models.Data;

namespace CMS.DAL.Repo.companytech
{
    public class CompanyTechnologyRepository : IGeneric<CompanyTechnology>, ICompanyTechnologyRepository
    {
        private readonly ApplicationDbContext _context;

        public CompanyTechnologyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CompanyTechnology>> GetAllAsync()
        {
            return await _context.CompanyTechnologies
                .Include(ct => ct.Company)
                .Include(ct => ct.Technology)
                .ToListAsync();
        }

        public async Task<CompanyTechnology?> GetByIdAsync(int id)
        {
            return await _context.CompanyTechnologies
                .Include(ct => ct.Company)
                .Include(ct => ct.Technology)
                .FirstOrDefaultAsync(ct => ct.CompanyTechnologyId == id);
        }

        public async Task<CompanyTechnology> AddAsync(CompanyTechnology entity)
        {
            _context.CompanyTechnologies.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<CompanyTechnology> UpdateAsync(CompanyTechnology entity)
        {
            _context.CompanyTechnologies.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.CompanyTechnologies.FindAsync(id);
            _context.CompanyTechnologies.Remove(entity!); 
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
