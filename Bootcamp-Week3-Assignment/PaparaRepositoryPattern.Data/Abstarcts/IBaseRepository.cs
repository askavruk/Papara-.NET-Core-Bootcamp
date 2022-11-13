using PaparaRepositoryPattern.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PaparaRepositoryPattern.Data.Abstarcts
{
    public interface IBaseRepository<T> where T : IBaseEntity
    {
        Task Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> GetById(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAll();
    }
}
