using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Repo.GenericRepo
{
    public interface IGenericRepo<T>
    {
     public Task<IEnumerable<T>> GetAll();
   public Task<T> GetById(int id);
       public Task Add(T entity);
       public Task Delete(T entity);
    }
}
