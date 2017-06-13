using mono_lvl3.Common.Filters;
using mono_lvl3.Model.Common;
using mono_lvl3.Model.DomainModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mono_lvl3.Repository.Common
{
    public interface ISongRepository
    {
        Task<IEnumerable<ISong>> GetAsync(IFilter filter = null);
        Task<ISong> GetByIDAsync(Guid id);
        Task<int> AddAsync(IUnitOfWork unitOfWork, ISong song);
        Task<int> UpdateAsync(IUnitOfWork unitOfWork, ISong song);
        Task<int> DeleteAsync(IUnitOfWork unitOfWork, Guid id);
        Task<IUnitOfWork> CreateUnitOfWork();
    }
}
