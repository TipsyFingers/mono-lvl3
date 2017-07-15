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
        Task<int> AddAsync(IAlbum album);
        Task<int> UpdateAsync(IAlbum album);
        Task<int> DeleteAsync(Guid id);
        Task<IAlbum> AddArtistsToAlbumAsync(Guid id, IEnumerable<Guid> artistIds);
    }
}
