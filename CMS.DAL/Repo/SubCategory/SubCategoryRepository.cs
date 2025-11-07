using CMS.DAL.Models.Entities;
using CMS.DAL.Repo.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CMS.DAL.Models.Data;

namespace CMS.DAL.Repo.subcategory
{
    public class SubCategoryRepository : IGeneric<SubCategory>, ISubCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public SubCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SubCategory>> GetAllAsync()
        {
            return await _context.SubCategories
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<SubCategory?> GetByIdAsync(int id)
        {
            return await _context.SubCategories
                .FirstOrDefaultAsync(sc => sc.SubCategoryId == id);
        }

        public async Task<SubCategory> AddAsync(SubCategory subCategory)
        {
            _context.SubCategories.Add(subCategory);
            await _context.SaveChangesAsync();
            return subCategory;
        }

        public async Task<SubCategory> UpdateAsync(SubCategory subCategory)
        {
            _context.SubCategories.Update(subCategory);
            await _context.SaveChangesAsync();
            return subCategory;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var subCategory = await _context.SubCategories.FindAsync(id);
            _context.SubCategories.Remove(subCategory!);
            await _context.SaveChangesAsync();
            return true;
        }

     
    }
}
