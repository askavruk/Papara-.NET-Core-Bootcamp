using Microsoft.EntityFrameworkCore;
using PaparaRepositoryPattern.Data.Abstarcts;
using PaparaRepositoryPattern.Data.Context;
using PaparaRepositoryPattern.Domain;
using PaparaRepositoryPattern.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PaparaRepositoryPattern.Data.Concretes
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseEntity
    {
        private readonly PaparaDbContext context;
        protected DbSet<T> table;

        public BaseRepository(PaparaDbContext context)
        {
            this.context = context;
            table = context.Set<T>();
        }

        public async Task Create(T entity)
        {
            table.Add(entity);
            await context.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            entity.DeleteDate = DateTime.Now;
            entity.Status = Status.Passive;
            context.SaveChanges();
        }

        public async Task<List<T>> GetAll()
        {
            var listOfAll = await table.ToListAsync();
            return listOfAll;
        }

        public async Task<T> GetById(Expression<Func<T, bool>> expression)
        {
            return await table.Where(expression).FirstOrDefaultAsync();
        }

        public void Update(T entity)
        {
            context.Update(entity);
            context.SaveChanges();
        }
    }
}
