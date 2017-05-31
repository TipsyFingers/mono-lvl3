using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mono_lvl3.Repository.Common
{
    public interface IGenericRepository
    {
        IUnitOfWork CreateUnitOfWork();
        Task<List<T>> GetAsync<T>() where T : class;
        Task<T> GetByIDAsync<T>(Guid id) where T : class;
        Task<int> AddAsync<T>(T entity) where T : class;
        Task<int> UpdateAsync<T>(T entity) where T : class;
        Task<int> DeleteAsync<T>(T entity) where T : class;
        Task<int> DeleteAsync<T>(Guid id) where T : class;
        IQueryable<T> GetWhere<T>() where T : class;
    }
}
