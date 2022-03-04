
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace Comunes.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        ValueTask<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity, object dto, Expression<Func<TEntity, bool>> currentEntityFilter);

        Task<IEnumerable<TEntity>> GetFilterOrderBy(Expression<Func<TEntity, bool>> predicate = null,
                                                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                    string includeProperties = "");
    }

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        internal DbSet<TEntity> dbSet;
        public Repository(DbContext context)
        {
            this.Context = context;
            this.dbSet = context.Set<TEntity>();
        }
        public async Task AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await Context.Set<TEntity>().AddRangeAsync(entities);
        }
                

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public ValueTask<TEntity> GetByIdAsync(int id)
        {
            return Context.Set<TEntity>().FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

        public void Update(TEntity entity, object dto, Expression<Func<TEntity, bool>> currentEntityFilter)    
        {
            var current = Context.Set<TEntity>().FirstOrDefault(currentEntityFilter);
            Context.Entry(current).CurrentValues.SetValues(dto);
        }

        /// <summary>
        /// 
        /// Tomado de:
        /// https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
        /// </summary>
        /// <param name="filter">Expresión lambda: x => x.Campo OperadorLógico valor</param>
        /// <param name="orderBy">Expresión lambda: q => q.OrderBy(s => s.LastName)</param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public async virtual Task<IEnumerable<TEntity>> GetFilterOrderBy(
           Expression<Func<TEntity, bool>> predicate = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }
    }
}