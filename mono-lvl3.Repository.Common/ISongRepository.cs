using mono_lvl3.Common.Filters;
using mono_lvl3.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mono_lvl3.Repository.Common
{
    public interface ISongRepository
    {
        Task<IEnumerable<ISong>> GetAsync(IFilter filter = null);
        Task<ISong> GetByIDAsync(Guid id);
        Task<int> AddAsync(ISong song);
        Task<int> UpdateAsync(ISong song);
        Task<int> DeleteAsync(Guid id);
        Task<IUnitOfWork> CreateUnitOfWork();
        IEnumerable<IAlbum> GetAlbumsAsync();
    }
}
