using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GL_DotNetFullStack_Project.Models
{
    public abstract class BaseEfCoreRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : class, IBaseEntity
        where TContext : DbContext
    {
        private readonly TContext _context;
        public BaseEfCoreRepository(TContext context)
        {
             _context = context;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            
            if (entity == null)
            {
                return null;
            }
            else
            {               
                _context.Set<TEntity>().Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<TEntity> DeleteById(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Get(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> Get()
        {
            using (_context)
            {
                return await _context.Set<TEntity>().ToListAsync();  
            }
        }

         public async Task<int> GetMaxId(TEntity entity)
        {
            return await _context.Set<TEntity>().MaxAsync(entity => entity.ID);
           // return await _context.TEntity.Max (e => e.ID);
        } 

        public async Task<TEntity> Update(TEntity entity)
        {
            using (_context)
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return entity;
            }
               
        }
    }
}
