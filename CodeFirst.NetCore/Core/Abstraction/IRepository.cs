using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.NetCore
{
    public interface IRepository { }

    public interface IRepository<TEntity> 
        : IRepository where TEntity : IEntity
    {
        Task AddAsync(TEntity data);
        Task UpdateAsync(int id ,TEntity data);
        Task DeleteAsync(int id);

        Task<TEntity> GetAsync(int id);

        Task<IEnumerable<TEntity>> GetListAsync();

    }
    
}
