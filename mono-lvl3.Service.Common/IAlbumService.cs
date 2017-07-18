using mono_lvl3.Common.Filters;
using mono_lvl3.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mono_lvl3.Service.Common
{
    public interface IAlbumService
    {
        #region Methods

        Task<IEnumerable<IAlbum>> GetAsync(IFilter filter = null);
        Task<IAlbum> GetByIDAsync(Guid id);
        Task<int> AddAsync(IAlbum album);
        Task<int> UpdateAsync(IAlbum album);
        Task<IAlbum> AddArtistsToAlbumAsync(Guid id, IEnumerable<Guid> artistIds);
        Task<int> DeleteAsync(Guid id);

        #endregion Methods
    }
}
