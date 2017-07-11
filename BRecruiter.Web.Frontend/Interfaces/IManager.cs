using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BRecruiter.Web.Frontend.Interfaces
{
    public interface IManager<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int id);
        Task<List<TEntity>> Get();
        Task<TEntity> Insert(TEntity model);
        Task Delete(int id);
        Task Update(TEntity model);
    }
}
