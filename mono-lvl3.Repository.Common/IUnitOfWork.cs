using System;
using System.Threading.Tasks;

namespace mono_lvl3.Repository.Common
{
    public interface IUnitOfWork
    {
        Task<int> AddAsync<T>(T entity) where T : class;
        Task<int> UpdateAsync<T>(T entity) where T : class;
        Task<int> DeleteAsync<T>(T entity) where T : class;
        Task<int> DeleteAsync<T>(Guid id) where T : class;
        Task<int> CommitAsync();
    }
}
