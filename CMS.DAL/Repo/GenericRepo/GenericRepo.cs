
using CMS.DAL.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Repo.GenericRepo
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        public readonly ApplicationDbContext _DbContext;
        public GenericRepo(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }
        public async Task< IEnumerable<T>> GetAll()
        {
            return await _DbContext.Set<T>().ToListAsync();
        }
        public  async Task<T> GetById(int id)
        {
            return await _DbContext.Set<T>().FindAsync(id);
        }

        public async Task Add(T entity)
        {
            await _DbContext.AddAsync(entity);
          await   _DbContext.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
          _DbContext.Remove(entity);
            await _DbContext.SaveChangesAsync();
        }
    }
}

