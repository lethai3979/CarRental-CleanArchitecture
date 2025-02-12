using Domain.Primitives;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServer.Repositories
{
    public abstract class GenericRepository<TEntity, EntityId> 
        where TEntity : BaseEntity<EntityId>
        where EntityId : Domain.Primitives.EntityId
    {
        protected ApplicationDbContext context;

        protected GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().Where(i => !i.IsDeleted).ToListAsync();
        }

        public async Task<TEntity?> GetById(EntityId id)
        {
            return await context.Set<TEntity>().SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task Add(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }
    }
}
