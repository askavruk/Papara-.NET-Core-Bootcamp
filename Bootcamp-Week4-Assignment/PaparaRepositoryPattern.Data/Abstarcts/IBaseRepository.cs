using PaparaRepositoryPattern.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PaparaRepositoryPattern.Data.Abstarcts
{
    public interface IBaseRepository<T> where T : class
    {
        Task<int> Add(T entity);
        Task<int> Delete(int id);
        Task<int> Update(T entity);
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
    }
}
