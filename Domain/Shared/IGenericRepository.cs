using Domain;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared
{
    public interface IGenericRepository<TEntity, TEntityId> where TEntity : BaseEntity<TEntityId>
    {
        Task<TEntity?> GetById(TEntityId id);
        Task<List<TEntity>> GetAll();
        Task Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
