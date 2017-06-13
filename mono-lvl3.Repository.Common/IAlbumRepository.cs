using mono_lvl3.Common.Filters;
using mono_lvl3.Model.Common;
using mono_lvl3.Model.DomainModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mono_lvl3.Repository.Common
{
    public interface IAlbumRepository
    {
        Task<IEnumerable<IAlbum>> GetAsync(IFilter filter = null);
        Task<IAlbum> GetByIDAsync(Guid id);
        Task<int> AddAsync(IUnitOfWork unitOfWork, IAlbum album);
        Task<int> UpdateAsync(IUnitOfWork unitOfWork, IAlbum album);
        Task<int> DeleteAsync(IUnitOfWork unitOfWork, Guid id);
        Task<IUnitOfWork> CreateUnitOfWork();
    }
}
